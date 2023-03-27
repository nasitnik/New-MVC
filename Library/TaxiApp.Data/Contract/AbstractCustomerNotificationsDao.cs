using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Common;
using TaxiApp.Common.Paging;
using TaxiApp.Entities.Contract;

namespace TaxiApp.Data.Contract
{
    public abstract class AbstractCustomerNotificationsDao : AbstractBaseDao
    {
        public abstract PagedList<AbstractCustomerNotifications> CustomerNotifications_All(PageParam pageParam, string search, AbstractCustomerNotifications abstractCustomerNotifications);
        public abstract SuccessResult<AbstractCustomerNotifications> CustomerNotifications_ById(int Id);
        public abstract SuccessResult<AbstractCustomerNotifications> CustomerNotifications_Upsert(AbstractCustomerNotifications abstractCustomerNotifications);
        public abstract SuccessResult<AbstractCustomerNotifications> CustomerNotifications_ReadUnRead(int Id);
        public abstract bool CustomerNotifications_Delete(int CustomerId);

    }
}
