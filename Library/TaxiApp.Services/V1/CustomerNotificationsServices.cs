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
    public class CustomerNotificationsServices : AbstractCustomerNotificationsServices
    {
        private AbstractCustomerNotificationsDao abstractCustomerNotificationsDao;

        public CustomerNotificationsServices(AbstractCustomerNotificationsDao abstractCustomerNotificationsDao)
        {
            this.abstractCustomerNotificationsDao = abstractCustomerNotificationsDao;
        }

        public override PagedList<AbstractCustomerNotifications> CustomerNotifications_All(PageParam pageParam, string search, AbstractCustomerNotifications abstractCustomerNotifications)
        {
            return this.abstractCustomerNotificationsDao.CustomerNotifications_All(pageParam, search, abstractCustomerNotifications);
        }

        public override SuccessResult<AbstractCustomerNotifications> CustomerNotifications_ById(int Id)
        {
            return this.abstractCustomerNotificationsDao.CustomerNotifications_ById(Id);
        }
        public override bool CustomerNotifications_Delete(int CustomerId)
        {
            return this.abstractCustomerNotificationsDao.CustomerNotifications_Delete(CustomerId);
        }

        public override SuccessResult<AbstractCustomerNotifications> CustomerNotifications_Upsert(AbstractCustomerNotifications abstractCustomerNotifications)
        {
            return this.abstractCustomerNotificationsDao.CustomerNotifications_Upsert(abstractCustomerNotifications);
        }
        public override SuccessResult<AbstractCustomerNotifications> CustomerNotifications_ReadUnRead(int Id)
        {
            return this.abstractCustomerNotificationsDao.CustomerNotifications_ReadUnRead(Id);
        }
    }

}