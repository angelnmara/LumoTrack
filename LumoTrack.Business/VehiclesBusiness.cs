using Kuktrack.Integrations.DTO;
using Kuktrack.Integrations.Proxy;
using Kuktrack.Integrations.Proxy.Proxies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using zorbek.essentials.utilities.Entities;
using LumoTrack.Business.Helpers;
using System.Device.Location.GeoCoordinate;
using LumoTrack.DTO;
using LumoTrack.Business.Mappers;
using LumoTrack.Proxy;
using System.Linq;

namespace LumoTrack.Business
{
    public class VehiclesBusiness
    {
        private string BASEADRESS = "http://api.navixy.com/v2/";


        public async Task<List<TrackerVehicleDTO>> GetVehiclesInRange(string hash, double Latitude, double Longitude)
        {
            try
            {
                var vehicleProxy = new BasicProxiesFactory().GetVehicleProxy();

                ResponseEntity<IEnumerable<TrackerVehicleDTO>> vehicles = await vehicleProxy.GetVehicleTrackers(hash);

                //List<TrackerVehicleDTO> locationInRange = FilterByRange(Latitude, Longitude, vehicles.Data.ToList(), 5.0);

                return vehicles.Data.ToList();
            }
            catch ( Exception e)
            {
                throw e;
            }

        }

        private List<TrackerVehicleDTO> FilterByRange(double latitude, double longitude, List<TrackerVehicleDTO> list, double range)
        {
            var locationDtoInRange = new List<TrackerVehicleDTO>();

            GeoCoordinate geoCoordinatePointA = new GeoCoordinate(latitude, longitude);

            foreach (var location in list)
            {
                GeoCoordinate geoCoordinatePointB = new GeoCoordinate(location.latitude, location.longitude);

                var distanceDifference = (geoCoordinatePointA.GetDistanceTo(geoCoordinatePointB) / 1000);

                if (distanceDifference <= range)
                    locationDtoInRange.Add(location);

            }

            return locationDtoInRange;
        }

        public async Task<List<VehicleDTO>> GetVehicles(string hash)
        {
            var trackerProxy = new TrackersProxy(BASEADRESS);

            ResponseEntity<List<TrackerDto>> trackerList = await trackerProxy.Trackers(hash);


            var vehicleProxy = new BasicProxiesFactory().GetVehicleProxy();

            ResponseEntity<IEnumerable<TrackerVehicleDTO>> vehicles = await vehicleProxy.GetVehicleTrackers(hash);

            return vehicles.Data.ToList().ToVehicle();
        }

        private List<LocationDto> FilterByRange(double latitude, double longitude, List<LocationDto> locationDtos, double range)
        {
            var locationDtoInRange = new List<LocationDto>();

            GeoCoordinate geoCoordinatePointA = new GeoCoordinate(latitude, longitude);

            foreach (var location in locationDtos)
            {
                GeoCoordinate geoCoordinatePointB = new GeoCoordinate(location.Latitude, location.Longitude);

                var distanceDifference = (geoCoordinatePointA.GetDistanceTo(geoCoordinatePointB) / 1000);

                if (distanceDifference <= range)
                    locationDtoInRange.Add(location);

            }

            return locationDtoInRange;
        }

        public async Task<List<DeviceDTO>> DevicesToNotify(string hash, List<DeviceDTO> deviceDTO, double range)
        {
            var deviceListResponse = new List<DeviceDTO>();

            var trackerProxy = new TrackersProxy(BASEADRESS);

            ResponseEntity<List<TrackerDto>> trackerList = await trackerProxy.Trackers(hash);

            if (trackerList.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<LocationDto> locationDtos = await trackerProxy.TrackersLocation(hash, trackerList.Data);

                foreach (var device in deviceDTO)
                {
                    foreach (var location in locationDtos)
                    {
                        GeoCoordinate geoCoordinatePointA = new GeoCoordinate(device.Latitude, device.Longitude);

                        GeoCoordinate geoCoordinatePointB = new GeoCoordinate(location.Latitude, location.Longitude);

                        var distanceDifference = (geoCoordinatePointA.GetDistanceTo(geoCoordinatePointB) / 1000);

                        if (distanceDifference <= range)
                        {
                            deviceListResponse.Add(device);
                            break;
                        }
                    }
                }
            }
            else if(trackerList.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            return deviceListResponse;

        }
    }
}
