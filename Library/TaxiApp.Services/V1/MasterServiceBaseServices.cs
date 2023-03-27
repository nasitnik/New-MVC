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
    public class MasterServiceBaseServices : AbstractMasterServiceBaseServices
    {
        private AbstractMasterServiceBaseDao abstractMasterServiceBaseDao;

        public MasterServiceBaseServices(AbstractMasterServiceBaseDao abstractMasterServiceBaseDao)
        {
            this.abstractMasterServiceBaseDao = abstractMasterServiceBaseDao;
        }


        public override PagedList<AbstractMasterServiceBase> MasterServiceBase_All(PageParam pageParam, string search)
        {
            return this.abstractMasterServiceBaseDao.MasterServiceBase_All(pageParam, search);
        }



    }

}