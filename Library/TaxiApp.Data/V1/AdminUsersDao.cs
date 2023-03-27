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
    public class AdminUsersDao : AbstractAdminUsersDao
    {
        
        public override PagedList<AbstractAdminUsers> AdminUsers_All(PageParam pageParam, string search , AbstractAdminUsers abstractAdminUsers)
        {
            PagedList<AbstractAdminUsers> AdminUsers = new PagedList<AbstractAdminUsers>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.AdminUsers_All, param, commandType: CommandType.StoredProcedure);
                AdminUsers.Values.AddRange(task.Read<AdminUsers>());
                AdminUsers.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return AdminUsers;
        }
        public override bool AdminUsers_Logout(int Id)
        {
            bool result = false;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.AdminUsers_Logout, param, commandType: CommandType.StoredProcedure);
                result = task.SingleOrDefault<bool>();
            }
            return result;

        }
        public override SuccessResult<AbstractAdminUsers> AdminUsers_ById(int Id)
        {
            SuccessResult<AbstractAdminUsers> AdminUsers = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Users_ById, param, commandType: CommandType.StoredProcedure);
                AdminUsers = task.Read<SuccessResult<AbstractAdminUsers>>().SingleOrDefault();
                AdminUsers.Item = task.Read<AdminUsers>().SingleOrDefault();
            }

            return AdminUsers;
        }
        public override SuccessResult<AbstractAdminUsers> AdminUsers_ActInAct(int Id)
        {
            SuccessResult<AbstractAdminUsers> AdminUsers = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.AdminUsers_ActInAct, param, commandType: CommandType.StoredProcedure);
                AdminUsers = task.Read<SuccessResult<AbstractAdminUsers>>().SingleOrDefault();
                AdminUsers.Item = task.Read<AdminUsers>().SingleOrDefault();
            }

            return AdminUsers;
        }
        public override SuccessResult<AbstractAdminUsers> AdminUsers_Login(string Email, string Password)
        {
            SuccessResult<AbstractAdminUsers> AdminUsers = null;
            var param = new DynamicParameters();

            param.Add("@Email", Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", Password, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Users_Login, param, commandType: CommandType.StoredProcedure);
                AdminUsers = task.Read<SuccessResult<AbstractAdminUsers>>().SingleOrDefault();
                AdminUsers.Item = task.Read<AdminUsers>().SingleOrDefault();
            }

            return AdminUsers;
        }
        public override SuccessResult<AbstractAdminUsers> AdminUsers_ChangePassword(AbstractAdminUsers abstractAdminUsers)
        {
            SuccessResult<AbstractAdminUsers> AdminUsers = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractAdminUsers.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@OldPassword", abstractAdminUsers.OldPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@NewPassword", abstractAdminUsers.NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ConfirmPassword", abstractAdminUsers.ConfirmPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            //param.Add("@Type", abstractAdminUsers.Type, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.AdminUsers_ChangePassword, param, commandType: CommandType.StoredProcedure);
                AdminUsers = task.Read<SuccessResult<AbstractAdminUsers>>().SingleOrDefault();
                AdminUsers.Item = task.Read<AdminUsers>().SingleOrDefault();
            }

            return AdminUsers;
        }
        public override SuccessResult<AbstractAdminUsers> AdminUsers_Delete(int Id, int DeletedBy)
        {
            SuccessResult<AbstractAdminUsers> AdminUsers = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@DeletedBy", DeletedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.AdminUsers_Delete, param, commandType: CommandType.StoredProcedure);
                AdminUsers = task.Read<SuccessResult<AbstractAdminUsers>>().SingleOrDefault();
                AdminUsers.Item = task.Read<AdminUsers>().SingleOrDefault();
            }
            return AdminUsers;
        }
       
        public override SuccessResult<AbstractAdminUsers> AdminUsers_Upsert(AbstractAdminUsers abstractAdminUsers)
        {
            SuccessResult<AbstractAdminUsers> AdminUsers = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractAdminUsers.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@UserTypeId", abstractAdminUsers.UserTypeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@FirstName", abstractAdminUsers.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@LastName", abstractAdminUsers.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@MobileNo", abstractAdminUsers.MobileNo, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", abstractAdminUsers.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", abstractAdminUsers.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ProfilePicture", abstractAdminUsers.ProfilePicture, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", abstractAdminUsers.CreatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", abstractAdminUsers.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.AdminUsers_Upsert, param, commandType: CommandType.StoredProcedure);
                AdminUsers = task.Read<SuccessResult<AbstractAdminUsers>>().SingleOrDefault();
                AdminUsers.Item = task.Read<AdminUsers>().SingleOrDefault();
            }

            return AdminUsers;
        }



    }
}
