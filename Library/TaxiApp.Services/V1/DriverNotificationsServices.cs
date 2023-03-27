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
    public class DriverNotificationsServices : AbstractDriverNotificationsServices
    {
        private AbstractDriverNotificationsDao abstractDriverNotificationsDao;

        public DriverNotificationsServices(AbstractDriverNotificationsDao abstractDriverNotificationsDao)
        {
            this.abstractDriverNotificationsDao = abstractDriverNotificationsDao;
        }

       
        public override PagedList<AbstractDriverNotifications> DriverNotifications_All(PageParam pageParam, string search)
        {
            return this.abstractDriverNotificationsDao.DriverNotifications_All(pageParam, search);
        }

        public override SuccessResult<AbstractDriverNotifications> DriverNotifications_ById(int Id)
        {
            return this.abstractDriverNotificationsDao.DriverNotifications_ById(Id);
        }

        public override SuccessResult<AbstractDriverNotifications> DriverNotifications_Upsert(AbstractDriverNotifications abstractDriverNotifications)
        {
            return this.abstractDriverNotificationsDao.DriverNotifications_Upsert(abstractDriverNotifications);
        }
       
       
        
        public override SuccessResult<AbstractDriverNotifications> DriverNotifications_ReadUnRead(int Id)
        {
            return this.abstractDriverNotificationsDao.DriverNotifications_ReadUnRead(Id);
        }


    }

}