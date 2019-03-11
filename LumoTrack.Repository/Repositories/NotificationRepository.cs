using LumoTrack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zorbek.Essentials.Data.Repositories;

namespace LumoTrack.Repository.Repositories
{
    public class NotificationRepository : GenericRepository<Notification, LumoTrackContext>
    {
        public NotificationRepository(LumoTrackContext context) : base(context)
        {

        }

        public List<Notification> GetList(string userId)
        {
            var response = context.Notification.Where(x => x.UserId == userId);

            return response.ToList();
        }

        public List<Notification> GetListFilter()
        {
            DateTime utcDateTime = DateTime.UtcNow;
            TimeSpan offSet = TimeSpan.Parse("-06:00:00"); //CDMX offset
            DateTime dateTime = utcDateTime + offSet;
            dateTime = dateTime.Date;

            var response = context.Notification.Where(x => x.ExpiryDate >= dateTime);

            return response.ToList();
        }
    }
}
