using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Common;
using TaxiApp.Common.Paging;
using TaxiApp.Data.Contract;
using TaxiApp.Entities.Contract;
using TaxiApp.Services.Contract;

namespace TaxiApp.Services.V1
{
    public class AdminUsersServices : AbstractAdminUsersServices
    {
        private AbstractAdminUsersDao abstractAdminUsersDao;

        public AdminUsersServices(AbstractAdminUsersDao abstractAdminUsersDao)
        {
            this.abstractAdminUsersDao = abstractAdminUsersDao;
        }

        public override PagedList<AbstractAdminUsers> AdminUsers_All(PageParam pageParam, string search , AbstractAdminUsers abstractAdminUsers)
        {
            return this.abstractAdminUsersDao.AdminUsers_All(pageParam, search, abstractAdminUsers);
        }
       
        public override SuccessResult<AbstractAdminUsers> AdminUsers_ById(int Id)
        {
            return this.abstractAdminUsersDao.AdminUsers_ById(Id);
        }

        public override SuccessResult<AbstractAdminUsers> AdminUsers_ActInAct(int Id)
        {
            return this.abstractAdminUsersDao.AdminUsers_ActInAct(Id);
        }

        public override SuccessResult<AbstractAdminUsers> AdminUsers_Upsert(AbstractAdminUsers abstractAdminUsers)
        {
            return this.abstractAdminUsersDao.AdminUsers_Upsert(abstractAdminUsers); 
        }
        public override SuccessResult<AbstractAdminUsers> AdminUsers_Login(string Email, string Password)
        {
            return this.abstractAdminUsersDao.AdminUsers_Login(Email,Password);
        }
        public override SuccessResult<AbstractAdminUsers> AdminUsers_ChangePassword(AbstractAdminUsers abstractAdminUsers)
        {
            return this.abstractAdminUsersDao.AdminUsers_ChangePassword(abstractAdminUsers);
        }
        public override SuccessResult<AbstractAdminUsers> AdminUsers_Delete(int Id, int DeletedBy)
        {
            return this.abstractAdminUsersDao.AdminUsers_Delete(Id, DeletedBy);
        }
        public override bool AdminUsers_Logout(int Id)
        {
            return this.abstractAdminUsersDao.AdminUsers_Logout(Id);
        }
    }

}