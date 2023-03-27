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
    public class HelpServices : AbstractHelpServices
    {
        private AbstractHelpDao abstractHelpDao;

        public HelpServices(AbstractHelpDao abstractHelpDao)
        {
            this.abstractHelpDao = abstractHelpDao;
        }


        public override PagedList<AbstractHelp> Help_All(PageParam pageParam, string search)
        {
            return this.abstractHelpDao.Help_All(pageParam, search);
        }

       

    }

}