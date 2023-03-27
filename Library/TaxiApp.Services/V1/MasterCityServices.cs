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
    public class MasterCityServices : AbstractMasterCityServices
    {
        private AbstractMasterCityDao abstractMasterCityDao;

        public MasterCityServices(AbstractMasterCityDao abstractMasterCityDao)
        {
            this.abstractMasterCityDao = abstractMasterCityDao;
        }

        public override PagedList<AbstractMasterCity> MasterCity_All(PageParam pageParam, string search )
        {
            return this.abstractMasterCityDao.MasterCity_All(pageParam, search);
        }
       
      
    }

}