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
    public class UserTypeServices : AbstractUserTypeServices
    {
        private AbstractUserTypeDao abstractUserTypeDao;

        public UserTypeServices(AbstractUserTypeDao abstractUserTypeDao)
        {
            this.abstractUserTypeDao = abstractUserTypeDao;
        }

        public override PagedList<AbstractUserType> UserType_All(PageParam pageParam, string search , AbstractUserType abstractUserType)
        {
            return this.abstractUserTypeDao.UserType_All(pageParam, search, abstractUserType);
        }
       
       
    }

}