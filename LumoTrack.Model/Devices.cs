using LumoTrack.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LumoTrack.Model
{
    public class Devices
    {
        [Key]
        public Guid Id { get; set; }

        public string FireBaseToken { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime LastNotification { get; set; }

        public string TimeZone { get; set; }

        public DeviceTypesEnum DeviceType { get; set; }
    }
}
