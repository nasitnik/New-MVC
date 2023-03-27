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
    public abstract class AbstractMasterHourServices
    {
        public abstract PagedList<AbstractMasterHour> MasterHour_All(PageParam pageParam, AbstractMasterHour abstractMasterHour);
       
        

    }
}
