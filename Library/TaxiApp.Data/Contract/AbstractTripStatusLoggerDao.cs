
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
    public abstract class AbstractTripStatusLoggerDao : AbstractBaseDao
    {
        public abstract SuccessResult<AbstractTripStatusLogger> Trip_UpsertStatus(AbstractTripStatusLogger abstractTripStatusLogger);
    }
}
