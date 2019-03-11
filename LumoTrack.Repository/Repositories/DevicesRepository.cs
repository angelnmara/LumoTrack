using LumoTrack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zorbek.Essentials.Data.Repositories;

namespace LumoTrack.Repository.Repositories
{
    public class DevicesRepository : GenericRepository<Devices, LumoTrackContext>
    {
        public DevicesRepository(LumoTrackContext context) : base(context)
        {

        }

        public Devices Read(string deviceId)
        {
            var device = context.Device.FirstOrDefault(x => x.Id.ToString() == deviceId);

            return device;
        }

        public List<Devices> GetList(DateTime now)
        {
            var devices = context.Device.Where(x => x.LastNotification <= now);

            //var devices = context.Device;

            return devices.ToList();
        }
    }
}
