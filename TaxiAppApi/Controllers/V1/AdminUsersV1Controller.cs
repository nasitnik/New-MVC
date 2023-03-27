using TaxiApp.APICommon;
using TaxiAppApi.Models;
using TaxiApp.Common;
using TaxiAppApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TaxiApp.Common.Paging;
using TaxiApp.Entities.Contract;
using TaxiApp.Services.Contract;
using TaxiApp.Entities.V1;
using System.IO;
using System.Security.Claims;
using System.Web.Http.Cors;

namespace TaxiAppApi.Controllers.V1
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdminUsersV1Controller : AbstractBaseController
    {
        #region Fields
        private readonly AbstractAdminUsersServices AbstractAdminUsersServices;
        #endregion

        #region Cnstr
        public AdminUsersV1Controller(AbstractAdminUsersServices abstractAdminUsersServices)
        {
            this.AbstractAdminUsersServices = abstractAdminUsersServices;
        }
        #endregion
        //AdminUsers_ById Api
        [System.Web.Http.HttpPost]
        [InheritedRoute("AdminUsers_ById")]
        public async Task<IHttpActionResult> AdminUsers_ById(int Id)
        {
            var quote = AbstractAdminUsersServices.AdminUsers_ById(Id);
            return this.Content((HttpStatusCode)quote.Code, quote);
        }
        //AdminUsers_ActInAct Api
        [System.Web.Http.HttpPost]
        [InheritedRoute("AdminUsers_ActInAct")]
        public async Task<IHttpActionResult> AdminUsers_ActInAct(int Id)
        {
            var quote = AbstractAdminUsersServices.AdminUsers_ActInAct(Id);
            return this.Content((HttpStatusCode)quote.Code, quote);
        }
        //AdminUsers_ActInAct Api
        [System.Web.Http.HttpPost]
        [InheritedRoute("AdminUsers_Delete")]
        public async Task<IHttpActionResult> AdminUsers_Delete(int Id,int DeletedBy)
        {
            var quote = AbstractAdminUsersServices.AdminUsers_Delete(Id,DeletedBy);
            return this.Content((HttpStatusCode)quote.Code, quote);
        }
        // AdminUsers_Login API
        [System.Web.Http.HttpPost]
        [InheritedRoute("Users_Login")]
        public async Task<IHttpActionResult> Users_Login(string Email, string Password)
        {
            var quote = AbstractAdminUsersServices.AdminUsers_Login( Email,Password);
            return this.Content((HttpStatusCode)quote.Code, quote);
        }
        //AdminUsers_ChangePassword API
        [System.Web.Http.HttpPost]
        [InheritedRoute("AdminUsers_ChangePassword")]
        public async Task<IHttpActionResult> AdminUsers_ChangePassword(AdminUsers adminUsers)
        {
            var quote = AbstractAdminUsersServices.AdminUsers_ChangePassword(adminUsers);
            return this.Content((HttpStatusCode)quote.Code, quote);
        }
        //AdminUsers_Upsert Api
        [System.Web.Http.HttpPost]
        [InheritedRoute("AdminUsers_Upsert")]
        public async Task<IHttpActionResult> AdminUsers_Upsert()
        {
            var claimsIdentity = (ClaimsIdentity)this.RequestContext.Principal.Identity;

            AdminUsers AdminUsers = new AdminUsers();
            var httpRequest = HttpContext.Current.Request;
            AdminUsers.Id = Convert.ToInt32(httpRequest.Params["Id"]);
            AdminUsers.UserTypeId = Convert.ToInt32(httpRequest.Params["UserTypeId "]);
            AdminUsers.FirstName = Convert.ToString(httpRequest.Params["FirstName"]);
            AdminUsers.LastName = Convert.ToString(httpRequest.Params["LastName"]);
            AdminUsers.MobileNo = Convert.ToString(httpRequest.Params["MobileNo"]);
            AdminUsers.IsResetPassword = Convert.ToBoolean(httpRequest.Params["IsResetPassword"]);
            AdminUsers.Email = Convert.ToString(httpRequest.Params["Email"]);
            AdminUsers.Password = Convert.ToString(httpRequest.Params["Password"]);
            AdminUsers.OldPassword = Convert.ToString(httpRequest.Params["OldPassword"]);            
            AdminUsers.NewPassword = Convert.ToString(httpRequest.Params["NewPassword"]);
            AdminUsers.ConfirmPassword = Convert.ToString(httpRequest.Params["ConfirmPassword"]);
            AdminUsers.ProfilePicture = Convert.ToString(httpRequest.Params["ProfilePicture"]);
            AdminUsers.CreatedBy = Convert.ToInt32(httpRequest.Params["CreatedBy"]);
            AdminUsers.UpdatedBy = Convert.ToInt32(httpRequest.Params["UpdatedBy"]);
            var quote = AbstractAdminUsersServices.AdminUsers_Upsert(AdminUsers);
            return this.Content((HttpStatusCode)quote.Code, quote);
        }
        
        [System.Web.Http.HttpPost]
        [InheritedRoute("AdminUsers_Logout")]
        public async Task<IHttpActionResult> AdminUsers_Logout(int Id)
        {
            var quote = AbstractAdminUsersServices.AdminUsers_Logout(Id);
            return this.Content((HttpStatusCode)200, quote);
        }
        //AdminUsers_All Api

        //Users_All Api
        [System.Web.Http.HttpPost]
        [InheritedRoute("AdminUsers_All")]
        public async Task<IHttpActionResult> AdminUsers_All(PageParam pageParam, string search)
        {
            AbstractAdminUsers AdminUsers = new AdminUsers();
            var quote = AbstractAdminUsersServices.AdminUsers_All(pageParam, search, AdminUsers);
            return this.Content((HttpStatusCode)200, quote);
        }
    }
}
