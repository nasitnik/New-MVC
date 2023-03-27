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
    public abstract class AbstractTripServices
    {
        public abstract PagedList<AbstractTrip> Trip_All(PageParam pageParam, string search, AbstractTrip abstractTrip);
        public abstract PagedList<AbstractTrip> TripDetails_ByCustomerId(PageParam pageParam, string search, AbstractTrip abstractTrip);
        public abstract SuccessResult<AbstractTrip> Trip_ById(int Id);
        public abstract SuccessResult<AbstractTrip> Trip_Delete(int Id, int DeletedBy);
        public abstract SuccessResult<AbstractTrip> Trip_AcceptByDriver(int DriverId, int TripId);
        public abstract SuccessResult<AbstractTrip> Trip_End(int DriverId, int TripId);
        public abstract SuccessResult<AbstractTrip> Trip_RejectByDriver(int DriverId, int TripId);
        public abstract SuccessResult<AbstractTrip> TripCancelReason_Upsert(AbstractTrip abstractTrip);
        public abstract PagedList<AbstractTrip> TripList_ApprovalPending(PageParam pageParam, AbstractTrip abstractTrip);
        public abstract SuccessResult<AbstractTrip> Trip_Upsert(AbstractTrip abstractTrip);
        public abstract SuccessResult<AbstractTrip> Driver_Assigned(AbstractTrip abstractTrip);
        public abstract SuccessResult<AbstractTrip> Trip_VerifyOtp(string MobileNo, int Otp);
        public abstract SuccessResult<AbstractTrip> Trip_SendOtp(string MobileNo, int Otp);
        public abstract SuccessResult<AbstractTrip> PromoCode_Apply(int TripId, string Promocode);
        public abstract SuccessResult<AbstractTrip> PromoCode_Remove(int TripId);
        public abstract SuccessResult<AbstractTrip> TripRating_Upsert(int id, int Rating);

    }
}
