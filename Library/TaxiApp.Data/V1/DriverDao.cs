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
    public class DriverDao : AbstractDriverDao
    {

        public override PagedList<AbstractDriver> Driver_All(PageParam pageParam, string search, AbstractDriver abstractDriver)
        {
            PagedList<AbstractDriver> Driver = new PagedList<AbstractDriver>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@IsActiveForFilter", abstractDriver.IsActiveForFilter, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_All, param, commandType: CommandType.StoredProcedure);
                Driver.Values.AddRange(task.Read<Driver>());
                Driver.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return Driver;
        }
        public override SuccessResult<AbstractDriver> Driver_AddressUpdate(AbstractDriver abstractDriver)
        {
            SuccessResult<AbstractDriver> Driver = null;
            var param = new DynamicParameters();

            param.Add("@DriverId", abstractDriver.DriverId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@CountryId", abstractDriver.CountryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@StateId", abstractDriver.StateId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@CityId", abstractDriver.CityId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@PinCode", abstractDriver.PinCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Address", abstractDriver.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", abstractDriver.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_AddressUpdate, param, commandType: CommandType.StoredProcedure);
                Driver = task.Read<SuccessResult<AbstractDriver>>().SingleOrDefault();
                Driver.Item = task.Read<Driver>().SingleOrDefault();
            }
            return Driver;
        }
        public override SuccessResult<AbstractDriver> Driver_ById(int Id)
        {
            SuccessResult<AbstractDriver> Driver = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_ById, param, commandType: CommandType.StoredProcedure);
                Driver = task.Read<SuccessResult<AbstractDriver>>().SingleOrDefault();
                Driver.Item = task.Read<Driver>().SingleOrDefault();
            }

            return Driver;
        }

        public override SuccessResult<AbstractDriver> Driver_LatLon(long id)
        {
            SuccessResult<AbstractDriver> Driver = new SuccessResult<AbstractDriver>();
            var param = new DynamicParameters();

            param.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_LatLon, param, commandType: CommandType.StoredProcedure);
                Driver = task.Read<SuccessResult<AbstractDriver>>().SingleOrDefault();
                Driver.Item = task.Read<Driver>().SingleOrDefault();
            }
            return Driver;
        }


        public override bool Driver_Logout(int Id)
        {
            bool result = false;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.Driver_Logout, param, commandType: CommandType.StoredProcedure);
                result = task.SingleOrDefault<bool>();
            }
            return result;

        }

        public override SuccessResult<AbstractDriver> Driver_Login(string Email, string Password, string DeviceToken)
        {
            SuccessResult<AbstractDriver> Driver = null;
            var param = new DynamicParameters();

            param.Add("@Email", Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@DeviceToken", DeviceToken, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_Login, param, commandType: CommandType.StoredProcedure);
                Driver = task.Read<SuccessResult<AbstractDriver>>().SingleOrDefault();
                Driver.Item = task.Read<Driver>().SingleOrDefault();
            }

            return Driver;
        } 
        
        public override SuccessResult<AbstractDriver> Driver_IsOnline(int id, string Lat, string Long)
        {
            SuccessResult<AbstractDriver> Driver = null;
            var param = new DynamicParameters();
            param.Add("@DriverId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Lat", Lat, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Long", Long, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_IsOnline, param, commandType: CommandType.StoredProcedure);
                Driver = task.Read<SuccessResult<AbstractDriver>>().SingleOrDefault();
                Driver.Item = task.Read<Driver>().SingleOrDefault();
            }

            return Driver;
        }

        public override SuccessResult<AbstractDriver> Driver_ChangePassword(AbstractDriver abstractDriver)
        {
            SuccessResult<AbstractDriver> Driver = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractDriver.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@OldPassword", abstractDriver.OldPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@NewPassword", abstractDriver.NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ConfirmPassword", abstractDriver.ConfirmPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Type", abstractDriver.Type, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_ChangePassword, param, commandType: CommandType.StoredProcedure);
                Driver = task.Read<SuccessResult<AbstractDriver>>().SingleOrDefault();
                Driver.Item = task.Read<Driver>().SingleOrDefault();
            }

            return Driver;
        }
        public override SuccessResult<AbstractDriver> Driver_Delete(int Id, int DeletedBy)
        {
            SuccessResult<AbstractDriver> Driver = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@DeletedBy", DeletedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_Delete, param, commandType: CommandType.StoredProcedure);
                Driver = task.Read<SuccessResult<AbstractDriver>>().SingleOrDefault();
                Driver.Item = task.Read<Driver>().SingleOrDefault();
            }
            return Driver;
        }
        public override SuccessResult<AbstractDriver> Driver_DrivingLicenceUpdate(AbstractDriver abstractDriver)
        {
            SuccessResult<AbstractDriver> Driver = null;
            var param = new DynamicParameters();

            param.Add("@DriverId", abstractDriver.DriverId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@DrivingLicence", abstractDriver.DrivingLicence, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", abstractDriver.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_DrivingLicenceUpdate, param, commandType: CommandType.StoredProcedure);
                Driver = task.Read<SuccessResult<AbstractDriver>>().SingleOrDefault();
                Driver.Item = task.Read<Driver>().SingleOrDefault();
            }
            return Driver;
        }
        public override SuccessResult<AbstractDriver> Driver_IdProofUpdate(AbstractDriver abstractDriver)
        {
            SuccessResult<AbstractDriver> Driver = null;
            var param = new DynamicParameters();

            param.Add("@DriverId", abstractDriver.DriverId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@IdProof", abstractDriver.IdProof, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", abstractDriver.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_IdProofUpdate, param, commandType: CommandType.StoredProcedure);
                Driver = task.Read<SuccessResult<AbstractDriver>>().SingleOrDefault();
                Driver.Item = task.Read<Driver>().SingleOrDefault();
            }
            return Driver;
        }
        public override SuccessResult<AbstractDriver> Driver_ProfilePictureUpdate(AbstractDriver abstractDriver)
        {
            SuccessResult<AbstractDriver> Driver = null;
            var param = new DynamicParameters();

            param.Add("@DriverId", abstractDriver.DriverId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ProfilePicture", abstractDriver.ProfilePicture, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", abstractDriver.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_ProfilePictureUpdate, param, commandType: CommandType.StoredProcedure);
                Driver = task.Read<SuccessResult<AbstractDriver>>().SingleOrDefault();
                Driver.Item = task.Read<Driver>().SingleOrDefault();
            }
            return Driver;
        }

        public override SuccessResult<AbstractDriver> Driver_Upsert(AbstractDriver abstractDriver)
        {
            SuccessResult<AbstractDriver> Driver = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractDriver.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@FirstName", abstractDriver.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@LastName", abstractDriver.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@MobileNo", abstractDriver.MobileNo, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Gender", abstractDriver.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", abstractDriver.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", abstractDriver.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CPassword", abstractDriver.CPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@DOB", abstractDriver.DOB, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@LicenceNo", abstractDriver.LicenceNo, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@PucNo", abstractDriver.PucNo, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@LICNo", abstractDriver.LICNo, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@VehicleNo", abstractDriver.VehicleNo, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ChasisNo", abstractDriver.ChasisNo, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@BloodGroup", abstractDriver.BloodGroup, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CountryId", abstractDriver.CountryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@StateId", abstractDriver.StateId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@CityId", abstractDriver.CityId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@PinCode", abstractDriver.PinCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Address", abstractDriver.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", abstractDriver.CreatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", abstractDriver.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_Upsert, param, commandType: CommandType.StoredProcedure);
                Driver = task.Read<SuccessResult<AbstractDriver>>().SingleOrDefault();
                Driver.Item = task.Read<Driver>().SingleOrDefault();
            }

            return Driver;
        } 
        
        
        public override SuccessResult<AbstractDriver> Driver_MsgRec(AbstractDriver abstractDriver)
        {
            SuccessResult<AbstractDriver> Driver = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractDriver.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@MsgJsonRes", abstractDriver.MsgJsonRes, dbType: DbType.String, direction: ParameterDirection.Input);
            
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_MsgRec, param, commandType: CommandType.StoredProcedure);
                Driver = task.Read<SuccessResult<AbstractDriver>>().SingleOrDefault();
                Driver.Item = task.Read<Driver>().SingleOrDefault();
            }

            return Driver;
        }

        public override SuccessResult<AbstractDriver> Driver_ActInAct(int Id)
        {
            SuccessResult<AbstractDriver> Driver = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_ActInAct, param, commandType: CommandType.StoredProcedure);
                Driver = task.Read<SuccessResult<AbstractDriver>>().SingleOrDefault();
                Driver.Item = task.Read<Driver>().SingleOrDefault();
            }

            return Driver;
        }
        public override SuccessResult<AbstractDriver> Driver_IdProofApproved(int Id)
        {
            SuccessResult<AbstractDriver> Driver = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_IdProofApproved, param, commandType: CommandType.StoredProcedure);
                Driver = task.Read<SuccessResult<AbstractDriver>>().SingleOrDefault();
                Driver.Item = task.Read<Driver>().SingleOrDefault();
            }

            return Driver;
        }
        public override SuccessResult<AbstractDriver> Driver_DriveingLicenceApproved(int Id)
        {
            SuccessResult<AbstractDriver> Driver = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Driver_DriveingLicenceApproved, param, commandType: CommandType.StoredProcedure);
                Driver = task.Read<SuccessResult<AbstractDriver>>().SingleOrDefault();
                Driver.Item = task.Read<Driver>().SingleOrDefault();
            }

            return Driver;
        }

    }
}
