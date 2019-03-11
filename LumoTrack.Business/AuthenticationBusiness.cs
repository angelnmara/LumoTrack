using Kuktrack.Integrations.Proxy;
using Kuktrack.Integrations.Proxy.Proxies;
using LumoTrack.Business.Manager;
using LumoTrack.Business.Mappers;
using LumoTrack.DTO;
using LumoTrack.Model;
using LumoTrack.Repository;
using LumoTrack.Repository.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using zorbek.essentials.utilities.Entities;

namespace LumoTrack.Business
{
    public class AuthenticationBusiness
    {
        public SignInStatus Login(SignInManager authenticationBusiness, LoginDTO login)
        {
            var result = authenticationBusiness.PasswordSignIn(login.Username, login.Password, login.RememberMe, false);
            return result;
        }

        public async Task<SignInStatus> LoginAsync(SignInManager signInManager, LoginDTO loginDto)
        {
            var result = await signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, true, false);

            return result;
        }

        public async Task<IdentityResult> CreateAsync(UserManager userManager, UserDTO user)
        {
            var responseUser = user.ToModel();
            var result = await userManager.CreateAsync(responseUser, user.Password);
            return result;
        }

        public async Task<UserDTO> ForgotPassword(UserManager userManager, string email)
        {
            var user = await userManager.FindByNameAsync(email);
            var responseUser = user.ToDTO();
            return responseUser;
        }

        public async Task<IdentityResult> ConfirmEmailAsync(UserManager userManager, string userId, string code)
        {
            var result = await userManager.ConfirmEmailAsync(userId, code);
            return result;
        }

        public async Task<bool> IsEmailConfirmedAsync(UserManager userManager, string id)
        {
            var result = await userManager.IsEmailConfirmedAsync(id);
            return result;
        }

        public async Task<UserDTO> FindByNameAsync(UserManager userManager, string email)
        {
            var result = await userManager.FindByNameAsync(email);
            var response = result.ToDTO();
            return response;
        }

        public async Task<IdentityResult> AddClaimAsync(UserManager userManager, UserDTO userDto, Claim claim)
        {
            var response = await userManager.AddClaimAsync(userDto.Id, claim);
            return response;
        }

        public IdentityResult AddToRole(UserManager userManager, string userId, string role)
        {
            var result = userManager.AddToRole(userId, role);

            return result;
        }

        public async Task<IdentityResult> ResetPasswordAsync(UserManager userManager, string id, string code,
            string password)
        {
            var result = await userManager.ResetPasswordAsync(id, code, password);
            return result;
        }

        public void DisposeUserManager(UserManager userManager)
        {
            userManager.Dispose();
        }

        public async Task<string> GetPhoneNumberAsync(UserManager userManager, string id)
        {
            var result = await userManager.GetPhoneNumberAsync(id);
            return result;
        }

        public async Task<bool> GetTwoFactorEnabledAsync(UserManager userManager, string id)
        {
            var result = await userManager.GetTwoFactorEnabledAsync(id);
            return result;
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(UserManager userManager, string id)
        {
            var result = await userManager.GetLoginsAsync(id);
            return result;
        }

        public async Task<IdentityResult> RemoveLoginAsync(UserManager userManager, string id,
            UserLoginInfo userLoginInfo)
        {
            var result = await userManager.RemoveLoginAsync(id, userLoginInfo);
            return result;
        }

        public async Task<UserDTO> FindByIdAsync(UserManager userManager, string id)
        {
            var result = await userManager.FindByIdAsync(id);
            var response = result.ToDTO();
            return response;
        }

        public IdentityResult RemoveFromRole(UserManager userManager, string userId, string oldRole)
        {

            var result = userManager.GetRoles(userId);

            var response = userManager.RemoveFromRole(userId, result.FirstOrDefault());

            return response;
        }

        public async Task<IdentityResult> ChangePasswordAsync(UserManager userManager, string id, string currentPassword, string newPassword)
        {
            var result = await userManager.ChangePasswordAsync(id, currentPassword, newPassword);
            return result;
        }

        public async Task<IdentityResult> ChangePasswordAsync(UserManager userManager, string userID, string password)
        {
            var resultUser = userManager.FindById(userID);

            string code = await userManager.GeneratePasswordResetTokenAsync(userID);

            var result = await userManager.ResetPasswordAsync(userID, code, password);

            return result;
        }

        public async Task<IdentityResult> AddPasswordAsync(UserManager userManager, string id, string password)
        {
            var result = await userManager.AddPasswordAsync(id, password);
            return result;
        }

        public async Task<IdentityResult> AddLoginAsync(UserManager userManager, string id, UserLoginInfo userLoginInfo)
        {
            var result = await userManager.AddLoginAsync(id, userLoginInfo);
            return result;
        }

        public UserDTO FindById(UserManager userManager, string id)
        {
            var resultUser = userManager.FindById(id);
            var responseUser = resultUser.ToDTO();

            responseUser.Roles = userManager.GetRoles(id).FirstOrDefault();

            return responseUser;
        }

        //SignInManager methods
        public void DisposeSignInManager(SignInManager signInManager)
        {
            signInManager.Dispose();
        }

        public Task SignInAsync(SignInManager singInManager, UserDTO user, bool isPersistent, bool rememberBrowser)
        {
            var responseUser = UserMapper.ToModel(user);
            var result = singInManager.SignInAsync(responseUser, false, false);
            return result;
        }

        public async Task<string> GenerateChangePhoneNumberTokenAsync(UserManager userManager, string id, string number)
        {
            var result = await userManager.GenerateChangePhoneNumberTokenAsync(id, number);
            return result;
        }
        public async Task<IdentityResult> AddCompany(UserManager userManager, string id, int? idcompany)
        {
            var user = userManager.FindById(id);
            var response = await userManager.UpdateAsync(user);

            return response;
        }



        public async Task<IdentityResult> UpdateUser(UserManager userManager, string id, UserEditDTO userDTO)
        {
            var user = userManager.FindById(id);

            user.PhoneNumber = userDTO.PhoneNumber;
            user.FirstName = userDTO.FirstName;
            user.SecondName = userDTO.SecondName;
            user.LastName = userDTO.LastName;
            user.MotherLastName = userDTO.MotherLastName;
            user.Email = userDTO.Email;
            user.UserName = userDTO.Email;
            
            var response = await userManager.UpdateAsync(user);

            return response;
        }

        public async Task<IdentityResult> DeleteUser(UserManager userManager, string id)
        {
            var user = userManager.FindById(id);

            var response = await userManager.DeleteAsync(user);

            return response;
        }

        public async Task<ICollection<UserDTO>> GetList()
        {
            var lumoTrackContext = new LumoTrackContext();

            var userRepository = new UserRepository(lumoTrackContext);

            var roleRepository = new RoleRepository(lumoTrackContext);

            var response = userRepository.GetList().ToList().ToDTO();

            List<UserDTO> responseList = new List<UserDTO>();

            foreach (var user in response)
            {
                user.Roles = roleRepository.GetRoleNameByUser(user.Id);

                responseList.Add(user);
            }

            return responseList;
        }

        private string BASEADRESS = "http://api.navixy.com/v2";

        public async Task<ResponseEntity<AuthenticationDto>> LoginKucktrack(string username, string password, HttpClient httpClient)
        {
            var authenticationProxy = new AuthenticationProxy(BASEADRESS, httpClient);

            var hash = await authenticationProxy.Login(username, password);

            return hash;
        }
    }
}
