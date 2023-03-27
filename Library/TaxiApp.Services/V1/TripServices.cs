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
    public class TripServices : AbstractTripServices
    {
        private AbstractTripDao abstractTripDao;

        public TripServices(AbstractTripDao abstractTripDao)
        {
            this.abstractTripDao = abstractTripDao;
        }

        public override PagedList<AbstractTrip> Trip_All(PageParam pageParam, string search , AbstractTrip abstractTrip)
        {
            return this.abstractTripDao.Trip_All(pageParam, search, abstractTrip);
        }
        public override PagedList<AbstractTrip> TripDetails_ByCustomerId(PageParam pageParam, string search, AbstractTrip abstractTrip)
        {
            return this.abstractTripDao.TripDetails_ByCustomerId(pageParam, search, abstractTrip);
        }

        public override SuccessResult<AbstractTrip> Trip_ById(int Id)
        {
            return this.abstractTripDao.Trip_ById(Id);
        }
        public override SuccessResult<AbstractTrip> TripRating_Upsert(int id, int Rating)
        {
            return this.abstractTripDao.TripRating_Upsert(id,Rating);
        }
        public override SuccessResult<AbstractTrip> PromoCode_Apply(int TripId, string Promocode)
        {
            return this.abstractTripDao.PromoCode_Apply(TripId,Promocode);
        }
        public override SuccessResult<AbstractTrip> PromoCode_Remove(int TripId)
        {
            return this.abstractTripDao.PromoCode_Remove(TripId);
        }
        public override SuccessResult<AbstractTrip> Trip_SendOtp(string MobileNo, int Otp)
        {
            return this.abstractTripDao.Trip_SendOtp(MobileNo, Otp);
        }
        public override SuccessResult<AbstractTrip> Trip_VerifyOtp(string MobileNo, int Otp)
        {
            return this.abstractTripDao.Trip_VerifyOtp(MobileNo, Otp);
        }

        public override SuccessResult<AbstractTrip> Trip_Upsert(AbstractTrip abstractTrip)
        {
            return this.abstractTripDao.Trip_Upsert(abstractTrip); 
        }

        public override SuccessResult<AbstractTrip> Trip_Delete(int Id, int DeletedBy)
        {
            return this.abstractTripDao.Trip_Delete(Id, DeletedBy);
        }
        public override SuccessResult<AbstractTrip> Driver_Assigned(AbstractTrip abstractTrip)
        {
            return this.abstractTripDao.Driver_Assigned(abstractTrip);
        }
        public override SuccessResult<AbstractTrip> Trip_AcceptByDriver(int DriverId, int TripId)
        {
            return this.abstractTripDao.Trip_AcceptByDriver(DriverId, TripId);
        }
        public override SuccessResult<AbstractTrip> Trip_End(int DriverId, int TripId)
        {
            return this.abstractTripDao.Trip_End(DriverId, TripId);
        }
        public override SuccessResult<AbstractTrip> Trip_RejectByDriver(int DriverId, int TripId)
        {
            return this.abstractTripDao.Trip_RejectByDriver(DriverId, TripId);
        }
        public override SuccessResult<AbstractTrip> TripCancelReason_Upsert(AbstractTrip abstractTrip)
        {
            return this.abstractTripDao.TripCancelReason_Upsert(abstractTrip);
        }
        public override PagedList<AbstractTrip> TripList_ApprovalPending(PageParam pageParam, AbstractTrip abstractTrip)
        {
            return this.abstractTripDao.TripList_ApprovalPending(pageParam, abstractTrip);
        }
    }

}