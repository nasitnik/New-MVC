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
    public class DriverServices : AbstractDriverServices
    {
        private AbstractDriverDao abstractDriverDao;

        public DriverServices(AbstractDriverDao abstractDriverDao)
        {
            this.abstractDriverDao = abstractDriverDao;
        }

        public override PagedList<AbstractDriver> Driver_All(PageParam pageParam, string search, AbstractDriver abstractDriver)
        {
            return this.abstractDriverDao.Driver_All(pageParam, search, abstractDriver);
        }

        public override SuccessResult<AbstractDriver> Driver_ById(int Id)
        {
            return this.abstractDriverDao.Driver_ById(Id);
        } 
        public override SuccessResult<AbstractDriver> Driver_LatLon(long id)
        {
            return this.abstractDriverDao.Driver_LatLon(id);
        }
        public override SuccessResult<AbstractDriver> Driver_DrivingLicenceUpdate(AbstractDriver abstractDriver)
        {
            return this.abstractDriverDao.Driver_DrivingLicenceUpdate(abstractDriver);
        }
        public override SuccessResult<AbstractDriver> Driver_AddressUpdate(AbstractDriver abstractDriver)
        {
            return this.abstractDriverDao.Driver_AddressUpdate(abstractDriver);
        }
        public override SuccessResult<AbstractDriver> Driver_IdProofUpdate(AbstractDriver abstractDriver)
        {
            return this.abstractDriverDao.Driver_IdProofUpdate(abstractDriver);
        }
        public override SuccessResult<AbstractDriver> Driver_ProfilePictureUpdate(AbstractDriver abstractDriver)
        {
            return this.abstractDriverDao.Driver_ProfilePictureUpdate(abstractDriver);
        }

        public override bool Driver_Logout(int Id)
        {
            return this.abstractDriverDao.Driver_Logout(Id);
        }

        public override SuccessResult<AbstractDriver> Driver_Upsert(AbstractDriver abstractDriver)
        {
            return this.abstractDriverDao.Driver_Upsert(abstractDriver); 
        }
        
        public override SuccessResult<AbstractDriver> Driver_MsgRec(AbstractDriver abstractDriver)
        {
            return this.abstractDriverDao.Driver_MsgRec(abstractDriver); 
        }
        public override SuccessResult<AbstractDriver> Driver_Login(string Email, string Password, string DeviceToken)
        {
            return this.abstractDriverDao.Driver_Login(Email, Password, DeviceToken);
        }  
        
       
        public override SuccessResult<AbstractDriver> Driver_IsOnline(int id, string Lat, string Long)
        {
            return this.abstractDriverDao.Driver_IsOnline(id, Lat, Long);
        }
        public override SuccessResult<AbstractDriver> Driver_ChangePassword(AbstractDriver abstractDriver)
        {
            return this.abstractDriverDao.Driver_ChangePassword(abstractDriver);
        }
        public override SuccessResult<AbstractDriver> Driver_Delete(int Id, int DeletedBy)
        {
            return this.abstractDriverDao.Driver_Delete(Id, DeletedBy);
        }

        public override SuccessResult<AbstractDriver> Driver_ActInAct(int Id)
        {
            return this.abstractDriverDao.Driver_ActInAct(Id);
        }
        public override SuccessResult<AbstractDriver> Driver_IdProofApproved(int Id)
        {
            return this.abstractDriverDao.Driver_IdProofApproved(Id);
        }
        public override SuccessResult<AbstractDriver> Driver_DriveingLicenceApproved(int Id)
        {
            return this.abstractDriverDao.Driver_DriveingLicenceApproved(Id);
        }
    }

}