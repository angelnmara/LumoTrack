using LumoTrack.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace LumoTrack.API.Helpers
{
    public class HashHelper
    {
        private readonly HttpClient _httpClient;
        public HashHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetHash()
        {
            try
            {
                Dictionary<string, string> json = GetJsonInfo();

                string hash = await CheckHash(json);

                return hash;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private static Dictionary<string, string> GetJsonInfo()
        {
            string pathjson = GetPath();

            Dictionary<string, string> items;

            using (StreamReader r = new StreamReader(pathjson))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }

            return items;
        }

        private async Task<string> CheckHash(Dictionary<string, string> json)
        {
            string hash = json["hash"];

            DateTime lastDateRefreshToken = DateTime.Parse(json["LastDateRefreshToken"]);

            double dayOfdifference = (DateTime.Now - lastDateRefreshToken).TotalDays;

            if (dayOfdifference >= 25.0)
            {
                var appLog = new EventLog("Application");
                appLog.Source = "LumoTrack";
                appLog.WriteEntry("Dias de diferencia :" + dayOfdifference.ToString());

                hash = await SetNewHash();

                appLog = new EventLog("Application");
                appLog.Source = "LumoTrack";
                appLog.WriteEntry("Hash:" + hash);
            }

            return hash;
        }

        public async Task<string> SetNewHash()
        {
            string pathjson = GetPath();

            Dictionary<string, string> items = new Dictionary<string, string>();

            string hash = await LoginAsync();

            items.Add("hash", hash);

            items.Add("LastDateRefreshToken", DateTime.Now.Date.ToString());

            using (StreamWriter file = File.CreateText(pathjson))
            {
                JsonSerializer serializer = new JsonSerializer();

                serializer.Serialize(file, items);

                var appLog = new EventLog("Application");
                appLog.Source = "LumoTrack";
                appLog.WriteEntry("set hash in json");
            }

            return hash;
        }

        private static string GetPath()
        {
            string directory = ConfigurationManager.AppSettings["hashPath"];

            string pathjson = Path.Combine(directory, "hash.json");

            return pathjson;
        }

        private async Task<string> LoginAsync()
        {
            var authenticationBusiness = new AuthenticationBusiness();

            string email = ConfigurationManager.AppSettings["email"];

            string password = ConfigurationManager.AppSettings["password"];

            var hash = await authenticationBusiness.LoginKucktrack(email, password, _httpClient);

            var appLog = new EventLog("Application");
            appLog.Source = "LumoTrack";
            appLog.WriteEntry("Response of kucktrack  :" + hash.Message);

            return hash.Data.Hash;
        }







    }
}