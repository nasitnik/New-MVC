using TaxiAppAdmin.Pages;
using TaxiApp.Common;
using TaxiApp.Entities.Contract;
using TaxiApp.Entities.V1;
using TaxiApp.Services.Contract;
using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using TaxiAppAdmin.Controllers;


namespace TaxiAppAdmin.Controllers
{
    public class AccountController : Controller
    {
        #region Fields
        private readonly AbstractAdminUsersServices abstractAdminUsersServices;
        #endregion

        #region Ctor
        public AccountController(AbstractAdminUsersServices abstractAdminUsersServices)
        {
            this.abstractAdminUsersServices = abstractAdminUsersServices;
        }
        #endregion

        #region Methods

        public ActionResult Signin()
        {
            return View();
        }
        public ActionResult Logout()
        {
            int UserType = 0;
            UserType = ProjectSession.AdminId;

            if (Request.Cookies["UserLogin"] != null)
            {

                abstractAdminUsersServices.AdminUsers_Logout(ProjectSession.AdminId);

                string[] myCookies = Request.Cookies.AllKeys;
                foreach (string cookie in myCookies)
                {
                    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                }
            }
            Session.Clear();
            Session.Abandon();

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction(Actions.Signin, Pages.Controllers.Account);


        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LogIn(string UserName, string Password)
        {
            SuccessResult<AbstractAdminUsers> result = abstractAdminUsersServices.AdminUsers_Login(UserName, Password);
            if (result != null && result.Code == 200 && result.Item != null)
            {
                Session.Clear();
                ProjectSession.AdminId = result.Item.Id;
                ProjectSession.AdminName = result.Item.FirstName + ' ' + result.Item.LastName;

                HttpCookie cookie = new HttpCookie("UserLogin");
                cookie.Values.Add("Id", result.Item.Id.ToString());

                cookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cookie);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            AdminUsers adminUsers = new AdminUsers();
            adminUsers.Id = ProjectSession.AdminId;
            adminUsers.OldPassword = oldPassword;
            adminUsers.NewPassword = newPassword;
            adminUsers.ConfirmPassword = confirmPassword;
            SuccessResult<AbstractAdminUsers> result1 = abstractAdminUsersServices.AdminUsers_ChangePassword(adminUsers);
            return Json(result1, JsonRequestBehavior.AllowGet);

        }

        public JsonResult UnAuthorizedAccess()
        {
            return Json(new { Code = 401, Message = "Unauthorized Access" }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}