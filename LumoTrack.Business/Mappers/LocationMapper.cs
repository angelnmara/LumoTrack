using Kuktrack.Integrations.DTO;
using LumoTrack.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LumoTrack.Business.Mappers
{
    public static class LocationMapper
    {
        public static List<LumoLocationDTO> LocationIntegrationsToDTO(this List<LocationDto> locationIntegrationDtos)
        {
            List<LumoLocationDTO> locationDTOList = new List<LumoLocationDTO>();

            foreach (var locationIntegrations in locationIntegrationDtos)
            {
                LumoLocationDTO locationDTO = new LumoLocationDTO();

                locationDTO.Id = locationIntegrations.Id;
                locationDTO.Latitude = locationIntegrations.Latitude;
                locationDTO.Longitude = locationIntegrations.Longitude;

                locationDTOList.Add(locationDTO);
            }
            return locationDTOList;
        }
    }
}
