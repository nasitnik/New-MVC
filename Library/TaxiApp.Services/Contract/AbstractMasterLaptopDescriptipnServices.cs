using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Common;
using TaxiApp.Common.Paging;
using TaxiApp.Entities.Contract;

namespace TaxiApp.Services.Contract
{
    public abstract class AbstractMasterLaptopDescriptipnServices
    {
        public abstract PagedList<AbstractMasterLaptopDescriptipn> MasterLaptopDescriptipn_All(PageParam pageParam, AbstractMasterLaptopDescriptipn AbstractMasterLaptopDescriptipn);
        public abstract SuccessResult<AbstractMasterLaptopDescriptipn> MasterLaptopDescriptipn_ById(int Id);                              
        public abstract SuccessResult<AbstractMasterLaptopDescriptipn> MasterLaptopDescriptipn_Upsert(AbstractMasterLaptopDescriptipn abstractMasterLaptopDescriptipn);
        

    }
}
