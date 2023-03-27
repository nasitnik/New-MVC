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
    public class MasterLaptopDescriptipnServices : AbstractMasterLaptopDescriptipnServices
    {
        private AbstractMasterLaptopDescriptipnDao abstractMasterLaptopDescriptipnDao;

        public MasterLaptopDescriptipnServices(AbstractMasterLaptopDescriptipnDao abstractMasterLaptopDescriptipnDao)
        {
            this.abstractMasterLaptopDescriptipnDao = abstractMasterLaptopDescriptipnDao;
        }

        public override PagedList<AbstractMasterLaptopDescriptipn> MasterLaptopDescriptipn_All(PageParam pageParam, AbstractMasterLaptopDescriptipn abstractMasterLaptopDescriptipn)
        {
            return this.abstractMasterLaptopDescriptipnDao.MasterLaptopDescriptipn_All(pageParam, abstractMasterLaptopDescriptipn);
        }
       
        public override SuccessResult<AbstractMasterLaptopDescriptipn> MasterLaptopDescriptipn_ById(int Id)
        {
            return this.abstractMasterLaptopDescriptipnDao.MasterLaptopDescriptipn_ById(Id);
        }        
        public override SuccessResult<AbstractMasterLaptopDescriptipn> MasterLaptopDescriptipn_Upsert(AbstractMasterLaptopDescriptipn abstractMasterLaptopDescriptipn)
        {
            return this.abstractMasterLaptopDescriptipnDao.MasterLaptopDescriptipn_Upsert(abstractMasterLaptopDescriptipn); 
        }                             
    }

}