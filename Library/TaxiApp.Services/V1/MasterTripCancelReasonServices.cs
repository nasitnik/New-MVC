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
    public class MasterTripCancelReasonServices : AbstractMasterTripCancelReasonServices
    {
        private AbstractMasterTripCancelReasonDao abstractMasterTripCancelReasonDao;

        public MasterTripCancelReasonServices(AbstractMasterTripCancelReasonDao abstractMasterTripCancelReasonDao)
        {
            this.abstractMasterTripCancelReasonDao = abstractMasterTripCancelReasonDao;
        }


        public override PagedList<AbstractMasterTripCancelReason> MasterTripCancelReason_All(PageParam pageParam, string search)
        {
            return this.abstractMasterTripCancelReasonDao.MasterTripCancelReason_All(pageParam, search);
        }
        public override SuccessResult<AbstractMasterTripCancelReason> MasterTripCancelReason_Upsert(AbstractMasterTripCancelReason abstractMasterTripCancelReason)
        {
            return this.abstractMasterTripCancelReasonDao.MasterTripCancelReason_Upsert(abstractMasterTripCancelReason);
        }



    }

}