using DataTables.Mvc;
using TaxiApp.Common;
using TaxiApp.Common.Paging;
using TaxiApp.Entities.Contract;
using TaxiApp.Entities.V1;
using TaxiApp.Services.Contract;
using TaxiAppAdmin.Infrastructure;
using TaxiAppAdmin.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiAppAdmin.Controllers
{
    public class FaqController : BaseController
    {
        private readonly AbstractFaqServices abstractFaqServices = null;

        public FaqController(AbstractFaqServices abstractFaqServices, AbstractTripServices abstractTripServices, AbstractTripStatusLoggerServices abstractTripStatusLoggerServices)
        {
            this.abstractFaqServices = abstractFaqServices;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddFaq()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DeleteFaq(int Id = 0)
        {
            int DeletedBy = ProjectSession.AdminId;
            abstractFaqServices.Faq_Delete(Id, DeletedBy);
            return Json("Faq Deleted successfully", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetFaqById(int Id = 0)
        {
            SuccessResult<AbstractFaq> successResult = abstractFaqServices.Faq_ById(Id);
            return Json(successResult,JsonRequestBehavior.AllowGet);
        }
        
        //Faq owner all data get
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ViewAllData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, int ForFaq = 0)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);

                var response = abstractFaqServices.Faq_All(pageParam, search, ForFaq);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult FaqUpsert( int Id = 0, int ForFaq = 0,string Question="",string Answer="")
        {
            
            Faq model = new Faq();
            model.Id = Id;
            model.ForFaq = ForFaq;
            model.Question = Question;
            model.Answer = Answer;
            model.CreatedBy = ProjectSession.AdminId;
            model.UpdatedBy = ProjectSession.AdminId;

            var result = abstractFaqServices.Faq_Upsert(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}