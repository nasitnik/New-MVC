using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Common;
using TaxiApp.Common.Paging;
using TaxiApp.Entities.Contract;

namespace TaxiApp.Services.Contract
{
    public abstract class AbstractAdminUsersServices
    {
        public abstract PagedList<AbstractAdminUsers> AdminUsers_All(PageParam pageParam, string search, AbstractAdminUsers abstractAdminUsers);
        public abstract SuccessResult<AbstractAdminUsers> AdminUsers_ById(int Id);
        public abstract SuccessResult<AbstractAdminUsers> AdminUsers_ActInAct(int Id);
        public abstract SuccessResult<AbstractAdminUsers> AdminUsers_Delete(int Id, int DeletedBy);
        public abstract SuccessResult<AbstractAdminUsers> AdminUsers_Login(string Email, string Password);
        public abstract SuccessResult<AbstractAdminUsers> AdminUsers_ChangePassword(AbstractAdminUsers abstractAdminUsers);
        public abstract SuccessResult<AbstractAdminUsers> AdminUsers_Upsert(AbstractAdminUsers abstractAdminUsers);
        public abstract bool AdminUsers_Logout(int Id);

    }
}
