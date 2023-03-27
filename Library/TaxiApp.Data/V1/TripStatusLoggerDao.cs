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
    public class TripStatusLoggerDao : AbstractTripStatusLoggerDao
    {

        

        public override SuccessResult<AbstractTripStatusLogger> Trip_UpsertStatus(AbstractTripStatusLogger abstractTripStatusLogger)
        {
            SuccessResult<AbstractTripStatusLogger> TripStatusLogger = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractTripStatusLogger.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@StatusId", abstractTripStatusLogger.StatusId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Trip_UpsertStatus, param, commandType: CommandType.StoredProcedure);
                TripStatusLogger = task.Read<SuccessResult<AbstractTripStatusLogger>>().SingleOrDefault();
                TripStatusLogger.Item = task.Read<TripStatusLogger>().SingleOrDefault();
            }

            return TripStatusLogger;
        }
       
    }
}
