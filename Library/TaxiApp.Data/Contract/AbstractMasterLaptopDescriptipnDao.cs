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
    public abstract class AbstractMasterLaptopDescriptipnDao : AbstractBaseDao
    {
        public abstract PagedList<AbstractMasterLaptopDescriptipn> MasterLaptopDescriptipn_All(PageParam pageParam, AbstractMasterLaptopDescriptipn abstractMasterLaptopDescriptipn);
        public abstract SuccessResult<AbstractMasterLaptopDescriptipn> MasterLaptopDescriptipn_ById(int LaptopId);        
        public abstract SuccessResult<AbstractMasterLaptopDescriptipn> MasterLaptopDescriptipn_Upsert(AbstractMasterLaptopDescriptipn abstractMasterLaptopDescriptipn);
        

    }
}
