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
    public class PromoCodeServices : AbstractPromoCodeServices
    {
        private AbstractPromoCodeDao abstractPromoCodeDao;

        public PromoCodeServices(AbstractPromoCodeDao abstractPromoCodeDao)
        {
            this.abstractPromoCodeDao = abstractPromoCodeDao;
        }

        public override SuccessResult<AbstractPromoCode> PromoCode_ById(int Id)
        {
            return this.abstractPromoCodeDao.PromoCode_ById(Id);
        }
        public override PagedList<AbstractPromoCode> PromoCode_All(PageParam pageParam)
        {
            return this.abstractPromoCodeDao.PromoCode_All(pageParam);
        }
              
        public override SuccessResult<AbstractPromoCode> PromoCode_Upsert(AbstractPromoCode abstractPromoCode)
        {
            return this.abstractPromoCodeDao.PromoCode_Upsert(abstractPromoCode);
        }               
        public override bool PromoCode_Delete(int Id)
        {
            return this.abstractPromoCodeDao.PromoCode_Delete(Id);
        }       
    }

}