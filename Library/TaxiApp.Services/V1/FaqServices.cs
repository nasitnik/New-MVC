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
    public class FaqServices : AbstractFaqServices
    {
        private AbstractFaqDao abstractFaqDao;

        public FaqServices(AbstractFaqDao abstractFaqDao)
        {
            this.abstractFaqDao = abstractFaqDao;
        }

        public override PagedList<AbstractFaq> Faq_All(PageParam pageParam, string search, int ForFaq)
        {
            return this.abstractFaqDao.Faq_All(pageParam, search, ForFaq);
        }
        public override SuccessResult<AbstractFaq> Faq_ById(int Id)
        {
            return this.abstractFaqDao.Faq_ById(Id);
        }
        public override SuccessResult<AbstractFaq> Faq_Delete(int Id, int DeletedBy)
        {
            return this.abstractFaqDao.Faq_Delete(Id,DeletedBy);
        }

        public override SuccessResult<AbstractFaq> Faq_Upsert( AbstractFaq abstractFaq)
        {
            return this.abstractFaqDao.Faq_Upsert( abstractFaq);
        }
  
    }

}
