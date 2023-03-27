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
    public class FaqDao : AbstractFaqDao
    {

        public override PagedList<AbstractFaq> Faq_All(PageParam pageParam, string search, int ForFaq)
        {
            PagedList<AbstractFaq> Faq = new PagedList<AbstractFaq>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ForFaq", ForFaq, dbType: DbType.Int32, direction: ParameterDirection.Input);


            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Faq_All, param, commandType: CommandType.StoredProcedure);
                Faq.Values.AddRange(task.Read<Faq>());
                Faq.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return Faq;
        }
        public override SuccessResult<AbstractFaq> Faq_ById(int Id)
        {
            SuccessResult<AbstractFaq> Faq = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Faq_ById, param, commandType: CommandType.StoredProcedure);
                Faq = task.Read<SuccessResult<AbstractFaq>>().SingleOrDefault();
                Faq.Item = task.Read<Faq>().SingleOrDefault();
            }

            return Faq;
        }
        public override SuccessResult<AbstractFaq> Faq_Delete(int Id, int DeletedBy)
        {
            SuccessResult<AbstractFaq> Faq = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@DeletedBy", DeletedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Faq_Delete, param, commandType: CommandType.StoredProcedure);
                Faq = task.Read<SuccessResult<AbstractFaq>>().SingleOrDefault();
                Faq.Item = task.Read<Faq>().SingleOrDefault();
            }
            return Faq;
        }

        public override SuccessResult<AbstractFaq> Faq_Upsert(AbstractFaq abstractFaq)
        {
            SuccessResult<AbstractFaq> Faq = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractFaq.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Question", abstractFaq.Question, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Answer", abstractFaq.Answer, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ForFaq", abstractFaq.ForFaq, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", abstractFaq.CreatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", abstractFaq.UpdatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Faq_Upsert, param, commandType: CommandType.StoredProcedure);
                Faq = task.Read<SuccessResult<AbstractFaq>>().SingleOrDefault();
                Faq.Item = task.Read<Faq>().SingleOrDefault();
            }

            return Faq;
        }



    }
}

