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
    public abstract class AbstractPricePackageServices
    {
        public abstract PagedList<AbstractPricePackage> PricePackage_All(PageParam pageParam, AbstractPricePackage AbstractPricePackage);
        public abstract SuccessResult<AbstractPricePackage> PricePackage_ById(int Id);                              
        public abstract SuccessResult<AbstractPricePackage> PricePackage_Upsert(AbstractPricePackage abstractPricePackage);
        

    }
}
