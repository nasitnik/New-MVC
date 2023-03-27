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
    public class CustomerDao : AbstractCustomerDao
    {

        //    public override PagedList<AbstractCustomer> Customer_All(PageParam pageParam, string search,AbstractCustomer abstractCustomer)
        //    {
        //        PagedList<AbstractCustomer> Customer = new PagedList<AbstractCustomer>();

        //        var param = new DynamicParameters();
        //        param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@IsActiveForFilter", abstractCustomer.IsActiveForFilter, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@Gender", abstractCustomer.Gender, dbType: DbType.String, direction: ParameterDirection.Input);

        //        using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //        {
        //            var task = con.QueryMultiple(SQLConfig.Customer_All, param, commandType: CommandType.StoredProcedure);
        //            Customer.Values.AddRange(task.Read<Customer>());
        //            Customer.TotalRecords = task.Read<int>().SingleOrDefault();
        //        }
        //        return Customer;
        //    }
        //    public override SuccessResult<AbstractCustomer> Customer_ById(int Id)
        //    {
        //        SuccessResult<AbstractCustomer> Customer = null;
        //        var param = new DynamicParameters();

        //        param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //        using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //        {
        //            var task = con.QueryMultiple(SQLConfig.Customer_ById, param, commandType: CommandType.StoredProcedure);
        //            Customer = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
        //            Customer.Item = task.Read<Customer>().SingleOrDefault();
        //        }

        //        return Customer;
        //    }
        //    public override SuccessResult<AbstractCustomer> Trip_Start(int CustomerId)
        //    {
        //        SuccessResult<AbstractCustomer> Customer = null;
        //        var param = new DynamicParameters();

        //        param.Add("@CustomerId", CustomerId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //        using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //        {
        //            var task = con.QueryMultiple(SQLConfig.Trip_Start, param, commandType: CommandType.StoredProcedure);
        //            Customer = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
        //            Customer.Item = task.Read<Customer>().SingleOrDefault();
        //        }

        //        return Customer;
        //    }
        //    public override SuccessResult<AbstractCustomer> Customer_Login(string Email, string Password, string DeviceToken)
        //    {
        //        SuccessResult<AbstractCustomer> Customer = null;
        //        var param = new DynamicParameters();

        //        param.Add("@Email", Email, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@Password", Password, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@DeviceToken", DeviceToken, dbType: DbType.String, direction: ParameterDirection.Input);

        //        using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //        {
        //            var task = con.QueryMultiple(SQLConfig.Customer_Login, param, commandType: CommandType.StoredProcedure);
        //            Customer = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
        //            Customer.Item = task.Read<Customer>().SingleOrDefault();
        //        }

        //        return Customer;
        //    }
        //    public override SuccessResult<AbstractCustomer> Customer_ChangePassword(AbstractCustomer abstractCustomer)
        //    {
        //        SuccessResult<AbstractCustomer> Customer = null;
        //        var param = new DynamicParameters();

        //        param.Add("@Id", abstractCustomer.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@OldPassword", abstractCustomer.OldPassword, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@NewPassword", abstractCustomer.NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@ConfirmPassword", abstractCustomer.ConfirmPassword, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@Type", abstractCustomer.Type, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //        using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //        {
        //            var task = con.QueryMultiple(SQLConfig.Customer_ChangePassword, param, commandType: CommandType.StoredProcedure);
        //            Customer = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
        //            Customer.Item = task.Read<Customer>().SingleOrDefault();
        //        }

        //        return Customer;
        //    }
        //    public override SuccessResult<AbstractCustomer> Customer_Delete(int Id, int DeletedBy)
        //    {
        //        SuccessResult<AbstractCustomer> Customer = null;
        //        var param = new DynamicParameters();

        //        param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@DeletedBy", DeletedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //        using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //        {
        //            var task = con.QueryMultiple(SQLConfig.Customer_Delete, param, commandType: CommandType.StoredProcedure);
        //            Customer = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
        //            Customer.Item = task.Read<Customer>().SingleOrDefault();
        //        }
        //        return Customer;
        //    }
        //    public override SuccessResult<AbstractCustomer> Customer_RcCardUpdate(AbstractCustomer abstractCustomer)
        //    {
        //        SuccessResult<AbstractCustomer> Customer = null;
        //        var param = new DynamicParameters();

        //        param.Add("@CustomerId", abstractCustomer.CustomerId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@RcCard", abstractCustomer.RcCard, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@UpdatedBy", abstractCustomer.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //        using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //        {
        //            var task = con.QueryMultiple(SQLConfig.Customer_RcCardUpdate, param, commandType: CommandType.StoredProcedure);
        //            Customer = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
        //            Customer.Item = task.Read<Customer>().SingleOrDefault();
        //        }
        //        return Customer;
        //    }
        //    public override SuccessResult<AbstractCustomer> Customer_AddressUpdate(AbstractCustomer abstractCustomer)
        //    {
        //        SuccessResult<AbstractCustomer> Customer = null;
        //        var param = new DynamicParameters();

        //        param.Add("@CustomerId", abstractCustomer.CustomerId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@CountryId", abstractCustomer.CountryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@StateId", abstractCustomer.StateId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@CityId", abstractCustomer.CityId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@PinCode", abstractCustomer.PinCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@Address", abstractCustomer.Address, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@UpdatedBy", abstractCustomer.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //        using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //        {
        //            var task = con.QueryMultiple(SQLConfig.Customer_AddressUpdate, param, commandType: CommandType.StoredProcedure);
        //            Customer = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
        //            Customer.Item = task.Read<Customer>().SingleOrDefault();
        //        }
        //        return Customer;
        //    }
        //    public override SuccessResult<AbstractCustomer> Customer_IdProofUpdate(AbstractCustomer abstractCustomer)
        //    {
        //        SuccessResult<AbstractCustomer> Customer = null;
        //        var param = new DynamicParameters();

        //        param.Add("@CustomerId", abstractCustomer.CustomerId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@IdProof", abstractCustomer.IdProof, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@UpdatedBy", abstractCustomer.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);


        //        using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //        {
        //            var task = con.QueryMultiple(SQLConfig.Customer_IdProofUpdate, param, commandType: CommandType.StoredProcedure);
        //            Customer = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
        //            Customer.Item = task.Read<Customer>().SingleOrDefault();
        //        }
        //        return Customer;
        //    }
        //    public override SuccessResult<AbstractCustomer> Customer_ProfilePictureUpdate(AbstractCustomer abstractCustomer)
        //    {
        //        SuccessResult<AbstractCustomer> Customer = null;
        //        var param = new DynamicParameters();

        //        param.Add("@CustomerId", abstractCustomer.CustomerId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@ProfilePicture", abstractCustomer.ProfilePicture, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@UpdatedBy", abstractCustomer.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //        using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //        {
        //            var task = con.QueryMultiple(SQLConfig.Customer_ProfilePictureUpdate, param, commandType: CommandType.StoredProcedure);
        //            Customer = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
        //            Customer.Item = task.Read<Customer>().SingleOrDefault();
        //        }
        //        return Customer;
        //    }

        //    public override SuccessResult<AbstractCustomer> Customer_Upsert(AbstractCustomer abstractCustomer)
        //    {
        //        SuccessResult<AbstractCustomer> Customer = null;
        //        var param = new DynamicParameters();

        //        param.Add("@Id", abstractCustomer.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@FirstName", abstractCustomer.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@LastName", abstractCustomer.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@MobileNo", abstractCustomer.MobileNo, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@Email", abstractCustomer.Email, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@Password", abstractCustomer.Password, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@DOB", abstractCustomer.DOB, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@Gender", abstractCustomer.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@StateId", abstractCustomer.StateId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@CityId", abstractCustomer.CityId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@PinCode", abstractCustomer.PinCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@Address", abstractCustomer.Address, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@CreatedBy", abstractCustomer.CreatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@UpdatedBy", abstractCustomer.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //        {
        //            var task = con.QueryMultiple(SQLConfig.Customer_Upsert, param, commandType: CommandType.StoredProcedure);
        //            Customer = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
        //            Customer.Item = task.Read<Customer>().SingleOrDefault();
        //        }

        //        return Customer;
        //    }
        //    public override SuccessResult<AbstractCustomer> Customer_ActInAct(int Id)
        //    {
        //        SuccessResult<AbstractCustomer> Customer = null;
        //        var param = new DynamicParameters();

        //        param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //        using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //        {
        //            var task = con.QueryMultiple(SQLConfig.Customer_ActInAct, param, commandType: CommandType.StoredProcedure);
        //            Customer = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
        //            Customer.Item = task.Read<Customer>().SingleOrDefault();
        //        }

        //        return Customer;
        //    }
        //    public override SuccessResult<AbstractCustomer> Customer_RcCardApproved(int Id)
        //    {
        //        SuccessResult<AbstractCustomer> Customer = null;
        //        var param = new DynamicParameters();

        //        param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //        using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //        {
        //            var task = con.QueryMultiple(SQLConfig.Customer_RcCardApproved, param, commandType: CommandType.StoredProcedure);
        //            Customer = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
        //            Customer.Item = task.Read<Customer>().SingleOrDefault();
        //        }

        //        return Customer;
        //    }
        //    public override SuccessResult<AbstractCustomer> Customer_IdProofApproved(int Id)
        //    {
        //        SuccessResult<AbstractCustomer> Customer = null;
        //        var param = new DynamicParameters();

        //        param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //        using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //        {
        //            var task = con.QueryMultiple(SQLConfig.Customer_IdProofApproved, param, commandType: CommandType.StoredProcedure);
        //            Customer = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
        //            Customer.Item = task.Read<Customer>().SingleOrDefault();
        //        }

        //        return Customer;
        //    }
        //    public override bool Customer_Logout(int Id)
        //    {
        //        bool result = false;
        //        var param = new DynamicParameters();

        //        param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //        using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //        {
        //            var task = con.Query<bool>(SQLConfig.Customer_Logout, param, commandType: CommandType.StoredProcedure);
        //            result = task.SingleOrDefault<bool>();
        //        }
        //        return result;

        //    }

    }
}
