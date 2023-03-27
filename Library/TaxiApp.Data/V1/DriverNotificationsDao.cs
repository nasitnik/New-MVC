using System;
using System.Collections.Generic;
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
    public class DriverNotificationsDao : AbstractDriverNotificationsDao
    {



        public override PagedList<AbstractDriverNotifications> DriverNotifications_All(PageParam pageParam, string search)
        {
            PagedList<AbstractDriverNotifications> DriverNotifications = new PagedList<AbstractDriverNotifications>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.DriverNotifications_All, param, commandType: CommandType.StoredProcedure);
                DriverNotifications.Values.AddRange(task.Read<DriverNotifications>());
                DriverNotifications.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return DriverNotifications;
        }
        public override SuccessResult<AbstractDriverNotifications> DriverNotifications_ById(int Id)
        {
            SuccessResult<AbstractDriverNotifications> DriverNotifications = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.DriverNotifications_ById, param, commandType: CommandType.StoredProcedure);
                DriverNotifications = task.Read<SuccessResult<AbstractDriverNotifications>>().SingleOrDefault();
                DriverNotifications.Item = task.Read<DriverNotifications>().SingleOrDefault();




            }

            return DriverNotifications;
        }
        
        
        

        public override SuccessResult<AbstractDriverNotifications> DriverNotifications_Upsert(AbstractDriverNotifications abstractDriverNotifications)
        {
            SuccessResult<AbstractDriverNotifications> DriverNotifications = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractDriverNotifications.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@DriverId", abstractDriverNotifications.DriverId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@CustomerId", abstractDriverNotifications.CustomerId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@TripId", abstractDriverNotifications.TripId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Messages", abstractDriverNotifications.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", abstractDriverNotifications.CreatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@TotalTimeInHours", abstractDriverNotifications.TotalTimeInHours, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.DriverNotifications_Upsert, param, commandType: CommandType.StoredProcedure);
                DriverNotifications = task.Read<SuccessResult<AbstractDriverNotifications>>().SingleOrDefault();
                DriverNotifications.Item = task.Read<DriverNotifications>().SingleOrDefault();
            }

            return DriverNotifications;
        }
        //public override SuccessResult<AbstractDriverNotifications> DriverNotifications_ReadUnRead(int Id)
        //{
        //    SuccessResult<AbstractDriverNotifications> AbstractDriverNotifications = null;
        //    var param = new DynamicParameters();

        //    param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.QueryMultiple(SQLConfig.DriverNotifications_ReadUnRead, param, commandType: CommandType.StoredProcedure);
        //        AbstractDriverNotifications = task.Read<SuccessResult<AbstractDriverNotifications>>().SingleOrDefault();
        //        AbstractDriverNotifications.Item = task.Read<AbstractDriverNotifications>().SingleOrDefault();
        //    }

        //    return AbstractDriverNotifications;
        //}




        public override SuccessResult<AbstractDriverNotifications> DriverNotifications_ReadUnRead(int Id)
        {
            SuccessResult<AbstractDriverNotifications> DriverNotifications = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.DriverNotifications_ReadUnRead, param, commandType: CommandType.StoredProcedure);
                DriverNotifications = task.Read<SuccessResult<AbstractDriverNotifications>>().SingleOrDefault();
                DriverNotifications.Item = task.Read<DriverNotifications>().SingleOrDefault();
            }

            return DriverNotifications;
        }
    }
}
