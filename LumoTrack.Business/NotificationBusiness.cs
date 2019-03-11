using FirebaseNet.Messaging;
using LumoTrack.Business.Mappers;
using LumoTrack.DTO;
using LumoTrack.Model;
using LumoTrack.Repository;
using LumoTrack.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LumoTrack.Business
{
    public class NotificationBusiness
    {

        private LumoTrackContext _lumoTrackContext;

        private readonly NotificationRepository _notificationRepository;

        public NotificationBusiness()
        {
            _lumoTrackContext = new LumoTrackContext();
            _notificationRepository = new NotificationRepository(_lumoTrackContext);
        }

        public NotificationDTO Create(NotificationDTO notificationDTO)
        {
            var notificationModel = notificationDTO.ToModel();

            var response=_notificationRepository.Create(notificationModel);

            return response.ToDTO();
        }


        public List<NotificationDTO> GetList(string userId)
        {
            List<Notification> response = _notificationRepository.GetList(userId);

            return response.ToDTO();
        }

        public List<NotificationDTO> GetListComplete()
        {
            List<Notification> response = _notificationRepository.GetList().ToList();

            return response.ToDTO().OrderBy(x=>x.CreationDate).ToList();
        }

        public List<NotificationDTO> GetList()
        {
            List<Notification> response = _notificationRepository.GetListFilter();

            return response.ToDTO();
        }

        public NotificationDTO Read(int notificationId)
        {
            var notification = _notificationRepository.Read(notificationId);

            return notification.ToDTO();
        }

        public NotificationDTO Update(NotificationDTO notificationDTO)
        {
            Notification notification = notificationDTO.ToModel();

            var response = _notificationRepository.Update(notification);

            return response.ToDTO();
        }

        public bool Delete(int id)
        {
            bool response = false;

            var notification = _notificationRepository.Delete(id);

            if (notification != null)
                response = true;

            return response;
        }
    }
}
