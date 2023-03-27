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
    public class MasterStateServices : AbstractMasterStateServices
    {
        private AbstractMasterStateDao abstractMasterStateDao;

        public MasterStateServices(AbstractMasterStateDao abstractMasterStateDao)
        {
            this.abstractMasterStateDao = abstractMasterStateDao;
        }

        public override PagedList<AbstractMasterState> MasterState_All(PageParam pageParam, string search )
        {
            return this.abstractMasterStateDao.MasterState_All(pageParam, search);
        }
       
      
    }

}