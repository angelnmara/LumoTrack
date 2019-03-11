using LumoTrack.DTO;
using LumoTrack.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LumoTrack.Business.Mappers
{
    public static class DevicesMapper
    {
        public static Devices ToModel(this DeviceDTO deviceDTO)
        {
            var devices = new Devices();

            if (deviceDTO.DeviceId != "")
                devices.Id = new Guid(deviceDTO.DeviceId);
            else
                devices.Id = Guid.NewGuid();

            devices.FireBaseToken = deviceDTO.FireBaseToken;
            devices.LastNotification = deviceDTO.LastNotification;
            devices.Latitude = deviceDTO.Latitude;
            devices.Longitude = deviceDTO.Longitude;
            devices.TimeZone = deviceDTO.TimeZone;
            devices.DeviceType = deviceDTO.devicesType;

            return devices;
        }

        public static DeviceDTO ToDTO(this Devices devices)
        {
            var deviceDTO = new DeviceDTO();

            deviceDTO.DeviceId = devices.Id.ToString();
            deviceDTO.FireBaseToken = devices.FireBaseToken;
            deviceDTO.LastNotification = devices.LastNotification;
            deviceDTO.Latitude = devices.Latitude;
            deviceDTO.Longitude = devices.Longitude;
            deviceDTO.TimeZone = devices.TimeZone;
            deviceDTO.devicesType = devices.DeviceType;

            return deviceDTO;
        }

        public static List<DeviceDTO> ToDTO(this List<Devices> devicesList)
        {
            var deviceDTOList = new List<DeviceDTO>();

            foreach (var devices in devicesList)
            {
                var deviceDTO = new DeviceDTO();

                deviceDTO.DeviceId = devices.Id.ToString();
                deviceDTO.FireBaseToken = devices.FireBaseToken;
                deviceDTO.LastNotification = devices.LastNotification;
                deviceDTO.Latitude = devices.Latitude;
                deviceDTO.Longitude = devices.Longitude;
                deviceDTO.devicesType = devices.DeviceType;

                deviceDTOList.Add(deviceDTO);
            }

            return deviceDTOList;
        }

        public static List<Devices> ToModel(this List<DeviceDTO> deviceDTOList)
        {
            var deviceList = new List<Devices>();

            foreach (var deviceDTO in deviceDTOList)
            {
                var devices = new Devices();

                devices.Id = new Guid(deviceDTO.DeviceId);
                devices.FireBaseToken = deviceDTO.FireBaseToken;
                devices.LastNotification = deviceDTO.LastNotification;
                devices.Latitude = deviceDTO.Latitude;
                devices.Longitude = deviceDTO.Longitude;
                devices.DeviceType = deviceDTO.devicesType;

                deviceList.Add(devices);
            }

            return deviceList;
        }
    }
}
