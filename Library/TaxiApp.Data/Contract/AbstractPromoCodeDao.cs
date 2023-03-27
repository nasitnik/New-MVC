
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
    public abstract class AbstractPromoCodeDao : AbstractBaseDao
    {
        public abstract PagedList<AbstractPromoCode> PromoCode_All(PageParam pageParam);               
        public abstract bool PromoCode_Delete(int Id);
        public abstract SuccessResult<AbstractPromoCode> PromoCode_ById(int Id);
        public abstract SuccessResult<AbstractPromoCode> PromoCode_Upsert(AbstractPromoCode abstractPromoCode);
    }
}
