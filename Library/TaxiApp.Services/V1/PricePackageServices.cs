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
    public class PricePackageServices : AbstractPricePackageServices
    {
        private AbstractPricePackageDao abstractPricePackageDao;

        public PricePackageServices(AbstractPricePackageDao abstractPricePackageDao)
        {
            this.abstractPricePackageDao = abstractPricePackageDao;
        }

        public override PagedList<AbstractPricePackage> PricePackage_All(PageParam pageParam, AbstractPricePackage abstractPricePackage)
        {
            return this.abstractPricePackageDao.PricePackage_All(pageParam, abstractPricePackage);
        }
       
        public override SuccessResult<AbstractPricePackage> PricePackage_ById(int Id)
        {
            return this.abstractPricePackageDao.PricePackage_ById(Id);
        }        
        public override SuccessResult<AbstractPricePackage> PricePackage_Upsert(AbstractPricePackage abstractPricePackage)
        {
            return this.abstractPricePackageDao.PricePackage_Upsert(abstractPricePackage); 
        }                             
    }

}