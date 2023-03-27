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
    public class TripStatusLoggerServices : AbstractTripStatusLoggerServices
    {
        private AbstractTripStatusLoggerDao abstractTripStatusLoggerDao;

        public TripStatusLoggerServices(AbstractTripStatusLoggerDao abstractTripStatusLoggerDao)
        {
            this.abstractTripStatusLoggerDao = abstractTripStatusLoggerDao;
        }

        

        public override SuccessResult<AbstractTripStatusLogger> Trip_UpsertStatus(AbstractTripStatusLogger abstractTripStatusLogger)
        {
            return this.abstractTripStatusLoggerDao.Trip_UpsertStatus(abstractTripStatusLogger);
        }
      
    }

}