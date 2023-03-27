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
    public class PromoCodeController : BaseController
    {
        private readonly AbstractPromoCodeServices abstractPromoCodeServices = null;


        public PromoCodeController(AbstractPromoCodeServices abstractPromoCodeServices)
        {
            this.abstractPromoCodeServices = abstractPromoCodeServices;

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetPromoCodeById(int Id = 0)
        {
            SuccessResult<AbstractPromoCode> successResult = abstractPromoCodeServices.PromoCode_ById(Id);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        //PromoCode owner all data get
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ViewAllData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, int ForPromoCode = 0)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                AbstractPromoCode PromoCode = new PromoCode();

                var response = abstractPromoCodeServices.PromoCode_All(pageParam);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult DeletePromoCode(int Id = 0)
        {
            abstractPromoCodeServices.PromoCode_Delete(Id);
            return Json("PromoCode Deleted successfully", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult PromoCodeUpsert( int Id = 0, string Name = "",int Discount = 0)
        {
            
            PromoCode model = new PromoCode();
            model.Id = Id;
            model.Name = Name;
            model.Discount = Discount;
            model.CreatedBy = ProjectSession.AdminId;
            model.UpdatedBy = ProjectSession.AdminId;

            var result = abstractPromoCodeServices.PromoCode_Upsert(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}