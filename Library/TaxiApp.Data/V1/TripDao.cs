using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Common;
using TaxiApp.Common.Paging;
using TaxiApp.Data.Contract;
using TaxiApp.Entities.Contract;
using TaxiApp.Entities.V1;
using Dapper;

namespace TaxiApp.Data.V1
{
    public class TripDao : AbstractTripDao
    {

        public override PagedList<AbstractTrip> Trip_All(PageParam pageParam, string search, AbstractTrip abstractTrip)
        {
            PagedList<AbstractTrip> Trip = new PagedList<AbstractTrip>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CustomerId", abstractTrip.CustomerId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@AssignedId", abstractTrip.AssignedId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@TripDateFrom", abstractTrip.TripDateFrom, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@TripDateTo", abstractTrip.TripDateTo, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@TripTimeFrom", abstractTrip.TripTimeFrom, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@TripTimeTo", abstractTrip.TripTimeTo, dbType: DbType.String, direction: ParameterDirection.Input);
            //param.Add("@TripStatusId", abstractTrip.TripStatusId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Trip_All, param, commandType: CommandType.StoredProcedure);
                Trip.Values.AddRange(task.Read<Trip>());
                Trip.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return Trip;
        }

        public override SuccessResult<AbstractTrip> TripRating_Upsert(int id, int Rating)
        {
            SuccessResult<AbstractTrip> Trip = null;
            var param = new DynamicParameters();

            param.Add("@TripId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@TripRatingByCustomer", Rating, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.TripRating_Upsert, param, commandType: CommandType.StoredProcedure);
                Trip = task.Read<SuccessResult<AbstractTrip>>().SingleOrDefault();
                Trip.Item = task.Read<Trip>().SingleOrDefault();
            }

