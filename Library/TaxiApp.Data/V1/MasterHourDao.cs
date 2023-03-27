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
    public class MasterHourDao : AbstractMasterHourDao
    {
        
        public override PagedList<AbstractMasterHour> MasterHour_All(PageParam pageParam , AbstractMasterHour abstractMasterHour)
        {
            PagedList<AbstractMasterHour> MasterHour = new PagedList<AbstractMasterHour>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);           

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterHour_All, param, commandType: CommandType.StoredProcedure);
                MasterHour.Values.AddRange(task.Read<MasterHour>());
                MasterHour.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return MasterHour;
        }
       
    }
}
