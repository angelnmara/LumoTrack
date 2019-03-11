using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LumoTrack.Business;
using LumoTrack.Business.Manager;
using LumoTrack.DTO;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using LumoTrack.BackOffice.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LumoTrack.BackOffice.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UserController : Controller
    {
        private UserManager _userManager;
        private SignInManager _signInManager;

        public UserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
            private set { _userManager = value; }
        }
        public SignInManager SignInManager
        {
            get
            {
                var owinContext = HttpContext.GetOwinContext();
                var manager = owinContext.Get<SignInManager>();
                _signInManager = manager;
                return _signInManager;
            }
            private set { _signInManager = value; }
        }


        public async Task<ActionResult> Index()
        {
            try
            {
                var authenticationBusiness = new AuthenticationBusiness();

                var response = await authenticationBusiness.GetList();

                response = response.OrderBy(x => x.Roles).ThenBy(x => x.Email).ToList();

                return View(response);
            }
            catch (Exception e)
            {
                return View("Error", "Error");
            }


        }


        [AllowAnonymous]
        public ActionResult Create()
        {
            var roleBusiness = new RoleBusiness();
            var role = roleBusiness.GetList();

            ViewBag.Roles = role.Select(x => x.Name).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Create(UserDTO userDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var authenticationBusiness = new AuthenticationBusiness();

                    var user = new UserDTO()
                    {
                        Id = Guid.NewGuid().ToString(),
                        FirstName = userDTO.FirstName,
                        PhoneNumber = userDTO.PhoneNumber,
                        UserName = userDTO.Email,
                        Email = userDTO.Email,
                        Password = userDTO.Password,
                        SecondName = userDTO.SecondName,
                        LastName = userDTO.LastName,
                        MotherLastName = userDTO.MotherLastName
                    };

                    var result = await authenticationBusiness.CreateAsync(UserManager, user);

                    if (result.Succeeded)
                    {
                        result = authenticationBusiness.AddToRole(UserManager, user.Id, userDTO.Roles);

                        if (result.Succeeded)
                        {
                            //await authenticationBusiness.AddClaimAsync(UserManager, user, new Claim("UserName", user.Email));

                            return RedirectToAction("Index");
                        }
                        //AddErrors(result);
                    }
                    else
                    {
                        var isEmailCorrect = IsValidEmail(user.Email);
                        if (!isEmailCorrect)
                        {
                            ModelState.AddModelError("Email", "-Verifique el formato del correo.");
                        }
                        else
                        {
                            var response = await authenticationBusiness.GetList();

                            var emailExist = response.Any(x => x.Email == userDTO.Email);

                            if (emailExist)
                            {
                                ModelState.AddModelError("Email", "-El correo que intenta ingresar, ya esta registrado.");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Contraseña ingresada es incorrecta");
                            }

                        }

                    }

                }
                var roleBusiness = new RoleBusiness();
                var role = roleBusiness.GetList();
                ViewBag.Roles = role.Select(x => x.Name).ToList();
                return View(userDTO);
            }
            catch (Exception e)
            {

                throw;
            }


        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public ActionResult Edit(string id)
        {
            var authenticationBusiness = new AuthenticationBusiness();

            var roleBusiness = new RoleBusiness();

            var userDTO = authenticationBusiness.FindById(UserManager, id);

            var role = roleBusiness.GetList();

            ViewBag.Roles = role.Select(x => x.Name).ToList();

            UserEditDTO user = new UserEditDTO();

            user.PhoneNumber = userDTO.PhoneNumber;
            user.FirstName = userDTO.FirstName;
            user.SecondName = userDTO.SecondName;
            user.LastName = userDTO.LastName;
            user.MotherLastName = userDTO.MotherLastName;
            user.Email = userDTO.Email;
            user.UserName = userDTO.Email;
            user.Roles = userDTO.Roles;

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Edit(UserEditDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var authenticationBusiness = new AuthenticationBusiness();

                var result = await authenticationBusiness.UpdateUser(UserManager, userDTO.Id, userDTO);



                if (result.Succeeded)
                {
                    //await authenticationBusiness.AddClaimAsync(UserManager, user, new Claim("UserName", user.Email));
                    result = authenticationBusiness.RemoveFromRole(UserManager, userDTO.Id, userDTO.Roles);

                    result = authenticationBusiness.AddToRole(UserManager, userDTO.Id, userDTO.Roles);

                    return RedirectToAction("Index");
                }
                else
                {
                    var response = await authenticationBusiness.GetList();

                    var emailExist = response.Any(x => x.Email == userDTO.Email);

                    if (emailExist)
                    {
                        ModelState.AddModelError("", "El correo que intenta ingresar, ya esta registrado");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Contraseña ingresada es incorrecta");

                    }
                }
                //AddErrors(result);
            }

            var roleBusiness = new RoleBusiness();

            var role = roleBusiness.GetList();

            ViewBag.Roles = role.Select(x => x.Name).ToList();

            return View(userDTO);
        }

        public ActionResult ChangePassword(string id)
        {
            var authenticationBusiness = new AuthenticationBusiness();

            var roleBusiness = new RoleBusiness();

            var userDTO = authenticationBusiness.FindById(UserManager, id);

            var role = roleBusiness.GetList();

            ViewBag.Roles = role.Select(x => x.Name).ToList();

            ChangePasswordDTO changePassword = new ChangePasswordDTO();

            changePassword.Email = userDTO.Email;
            changePassword.UserID = userDTO.Id;

            return View(changePassword);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> ChangePassword(ChangePasswordDTO changePassword)
        {
            if (ModelState.IsValid)
            {
                var authenticationBusiness = new AuthenticationBusiness();

                var result = await authenticationBusiness.ChangePasswordAsync(UserManager, changePassword.UserID, changePassword.Password);

                if (result.Succeeded)
                {
                    //await authenticationBusiness.AddClaimAsync(UserManager, user, new Claim("UserName", user.Email));

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Contraseña ingresada es incorrecta");
                }
                //AddErrors(result);
            }

            return View(changePassword);
        }


        public ActionResult Delete(string id)
        {
            var authenticationBusiness = new AuthenticationBusiness();

            var userDTO = authenticationBusiness.FindById(UserManager, id);

            return View(userDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Delete(UserDTO userDTO)
        {
            var authenticationBusiness = new AuthenticationBusiness();

            var result = await authenticationBusiness.DeleteUser(UserManager, userDTO.Id);

            if (result.Succeeded)
            {
                //await authenticationBusiness.AddClaimAsync(UserManager, user, new Claim("UserName", user.Email));

                return RedirectToAction("Index");
            }
            //AddErrors(result);

            return View(userDTO);
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (Request.IsAuthenticated)
                return RedirectToAction("Index", "Notification");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var loginDto = new LoginDTO()
            {
                Username = model.Email,
                Password = model.Password,
                RememberMe = model.RememberMe
            };

            var authBusiness = new AuthenticationBusiness();
            var result = await authBusiness.LoginAsync(SignInManager, loginDto);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Notification");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Usuario o Contraseña incorrecto");
                    return View(model);
            }
        }

    }
}