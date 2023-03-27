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
    public class PromoCodeDao : AbstractPromoCodeDao
    {

        public override PagedList<AbstractPromoCode> PromoCode_All(PageParam pageParam)
        {
            PagedList<AbstractPromoCode> PromoCode = new PagedList<AbstractPromoCode>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);            

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.PromoCode_All, param, commandType: CommandType.StoredProcedure);
                PromoCode.Values.AddRange(task.Read<PromoCode>());
                PromoCode.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return PromoCode;
        }

        public override SuccessResult<AbstractPromoCode> PromoCode_ById(int Id)
        {
            SuccessResult<AbstractPromoCode> PromoCode = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.PromoCode_ById, param, commandType: CommandType.StoredProcedure);
                PromoCode = task.Read<SuccessResult<AbstractPromoCode>>().SingleOrDefault();
                PromoCode.Item = task.Read<PromoCode>().SingleOrDefault();
            }

            return PromoCode;
        }
        public override bool PromoCode_Delete(int Id)
        {
            bool result = false;
            var param = new DynamicParameters();


            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);    
            
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.PromoCode_Delete, param, commandType: CommandType.StoredProcedure);
                result = task.SingleOrDefault<bool>();
            }
            return result;
        }
        public override SuccessResult<AbstractPromoCode> PromoCode_Upsert(AbstractPromoCode abstractPromoCode)
        {
            SuccessResult<AbstractPromoCode> PromoCode = null; 
            var param = new DynamicParameters();

            param.Add("@Id", abstractPromoCode.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", abstractPromoCode.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Discount", abstractPromoCode.Discount, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", abstractPromoCode.CreatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", abstractPromoCode.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.PromoCode_Upsert, param, commandType: CommandType.StoredProcedure);
                PromoCode = task.Read<SuccessResult<AbstractPromoCode>>().SingleOrDefault();
                PromoCode.Item = task.Read<PromoCode>().SingleOrDefault();
            }
            return PromoCode;
        }        
    }
}
