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
    public class PricePackageDao : AbstractPricePackageDao
    {
        
        public override PagedList<AbstractPricePackage> PricePackage_All(PageParam pageParam, AbstractPricePackage abstractPricePackage)
        {
            PagedList<AbstractPricePackage> PricePackage = new PagedList<AbstractPricePackage>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);            

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.PricePackage_All, param, commandType: CommandType.StoredProcedure);
                PricePackage.Values.AddRange(task.Read<PricePackage>());
                PricePackage.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return PricePackage;
        }
       
        public override SuccessResult<AbstractPricePackage> PricePackage_ById(int Id)
        {
            SuccessResult<AbstractPricePackage> PricePackage = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.PricePackage_ById, param, commandType: CommandType.StoredProcedure);
                PricePackage = task.Read<SuccessResult<AbstractPricePackage>>().SingleOrDefault();
                PricePackage.Item = task.Read<PricePackage>().SingleOrDefault();
            }

            return PricePackage;
        }
        
       
        public override SuccessResult<AbstractPricePackage> PricePackage_Upsert(AbstractPricePackage abstractPricePackage)
        {
            SuccessResult<AbstractPricePackage> PricePackage = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractPricePackage.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);            
            param.Add("@MasterHourId ", abstractPricePackage.MasterHourId, dbType: DbType.Int32, direction: ParameterDirection.Input);            
            param.Add("@Price  ", abstractPricePackage.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);            
            param.Add("@CreatedBy", abstractPricePackage.CreatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", abstractPricePackage.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.PricePackage_Upsert, param, commandType: CommandType.StoredProcedure);
                PricePackage = task.Read<SuccessResult<AbstractPricePackage>>().SingleOrDefault();
                PricePackage.Item = task.Read<PricePackage>().SingleOrDefault();
            }

            return PricePackage;
        }



    }
}
