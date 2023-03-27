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
    public abstract class AbstractDriverNotificationsServices
    {
        public abstract PagedList<AbstractDriverNotifications> DriverNotifications_All(PageParam pageParam, string search);
        public abstract SuccessResult<AbstractDriverNotifications> DriverNotifications_ById(int Id);
        public abstract SuccessResult<AbstractDriverNotifications> DriverNotifications_ReadUnRead(int Id);
        public abstract SuccessResult<AbstractDriverNotifications> DriverNotifications_Upsert(AbstractDriverNotifications abstractDriverNotifications);
    }
}
