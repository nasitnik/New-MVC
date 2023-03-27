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
    public class MasterLaptopDescriptipnDao : AbstractMasterLaptopDescriptipnDao
    {
        
        public override PagedList<AbstractMasterLaptopDescriptipn> MasterLaptopDescriptipn_All(PageParam pageParam, AbstractMasterLaptopDescriptipn abstractMasterLaptopDescriptipn)
        {
            PagedList<AbstractMasterLaptopDescriptipn> MasterLaptopDescriptipn = new PagedList<AbstractMasterLaptopDescriptipn>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);            

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.spMasterLaptopDescriptipn_All, param, commandType: CommandType.StoredProcedure);
                MasterLaptopDescriptipn.Values.AddRange(task.Read<MasterLaptopDescriptipn>());
                MasterLaptopDescriptipn.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return MasterLaptopDescriptipn;
        }
       
        public override SuccessResult<AbstractMasterLaptopDescriptipn> MasterLaptopDescriptipn_ById(int Laptop)
        {
            SuccessResult<AbstractMasterLaptopDescriptipn> MasterLaptopDescriptipn = null;
            var param = new DynamicParameters();

            param.Add("@LaptopId", Laptop, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.spMasterLaptopDescriptipn_ById, param, commandType: CommandType.StoredProcedure);
                MasterLaptopDescriptipn = task.Read<SuccessResult<AbstractMasterLaptopDescriptipn>>().SingleOrDefault();
                MasterLaptopDescriptipn.Item = task.Read<MasterLaptopDescriptipn>().SingleOrDefault();
            }

            return MasterLaptopDescriptipn;
        }
        
       
        public override SuccessResult<AbstractMasterLaptopDescriptipn> MasterLaptopDescriptipn_Upsert(AbstractMasterLaptopDescriptipn abstractMasterLaptopDescriptipn)
        {
            SuccessResult<AbstractMasterLaptopDescriptipn> MasterLaptopDescriptipn = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractMasterLaptopDescriptipn.Laptop, dbType: DbType.Int32, direction: ParameterDirection.Input);            
            param.Add("@MasterHourId ", abstractMasterLaptopDescriptipn.MasterHourId, dbType: DbType.Int32, direction: ParameterDirection.Input);            
            //param.Add("@Price  ", abstractMasterLaptopDescriptipn.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);            
            param.Add("@CreatedBy", abstractMasterLaptopDescriptipn.CreatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", abstractMasterLaptopDescriptipn.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.spMasterLaptopDescriptipn_Upsert, param, commandType: CommandType.StoredProcedure);
                MasterLaptopDescriptipn = task.Read<SuccessResult<AbstractMasterLaptopDescriptipn>>().SingleOrDefault();
                MasterLaptopDescriptipn.Item = task.Read<MasterLaptopDescriptipn>().SingleOrDefault();
            }

            return MasterLaptopDescriptipn;
        }



    }
}
