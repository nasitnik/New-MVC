using DataTables.Mvc;
using TaxiApp.Common;
using TaxiApp.Common.Paging;
using TaxiApp.Entities.Contract;
using TaxiApp.Entities.V1;
using TaxiApp.Services.Contract;
using TaxiAppAdmin.Infrastructure;
using TaxiAppAdmin.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiAppAdmin.Controllers
{
    public class ChangePasswordController : BaseController
    {
        #region Fields
        private readonly AbstractAdminUsersServices abstractAdminUsersServices;
        #endregion

        #region Ctor
        public ChangePasswordController(AbstractAdminUsersServices abstractAdminUsersServices)
        {
            this.abstractAdminUsersServices = abstractAdminUsersServices;
        }
        #endregion

        #region Methods
        [HttpGet]
        [ActionName(Actions.ChangePassword)]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ActionName(Actions.ChangePassword)]
        public ActionResult ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            AbstractAdminUsers abstractAdminUsers = new AdminUsers();
            abstractAdminUsers.OldPassword = oldPassword;
            abstractAdminUsers.NewPassword = newPassword;
            abstractAdminUsers.ConfirmPassword = confirmPassword;
            abstractAdminUsers.Type = 1;
            abstractAdminUsers.Id = ProjectSession.AdminId;
            SuccessResult<AbstractAdminUsers> result1 = abstractAdminUsersServices.AdminUsers_ChangePassword(abstractAdminUsers);
            return Json(result1, JsonRequestBehavior.AllowGet);

        }

        #endregion
    }
}