using LumoTrack.DTO;
using LumoTrack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LumoTrack.Business.Mappers
{
    internal static class UserMapper
    {
        public static UserDTO ToDTO(this User user)
        {
            var userDto = new UserDTO()
            {
                LockoutEndDateUtc = user.LockoutEndDateUtc,
                PhoneNumber = user.PhoneNumber,
                Id = user.Id,
                FirstName = user.FirstName,
                Email = user.Email,
                UserName = user.UserName,
                SecondName=user.SecondName,
                LastName=user.LastName,
                MotherLastName=user.MotherLastName,
                
            };
            return userDto;
        }
        public static User ToModel(this UserDTO user)
        {
            var userModel = new User()
            {
                LockoutEndDateUtc = user.LockoutEndDateUtc,
                Id = user.Id,
                FirstName = user.FirstName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                MotherLastName = user.MotherLastName
            };
            return userModel;
        }

        public static List<UserDTO> ToDTO(this List<User> userList)
        {
            var userDTOList = new List<UserDTO>();

            foreach (var user in userList)
            {
                var userDto = new UserDTO()
                {
                    LockoutEndDateUtc = user.LockoutEndDateUtc,
                    PhoneNumber = user.PhoneNumber,
                    Id = user.Id,
                    FirstName = user.FirstName,
                    SecondName=user.SecondName,
                    LastName=user.LastName,
                    MotherLastName=user.MotherLastName,
                    Email = user.Email,
                    UserName = user.UserName,
                };

                userDTOList.Add(userDto);
            }

            return userDTOList;
        }
    }
}
