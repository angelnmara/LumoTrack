using FirebaseNet.Messaging;
using LumoTrack.Business;
using LumoTrack.DTO;
using LumoTrack.Notifier.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumoTrack.Notifier
{
    public class NotifierDevices
    {
        private List<DeviceDTO> _deviceDTOList;

        private List<VehicleDTO> _vehicleList;

        private DateTime UTCTime;
        public List<DeviceDTO> Start()
        {
            ConsoleHelper.WriteTitle("Geofence Analyser 1.0");

            try
            {
                List<DeviceDTO> deviceDtoList = new List<DeviceDTO>();
                List<DeviceDTO> devicesResponse = new List<DeviceDTO>();

                var devicesBusiness = new DeviceBusiness();
                var vehiclesBusiness = new VehiclesBusiness();
                UTCTime = DateTime.UtcNow;
                ConsoleHelper.WriteMessage("Get devices in Coordinated Universal Time:" + UTCTime.ToString());
                ConsoleHelper.WriteSeparator();

                var devices = devicesBusiness.GetDevicesToNotify(UTCTime);

                string hash = new HashHelper(new System.Net.Http.HttpClient()).GetHash().Result;

                ConsoleHelper.WriteMessage("Analyzing which devices to notify");
                ConsoleHelper.WriteSeparator();
                if (devices != null)
                {
                    devicesResponse = vehiclesBusiness.DevicesToNotify(hash, devices, 1.0).Result;
                }
                else
                {
                    ConsoleHelper.WriteWarning("Failed connection with Kuktrack");
                    ConsoleHelper.WriteSeparator();
                }

                ConsoleHelper.WriteMessage("Notifying");
                ConsoleHelper.WriteSeparator();

                if (devicesResponse != null)
                {
                    foreach (var device in devicesResponse)
                    {
                        DeviceDTO deviceResult = Notify(device).Result;

                        deviceDtoList.Add(deviceResult);

                        var diference = (Convert.ToDouble(deviceDtoList.Count) / Convert.ToDouble(devicesResponse.Count)) * 100;

                        ConsoleHelper.ClearCurrentConsoleLine();

                        Console.Write("Working " + diference.ToString() + "%");
                    }
                    ConsoleHelper.WriteSeparator();

                    ConsoleHelper.WriteMessage("Update Information information to database");
                    ConsoleHelper.WriteSeparator();

                    UpdateDevicesDatabase(deviceDtoList);
                }
                else
                {
                    ConsoleHelper.WriteWarning("Failed connection with Kuktrack");
                    ConsoleHelper.WriteSeparator();
                }

                return devicesResponse;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        private void UpdateDevicesDatabase(List<DeviceDTO> devicesResponse)
        {
            var devicesBusiness = new DeviceBusiness();

            devicesBusiness.UpdateNotifiedDevices(devicesResponse, UTCTime);
        }

        private async Task<DeviceDTO> Notify(DeviceDTO devices)
        {
            FCMClient client = new FCMClient(System.Configuration.ConfigurationManager.AppSettings["fireBaseServerKey"].ToString());

            Dictionary<string, string> keys = new Dictionary<string, string>();
            keys.Add("title", "Sigue tu camión");
            keys.Add("body", "Existen unidades cerca de ti");
            keys.Add("Action", "Map");

            var message = new FirebaseNet.Messaging.Message()
            {
                To = devices.FireBaseToken,
                Data = keys
            };

            if (devices.devicesType == Common.DeviceTypesEnum.IOS)
            {
                var notificationIOS = new IOSNotification();
                notificationIOS.Title = "Sigue tu camión";
                notificationIOS.Body = "Existen unidades cerca de ti";
                notificationIOS.ClickAction = "Map";

                message.Notification = notificationIOS;
            }


        
            IFCMResponse result = await client.SendMessageAsync(message);

            Console.WriteLine(devices.FireBaseToken+"  "+ ((DownstreamMessageResponse)result).Failure);

            return devices;
        }
    }
}
