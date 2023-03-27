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
    public class CustomerNotificationsDao : AbstractCustomerNotificationsDao
    {

        public override PagedList<AbstractCustomerNotifications> CustomerNotifications_All(PageParam pageParam, string search, AbstractCustomerNotifications abstractCustomerNotifications)
        {
            PagedList<AbstractCustomerNotifications> CustomerNotifications = new PagedList<AbstractCustomerNotifications>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CustomerId", abstractCustomerNotifications.CustomerId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.CustomerNotifications_All, param, commandType: CommandType.StoredProcedure);
                CustomerNotifications.Values.AddRange(task.Read<CustomerNotifications>());
                CustomerNotifications.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return CustomerNotifications;
        }
        public override SuccessResult<AbstractCustomerNotifications> CustomerNotifications_ById(int Id)
        {
            SuccessResult<AbstractCustomerNotifications> CustomerNotifications = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.CustomerNotifications_ById, param, commandType: CommandType.StoredProcedure);
                CustomerNotifications = task.Read<SuccessResult<AbstractCustomerNotifications>>().SingleOrDefault();
                CustomerNotifications.Item = task.Read<CustomerNotifications>().SingleOrDefault();
            }

            return CustomerNotifications;
        }

        public override bool CustomerNotifications_Delete(int CustomerId)
        {
            bool result = false;
            var param = new DynamicParameters();

            param.Add("@CustomerId", CustomerId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.CustomerNotifications_Delete, param, commandType: CommandType.StoredProcedure);
                result = task.SingleOrDefault<bool>();
            }
            return result;

        }

        public override SuccessResult<AbstractCustomerNotifications> CustomerNotifications_ReadUnRead(int Id)
        {
            SuccessResult<AbstractCustomerNotifications> CustomerNotifications = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.CustomerNotifications_ReadUnRead, param, commandType: CommandType.StoredProcedure);
                CustomerNotifications = task.Read<SuccessResult<AbstractCustomerNotifications>>().SingleOrDefault();
                CustomerNotifications.Item = task.Read<CustomerNotifications>().SingleOrDefault();
            }

            return CustomerNotifications;
        }

        public override SuccessResult<AbstractCustomerNotifications> CustomerNotifications_Upsert(AbstractCustomerNotifications abstractCustomerNotifications)
        {
            SuccessResult<AbstractCustomerNotifications> CustomerNotifications = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractCustomerNotifications.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@CustomerId", abstractCustomerNotifications.CustomerId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Message", abstractCustomerNotifications.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", abstractCustomerNotifications.CreatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.CustomerNotifications_Upsert, param, commandType: CommandType.StoredProcedure);
                CustomerNotifications = task.Read<SuccessResult<AbstractCustomerNotifications>>().SingleOrDefault();
                CustomerNotifications.Item = task.Read<CustomerNotifications>().SingleOrDefault();
            }

            return CustomerNotifications;
        }



    }

    
}
