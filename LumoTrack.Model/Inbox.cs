using LumoTrack.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LumoTrack.Model
{
    public class Inbox
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public string TruckName { get; set; }

        public string TruckId { get; set; }

        public ReportTypesEnum ReportType { get; set; }

        public string Message { get; set; }

        public string Response { get; set; }

        public DateTime? ResponseDate { get; set; }

        public string UserId { get; set; }

        public string UserResponseId { get; set; }
    }
}
