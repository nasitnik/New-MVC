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
    public class HelpDao : AbstractHelpDao
    {



        public override PagedList<AbstractHelp> Help_All(PageParam pageParam, string search)
        {
            PagedList<AbstractHelp> Help = new PagedList<AbstractHelp>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Help_All, param, commandType: CommandType.StoredProcedure);
                Help.Values.AddRange(task.Read<Help>());
                Help.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return Help;
        }
       
    }
}

