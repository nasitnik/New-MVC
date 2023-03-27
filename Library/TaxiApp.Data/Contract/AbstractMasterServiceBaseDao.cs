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
    public abstract class AbstractMasterServiceBaseDao : AbstractBaseDao
    {
        public abstract PagedList<AbstractMasterServiceBase> MasterServiceBase_All(PageParam pageParam, string search);

    }
}
