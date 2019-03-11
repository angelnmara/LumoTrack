using LumoTrack.Common;
using LumoTrack.DTO;
using LumoTrack.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LumoTrack.Business.Mappers
{
    public static class InboxMapper
    {
        public static Inbox ToModel(this InboxDTO inboxDTO)
        {
            var inbox = new Inbox();

            inbox.Id = inboxDTO.Id;
            inbox.CreationDate = inboxDTO.CreationDate;
            inbox.Message = inboxDTO.Message;
            inbox.ReportType = (ReportTypesEnum)inboxDTO.ReportType;
            inbox.Response = inboxDTO.Response;
            inbox.ResponseDate = inboxDTO.ResponseDate;
            inbox.TruckId = inboxDTO.TruckId;
            inbox.TruckName = inboxDTO.TruckName;
            inbox.UserId = inboxDTO.UserId;
            inbox.UserResponseId = inboxDTO.UserResponseId;

            return inbox;
        }

        public static InboxDTO ToDTO(this Inbox inbox)
        {
            var inboxDTO = new InboxDTO();

            inboxDTO.Id = inbox.Id;
            inboxDTO.CreationDate = inbox.CreationDate;
            inboxDTO.Message = inbox.Message;
            inboxDTO.ReportType = inbox.ReportType;
            inboxDTO.Response = inbox.Response;
            inboxDTO.ResponseDate = inbox.ResponseDate;
            inboxDTO.TruckId = inbox.TruckId;
            inboxDTO.TruckName = inbox.TruckName;
            inboxDTO.UserId = inbox.UserId;
            inboxDTO.UserResponseId = inbox.UserResponseId;

            return inboxDTO;
        }

        public static List<InboxDTO> ToDTO(this List<Inbox> inboxList)
        {
            var inboxDTOList = new List<InboxDTO>();

            foreach (var inbox in inboxList)
            {
                var inboxDTO = new InboxDTO();

                inboxDTO.Id = inbox.Id;
                inboxDTO.CreationDate = inbox.CreationDate;
                inboxDTO.Message = inbox.Message;
                inboxDTO.ReportType =inbox.ReportType;
                inboxDTO.Response = inbox.Response;
                inboxDTO.ResponseDate = inbox.ResponseDate;
                inboxDTO.TruckId = inbox.TruckId;
                inboxDTO.TruckName = inbox.TruckName;
                inboxDTO.UserId = inbox.UserId;
                inboxDTO.UserResponseId = inbox.UserResponseId;

                inboxDTOList.Add(inboxDTO);
            }

            return inboxDTOList;
        }
    }
}
