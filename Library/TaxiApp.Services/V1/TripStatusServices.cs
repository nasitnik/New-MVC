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
    public class TripStatusServices : AbstractTripStatusServices
    {
        private AbstractTripStatusDao abstractTripStatusDao;

        public TripStatusServices(AbstractTripStatusDao abstractTripStatusDao)
        {
            this.abstractTripStatusDao = abstractTripStatusDao;
        }

        public override PagedList<AbstractTripStatus> TripStatus_All(PageParam pageParam, string search , AbstractTripStatus abstractTripStatus)
        {
            return this.abstractTripStatusDao.TripStatus_All(pageParam, search, abstractTripStatus);
        }
       
       
    }

}