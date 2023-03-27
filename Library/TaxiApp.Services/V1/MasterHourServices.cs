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
    public class MasterHourServices : AbstractMasterHourServices
    {
        private AbstractMasterHourDao abstractMasterHourDao;

        public MasterHourServices(AbstractMasterHourDao abstractMasterHourDao)
        {
            this.abstractMasterHourDao = abstractMasterHourDao;
        }

        public override PagedList<AbstractMasterHour> MasterHour_All(PageParam pageParam, AbstractMasterHour abstractMasterHour)
        {
            return this.abstractMasterHourDao.MasterHour_All(pageParam, abstractMasterHour);
        }
                                        
    }

}