using System;
using System.Collections.Generic;
using System.Text;

namespace LumoTrack.Model
{
    public class Notification
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Important { get; set; }

        public string Message { get; set; }

        public DateTime NotificationDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string UserId { get; set; }
    }
}
