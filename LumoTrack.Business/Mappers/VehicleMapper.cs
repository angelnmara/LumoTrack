using Kuktrack.Integrations.Proxy;
using LumoTrack.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LumoTrack.Business.Mappers
{
    public static class VehicleMapper
    {
        public static VehicleDTO ToVehicle(this TrackerDto trackerDTO)
        {
            var vehicle = new VehicleDTO();

            vehicle.Id = trackerDTO.Id;
            vehicle.TruckName = trackerDTO.Label;

            return vehicle;
        }

        public static List<VehicleDTO> ToVehicle(this List<TrackerVehicleDTO> trackerDtoList)
        {
            var vehicleDtoList = new List<VehicleDTO>();

            foreach (var tracker in trackerDtoList)
            {
                var vehicle = new VehicleDTO();

                vehicle.Id = tracker.trackerId;
                vehicle.TruckName = tracker.label;

                vehicleDtoList.Add(vehicle);
            }
                       
            return vehicleDtoList;
        }
    }
}
