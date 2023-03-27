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
    public class PackagePriceController : BaseController
    {
        private readonly AbstractPricePackageServices abstractPricePackageServices = null;
        private readonly AbstractMasterHourServices abstractMasterHourServices = null;


        public PackagePriceController(AbstractPricePackageServices abstractPricePackageServices, AbstractMasterHourServices abstractMasterHourServices)
        {
            this.abstractPricePackageServices = abstractPricePackageServices;
            this.abstractMasterHourServices = abstractMasterHourServices;

        }

        public ActionResult Index()
        {
            ViewBag.PricePackageId = MasterPricePackageDropdown();
            return View();
        }
        public ActionResult AddPricePackage()
        {
            return View();
        }
        public IList<SelectListItem> MasterPricePackageDropdown()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                PageParam pageParam = new PageParam();
                pageParam.Offset = 0;
                pageParam.Limit = 0;

                AbstractMasterHour abstractMasterHour = new MasterHour();

                var models = abstractMasterHourServices.MasterHour_All(pageParam,abstractMasterHour);

                foreach (var master in models.Values)
                {
                    items.Add(new SelectListItem() { Text = master.Details.ToString(), Value = Convert.ToString(master.Id) });
                }


                return items;
            }
            catch (Exception)
            {
                return items;
            }
        }

        [HttpPost]
        public JsonResult GetPricePackageById(int Id = 0)
        {
            SuccessResult<AbstractPricePackage> successResult = abstractPricePackageServices.PricePackage_ById(Id);
            return Json(successResult,JsonRequestBehavior.AllowGet);
        }
        
        //PricePackage owner all data get
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public JsonResult ViewAllData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, int ForPricePackage = 0)
        //{
        //    {
        //        int totalRecord = 0;
        //        int filteredRecord = 0;

        //        PageParam pageParam = new PageParam();
        //        pageParam.Offset = requestModel.Start;
        //        pageParam.Limit = requestModel.Length;

        //        AbstractPricePackage pricePackage = new PricePackage();

        //        var response = abstractPricePackageServices.spMasterLaptopDescriptipn_All(pageParam, pricePackage);

        //        totalRecord = (int)response.TotalRecords;
        //        filteredRecord = (int)response.TotalRecords;

        //        return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
        //    }
        //}

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult PricePackageUpsert( int Id = 0, int MasterHourId = 0,decimal Price = 0)
        {
            
            PricePackage model = new PricePackage();
            model.Id = Id;
            model.MasterHourId = MasterHourId;
            model.Price = Price;
            model.CreatedBy = ProjectSession.AdminId;
            model.UpdatedBy = ProjectSession.AdminId;

            var result = abstractPricePackageServices.PricePackage_Upsert(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}