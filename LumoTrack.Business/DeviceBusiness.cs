using LumoTrack.Business.Mappers;
using LumoTrack.DTO;
using LumoTrack.Model;
using LumoTrack.Repository;
using LumoTrack.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace LumoTrack.Business
{
    public class DeviceBusiness
    {
        private LumoTrackContext _lumoTrackContext;

        private readonly DevicesRepository _devicesRepository;

        public List<DeviceDTO> GetDevicesToNotify(DateTime utcnow)
        {
            List<DeviceDTO> devicesToNotify = new List<DeviceDTO>();

            var devicesModel = _devicesRepository.GetList();

            foreach (var item in devicesModel)
            {
                TimeZoneInfo timezone = TimeZoneInfo.FindSystemTimeZoneById(item.TimeZone);

                DateTime serverTimeZonetime = TimeZoneInfo.ConvertTimeFromUtc(utcnow, timezone);

                DateTime deviceTimeZonetime = TimeZoneInfo.ConvertTimeFromUtc(item.LastNotification, timezone);

                var hours = (serverTimeZonetime - deviceTimeZonetime).TotalHours;

                if (hours >= 24)
                    devicesToNotify.Add(item.ToDTO());
            }


            return devicesToNotify;
        }

        public DeviceBusiness()
        {
            _lumoTrackContext = new LumoTrackContext();
            _devicesRepository = new DevicesRepository(_lumoTrackContext);
        }

        public DeviceDTO Register(DeviceDTO deviceDTO)
        {
            DateTime time = SetNotificationTime(deviceDTO.TimeZone);

            deviceDTO.LastNotification = time;

            deviceDTO.TimeZone = ConfigurationManager.AppSettings["timezone"];

            var deviceModel = deviceDTO.ToModel();

            var response = _devicesRepository.Create(deviceModel);

            return response.ToDTO();
        }

        public void UpdateNotifiedDevices(List<DeviceDTO> devicesResponse, DateTime utcnow)
        {
            TimeSpan timeSpan = new TimeSpan(7, 00, 00);

            foreach (var item in devicesResponse)
            {
                TimeZoneInfo timezone = TimeZoneInfo.FindSystemTimeZoneById(item.TimeZone);

                DateTime local = TimeZoneInfo.ConvertTimeFromUtc(utcnow, timezone);

                local = local.Date + timeSpan;

                DateTime utcNotification = TimeZoneInfo.ConvertTimeToUtc(local);

                item.LastNotification = utcNotification;

                _devicesRepository.Update(item.ToModel());
            }
        }

        public DeviceDTO GetUser(string userId)
        {
            var response = _devicesRepository.Read(userId);

            if (response == null)
                return null;
            return response.ToDTO();
        }

        public string GetFireBaseToken(string userId)
        {
            var response = _devicesRepository.Read(userId);

            if (response == null)
                return "";
            return response.FireBaseToken;
        }

        public DeviceDTO Upsert(DeviceDTO deviceDTO)
        {
            var devices = _devicesRepository.Read(deviceDTO.DeviceId);

            DeviceDTO response;

            if (devices == null)
            {
                response = Register(deviceDTO);
            }
            else
            {

                deviceDTO.LastNotification = devices.LastNotification;

                deviceDTO.TimeZone = ConfigurationManager.AppSettings["timezone"];

                var deviceModel = deviceDTO.ToModel();

                response = _devicesRepository.Update(deviceModel).ToDTO();
            }

            return response;
        }

        private DateTime SetNotificationTime(string timeZone)
        {
            TimeZoneInfo timezone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);

            DateTime utc = DateTime.UtcNow;

            DateTime local = TimeZoneInfo.ConvertTimeFromUtc(utc, timezone);

            TimeSpan timeSpan = new TimeSpan(7, 00, 00);

            local = local.AddDays(-1);

            local = local.Date + timeSpan;

            DateTime utcNotification = TimeZoneInfo.ConvertTimeToUtc(local);

            return utcNotification;
        }

        public DeviceDTO Update(DeviceDTO deviceDTO)
        {
            var devices = _devicesRepository.Read(deviceDTO.DeviceId);

            var deviceModel = deviceDTO.ToModel();

            deviceModel.LastNotification = devices.LastNotification;

            var response = _devicesRepository.Update(deviceModel);

            return response.ToDTO();
        }


    }
}
