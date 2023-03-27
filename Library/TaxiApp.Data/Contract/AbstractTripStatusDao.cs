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
    public abstract class AbstractTripStatusDao : AbstractBaseDao
    {
        public abstract PagedList<AbstractTripStatus> TripStatus_All(PageParam pageParam, string search, AbstractTripStatus abstractTripStatus);
    }
}
