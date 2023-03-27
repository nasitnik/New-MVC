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
    public abstract class AbstractMasterStateDao : AbstractBaseDao
    {
        public abstract PagedList<AbstractMasterState> MasterState_All(PageParam pageParam, string search);

    }
}
