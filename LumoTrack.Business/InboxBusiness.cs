using LumoTrack.Business.Mappers;
using LumoTrack.DTO;
using LumoTrack.Model;
using LumoTrack.Repository;
using LumoTrack.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LumoTrack.Business
{
    public class InboxBusiness
    {
        private LumoTrackContext _lumoTrackContext;

        private readonly InboxRepository _inboxRepository;

        public InboxBusiness()
        {
            _lumoTrackContext = new LumoTrackContext();
            _inboxRepository = new InboxRepository(_lumoTrackContext);
        }

        public InboxDTO Create(InboxDTO inboxDTO)
        {
            Inbox inbox = inboxDTO.ToModel();

            Inbox response = _inboxRepository.Create(inbox);

            return response.ToDTO();
        }

        public InboxDTO Read(int id)
        {
            Inbox inbox = _inboxRepository.Read(id);

            return inbox.ToDTO();
        }

        public InboxDTO Update(InboxDTO inboxDTO)
        {
            Inbox inbox = inboxDTO.ToModel();

            Inbox response = _inboxRepository.Update(inbox);

            return response.ToDTO();
        }

        public List<InboxDTO> GetList()
        {
            List<Inbox> inboxes = _inboxRepository.GetList().ToList();

            inboxes = inboxes.Where(x =>
                    x.ResponseDate == null ||
                    (x.ResponseDate != null && x.ResponseDate.Value.AddDays(30) > DateTime.Today))
                .OrderBy(x => x.ResponseDate.HasValue)
                .ThenBy(x => x.CreationDate)
                .ToList();

            return inboxes.ToDTO();
        }

        public List<InboxDTO> GetList(string userId)
        {
            List<Inbox> inboxes = _inboxRepository.GetListbyUser(userId).ToList();

            return inboxes.ToDTO();
        }
    }
}
