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
    public abstract class AbstractMasterHourDao : AbstractBaseDao
    {
        public abstract PagedList<AbstractMasterHour> MasterHour_All(PageParam pageParam , AbstractMasterHour abstractMasterHour);
      
    }
}
