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
    public abstract class AbstractFaqServices
    {
        public abstract PagedList<AbstractFaq> Faq_All(PageParam pageParam, string search, int ForFaq);
        public abstract SuccessResult<AbstractFaq> Faq_Upsert(AbstractFaq abstractFaq);
        public abstract SuccessResult<AbstractFaq> Faq_Delete(int Id, int DeletedBy);
        public abstract SuccessResult<AbstractFaq> Faq_ById(int Id);

    }
}

