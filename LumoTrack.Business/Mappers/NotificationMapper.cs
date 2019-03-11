using LumoTrack.DTO;
using LumoTrack.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LumoTrack.Business.Mappers
{
    public static class NotificationMapper
    {
        public static Notification ToModel(this NotificationDTO notificationDTO)
        {
            var notification = new Notification();

            notification.Id = notificationDTO.Id;
            notification.CreationDate = notificationDTO.CreationDate;
            notification.ExpiryDate = notificationDTO.ExpiryDate;
            notification.Important = notificationDTO.Important;
            notification.Message = notificationDTO.Message;
            notification.NotificationDate = notificationDTO.NotificationDate;
            notification.Title = notificationDTO.Title;
            notification.UserId = notificationDTO.UserId;

            return notification;
        }

        public static NotificationDTO ToDTO(this Notification notification)
        {
            var notificationDTO = new NotificationDTO();

            notificationDTO.Id = notification.Id;
            notificationDTO.CreationDate = notification.CreationDate;
            notificationDTO.ExpiryDate = notification.ExpiryDate;
            notificationDTO.Important = notification.Important;
            notificationDTO.Message = notification.Message;
            notificationDTO.NotificationDate = notification.NotificationDate;
            notificationDTO.Title = notification.Title;
            notificationDTO.UserId = notification.UserId;

            return notificationDTO;
        }

        public static List<NotificationDTO> ToDTO(this List<Notification> notificationList)
        {
            var notificationDTOList = new List<NotificationDTO>();

            foreach (var notification in notificationList)
            {
                var notificationDTO = new NotificationDTO();

                notificationDTO.Id = notification.Id;
                notificationDTO.CreationDate = notification.CreationDate;
                notificationDTO.ExpiryDate = notification.ExpiryDate;
                notificationDTO.Important = notification.Important;
                notificationDTO.Message = notification.Message;
                notificationDTO.NotificationDate = notification.NotificationDate;
                notificationDTO.Title = notification.Title;
                notificationDTO.UserId = notification.UserId;

                notificationDTOList.Add(notificationDTO);
            }

            return notificationDTOList;
        }
    }
}
