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
    public class MasterTripCancelReasonDao : AbstractMasterTripCancelReasonDao
    {



        public override PagedList<AbstractMasterTripCancelReason> MasterTripCancelReason_All(PageParam pageParam, string search)
        {
            PagedList<AbstractMasterTripCancelReason> MasterTripCancelReason = new PagedList<AbstractMasterTripCancelReason>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterTripCancelReason_All, param, commandType: CommandType.StoredProcedure);
                MasterTripCancelReason.Values.AddRange(task.Read<MasterTripCancelReason>());
                MasterTripCancelReason.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return MasterTripCancelReason;
        }
        public override SuccessResult<AbstractMasterTripCancelReason> MasterTripCancelReason_Upsert(AbstractMasterTripCancelReason abstractMasterTripCancelReason)
        {
            SuccessResult<AbstractMasterTripCancelReason> MasterTripCancelReason = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractMasterTripCancelReason.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", abstractMasterTripCancelReason.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterTripCancelReason_Upsert, param, commandType: CommandType.StoredProcedure);
                MasterTripCancelReason = task.Read<SuccessResult<AbstractMasterTripCancelReason>>().SingleOrDefault();
                MasterTripCancelReason.Item = task.Read<MasterTripCancelReason>().SingleOrDefault();
            }

            return MasterTripCancelReason;
        }

    }
}

