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
    public abstract class AbstractDriverServices
    {
        public abstract PagedList<AbstractDriver> Driver_All(PageParam pageParam, string search, AbstractDriver abstractDriver);
        public abstract SuccessResult<AbstractDriver> Driver_ById(int Id);
        public abstract SuccessResult<AbstractDriver> Driver_LatLon(long id);
        public abstract bool Driver_Logout(int Id);
        public abstract SuccessResult<AbstractDriver> Driver_Delete(int Id, int DeletedBy);
        public abstract SuccessResult<AbstractDriver> Driver_DrivingLicenceUpdate(AbstractDriver abstractDriver);
        public abstract SuccessResult<AbstractDriver> Driver_IdProofUpdate(AbstractDriver abstractDriver);
        public abstract SuccessResult<AbstractDriver> Driver_AddressUpdate(AbstractDriver abstractDriver);
        public abstract SuccessResult<AbstractDriver> Driver_ProfilePictureUpdate(AbstractDriver abstractDriver);
        public abstract SuccessResult<AbstractDriver> Driver_Login(string Email, string PasswordHash, string DeviceToken);
        public abstract SuccessResult<AbstractDriver> Driver_IsOnline(int id, string Lat, string Long);
        public abstract SuccessResult<AbstractDriver> Driver_ChangePassword(AbstractDriver abstractDriver);
        public abstract SuccessResult<AbstractDriver> Driver_Upsert(AbstractDriver abstractDriver);
        public abstract SuccessResult<AbstractDriver> Driver_MsgRec(AbstractDriver abstractDriver);
        public abstract SuccessResult<AbstractDriver> Driver_ActInAct(int Id);
        public abstract SuccessResult<AbstractDriver> Driver_IdProofApproved(int Id);
        public abstract SuccessResult<AbstractDriver> Driver_DriveingLicenceApproved(int Id);
    }
}
