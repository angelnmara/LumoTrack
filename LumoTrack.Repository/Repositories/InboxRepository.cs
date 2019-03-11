using LumoTrack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zorbek.Essentials.Data.Repositories;

namespace LumoTrack.Repository.Repositories
{
    public class InboxRepository : GenericRepository<Inbox, LumoTrackContext>
    {
        public InboxRepository(LumoTrackContext context) : base(context)
        {

        }

        public List<Inbox> GetListbyUser(string userId)
        {
            var inboxList = context.Inbox.Where(x => x.UserId == userId);
            
            return inboxList.ToList();
        }
    }
}
