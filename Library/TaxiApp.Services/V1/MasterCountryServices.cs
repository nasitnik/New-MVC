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
    public class MasterCountryServices : AbstractMasterCountryServices
    {
        private AbstractMasterCountryDao abstractMasterCountryDao;

        public MasterCountryServices(AbstractMasterCountryDao abstractMasterCountryDao)
        {
            this.abstractMasterCountryDao = abstractMasterCountryDao;
        }

        public override PagedList<AbstractMasterCountry> MasterCountry_All(PageParam pageParam, string search )
        {
            return this.abstractMasterCountryDao.MasterCountry_All(pageParam, search);
        }
       
      
    }

}