            return Trip;
        }
        public override PagedList<AbstractTrip> TripList_ApprovalPending(PageParam pageParam,  AbstractTrip abstractTrip)
        {
            PagedList<AbstractTrip> Trip = new PagedList<AbstractTrip>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@DriverId", abstractTrip.DriverId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.TripList_ApprovalPending, param, commandType: CommandType.StoredProcedure);
                Trip.Values.AddRange(task.Read<Trip>());
                Trip.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return Trip;
        }
        public override SuccessResult<AbstractTrip> PromoCode_Apply(int TripId,string Promocode)
        {
            SuccessResult<AbstractTrip> Trip = null;
            var param = new DynamicParameters();

            param.Add("@TripId", TripId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Promocode", Promocode, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.PromoCode_Apply, param, commandType: CommandType.StoredProcedure);
                Trip = task.Read<SuccessResult<AbstractTrip>>().SingleOrDefault();
                Trip.Item = task.Read<Trip>().SingleOrDefault();
            }

            return Trip;
        }
        public override SuccessResult<AbstractTrip> PromoCode_Remove(int TripId)
        {
            SuccessResult<AbstractTrip> Trip = null;
            var param = new DynamicParameters();

            param.Add("@TripId", TripId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.PromoCode_Remove, param, commandType: CommandType.StoredProcedure);
                Trip = task.Read<SuccessResult<AbstractTrip>>().SingleOrDefault();
                Trip.Item = task.Read<Trip>().SingleOrDefault();
            }

            return Trip;
        }
        public override PagedList<AbstractTrip> TripDetails_ByCustomerId(PageParam pageParam, string search, AbstractTrip abstractTrip)
        {
            PagedList<AbstractTrip> Trip = new PagedList<AbstractTrip>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CustomerId", abstractTrip.CustomerId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.TripDetails_ByCustomerId, param, commandType: CommandType.StoredProcedure);
                Trip.Values.AddRange(task.Read<Trip>());
                Trip.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return Trip;
        }
        public override SuccessResult<AbstractTrip> Trip_ById(int Id)
        {
            SuccessResult<AbstractTrip> Trip = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Trip_ById, param, commandType: CommandType.StoredProcedure);
                Trip = task.Read<SuccessResult<AbstractTrip>>().SingleOrDefault();
                Trip.Item = task.Read<Trip>().SingleOrDefault();
            }

            return Trip;
        }
        public override SuccessResult<AbstractTrip> Trip_AcceptByDriver(int DriverId, int TripId)
        {
            SuccessResult<AbstractTrip> Trip = null;
            var param = new DynamicParameters();

            param.Add("@DriverId", DriverId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@TripId", TripId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Trip_AcceptByDriver, param, commandType: CommandType.StoredProcedure);
                Trip = task.Read<SuccessResult<AbstractTrip>>().SingleOrDefault();
                Trip.Item = task.Read<Trip>().SingleOrDefault();
            }

            return Trip;
        }
        public override SuccessResult<AbstractTrip> Trip_End(int DriverId, int TripId)
        {
            SuccessResult<AbstractTrip> Trip = null;
            var param = new DynamicParameters();

            param.Add("@DriverId", DriverId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@TripId", TripId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Trip_End, param, commandType: CommandType.StoredProcedure);
                Trip = task.Read<SuccessResult<AbstractTrip>>().SingleOrDefault();
                Trip.Item = task.Read<Trip>().SingleOrDefault();
            }

            return Trip;
        }
        public override SuccessResult<AbstractTrip> TripCancelReason_Upsert(AbstractTrip abstractTrip)
        {
            SuccessResult<AbstractTrip> Trip = null;
            var param = new DynamicParameters();

            param.Add("@TripId", abstractTrip.TripId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@MasterTripCancelReasonId", abstractTrip.MasterTripCancelReasonId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.TripCancelReason_Upsert, param, commandType: CommandType.StoredProcedure);
                Trip = task.Read<SuccessResult<AbstractTrip>>().SingleOrDefault();
                Trip.Item = task.Read<Trip>().SingleOrDefault();
            }

            return Trip;
        }
        public override SuccessResult<AbstractTrip> Trip_RejectByDriver(int DriverId, int TripId)
        {
            SuccessResult<AbstractTrip> Trip = null;
            var param = new DynamicParameters();

            param.Add("@DriverId", DriverId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@TripId", TripId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Trip_RejectByDriver, param, commandType: CommandType.StoredProcedure);
                Trip = task.Read<SuccessResult<AbstractTrip>>().SingleOrDefault();
                Trip.Item = task.Read<Trip>().SingleOrDefault();
            }

            return Trip;
        }
        public override SuccessResult<AbstractTrip> Driver_Assigned(AbstractTrip abstractTrip)
        {
            SuccessResult<AbstractTrip> Trip = null;
            var param = new DynamicParameters();

            param.Add("@DriverId", abstractTrip.DriverId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@TripId", abstractTrip.TripId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", abstractTrip.CreatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_Assigned, param, commandType: CommandType.StoredProcedure);
                Trip = task.Read<SuccessResult<AbstractTrip>>().SingleOrDefault();
                Trip.Item = task.Read<Trip>().SingleOrDefault();
            }
            return Trip;
        }
        public override SuccessResult<AbstractTrip> Trip_Delete(int Id, int DeletedBy)
        {
            SuccessResult<AbstractTrip> Trip = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@DeletedBy", DeletedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Trip_Delete, param, commandType: CommandType.StoredProcedure);
                Trip = task.Read<SuccessResult<AbstractTrip>>().SingleOrDefault();
                Trip.Item = task.Read<Trip>().SingleOrDefault();
            }
            return Trip;
        }

        public override SuccessResult<AbstractTrip> Trip_Upsert(AbstractTrip abstractTrip)
        {
            SuccessResult<AbstractTrip> Trip = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractTrip.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@CustomerId", abstractTrip.CustomerId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@PickUpLat", abstractTrip.PickUpLat, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@DropOffLat", abstractTrip.DropOffLat, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@PickUpLong", abstractTrip.PickUpLong, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@DropOffLong", abstractTrip.DropOffLong, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@PickUpAddress", abstractTrip.PickUpAddress, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@DropOffAddress", abstractTrip.DropOffAddress, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@TripRatingByCustomer", abstractTrip.TripRatingByCustomer, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@TripRemarksByCustomer", abstractTrip.TripRemarksByCustomer, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@MasterTripTypeId", abstractTrip.MasterTripTypeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@PickUpDate", abstractTrip.PickUpDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("@PickUpTime", abstractTrip.PickUpTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("@DropOffDate", abstractTrip.DropOffDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("@DropOffTime", abstractTrip.DropOffTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("@TotalTime", abstractTrip.TotalTime, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@TotalKiloMeters", abstractTrip.TotalKiloMeters, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", abstractTrip.CreatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", abstractTrip.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Trip_Upsert, param, commandType: CommandType.StoredProcedure);
                Trip = task.Read<SuccessResult<AbstractTrip>>().SingleOrDefault();
                Trip.Item = task.Read<Trip>().SingleOrDefault();
            }

            return Trip;
        }
        public override SuccessResult<AbstractTrip> Trip_VerifyOtp(string MobileNo, int Otp)
        {
            SuccessResult<AbstractTrip> Trip = null;
            var param = new DynamicParameters();

            param.Add("@MobileNo", MobileNo, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Otp", Otp, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Trip_VerifyOtp, param, commandType: CommandType.StoredProcedure);
                Trip = task.Read<SuccessResult<AbstractTrip>>().SingleOrDefault();
                Trip.Item = task.Read<Trip>().SingleOrDefault();
            }
            return Trip;
        }
        public override SuccessResult<AbstractTrip> Trip_SendOtp(string MobileNo, int Otp)
        {
            SuccessResult<AbstractTrip> Trip = null;
            var param = new DynamicParameters();

            param.Add("@MobileNo", MobileNo, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Otp", Otp, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Trip_SendOTP, param, commandType: CommandType.StoredProcedure);
                Trip = task.Read<SuccessResult<AbstractTrip>>().SingleOrDefault();
                Trip.Item = task.Read<Trip>().SingleOrDefault();
            }
            return Trip;
        }


    }
}
