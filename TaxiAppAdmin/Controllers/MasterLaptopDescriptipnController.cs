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
    public class MasterLaptopDescriptipnController : BaseController
    {
        private readonly AbstractMasterLaptopDescriptipnServices abstractMasterLaptopDescriptipnServices = null;
        private readonly AbstractMasterHourServices abstractMasterHourServices = null;


        public MasterLaptopDescriptipnController(AbstractMasterLaptopDescriptipnServices abstractMasterLaptopDescriptipnServices, AbstractMasterHourServices abstractMasterHourServices)
        {
            this.abstractMasterLaptopDescriptipnServices = abstractMasterLaptopDescriptipnServices;
            this.abstractMasterHourServices = abstractMasterHourServices;

        }

        public ActionResult Index()
        {
            //ViewBag.MasterLaptopDescriptipnId = MasterMasterLaptopDescriptipnDropdown();
            return View();
        }
        public ActionResult AddMasterLaptopDescriptipn()
        {
            return View();
        }
        //public IList<SelectListItem> MasterMasterLaptopDescriptipnDropdown()
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    try
        //    {
        //        PageParam pageParam = new PageParam();
        //        pageParam.Offset = 0;
        //        pageParam.Limit = 0;

        //        AbstractMasterHour abstractMasterHour = new MasterHour();

        //        var models = abstractMasterHourServices.MasterHour_All(pageParam,abstractMasterHour);

        //        foreach (var master in models.Values)
        //        {
        //            items.Add(new SelectListItem() { Text = master.Details.ToString(), Value = Convert.ToString(master.Id) });
        //        }


        //        return items;
        //    }
        //    catch (Exception)
        //    {
        //        return items;
        //    }
        //}

        [HttpPost]
        public JsonResult GetMasterLaptopDescriptipnById(int Id = 0)
        {
            SuccessResult<AbstractMasterLaptopDescriptipn> successResult = abstractMasterLaptopDescriptipnServices.MasterLaptopDescriptipn_ById(Id);
            return Json(successResult,JsonRequestBehavior.AllowGet);
        }
        
        //MasterLaptopDescriptipn owner all data get
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ViewAllData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, AbstractMasterLaptopDescriptipn abstractMasterLaptopDescriptipn)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;


                var response = abstractMasterLaptopDescriptipnServices.MasterLaptopDescriptipn_All(pageParam,abstractMasterLaptopDescriptipn);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult MasterLaptopDescriptipnUpsert( int Id = 0, int MasterHourId = 0,decimal Price = 0)
        {
            
            MasterLaptopDescriptipn model = new MasterLaptopDescriptipn();
            model.Id = Id;
            model.MasterHourId = MasterHourId;
            //model.Price = Price;
            model.CreatedBy = ProjectSession.AdminId;
            model.UpdatedBy = ProjectSession.AdminId;

            var result = abstractMasterLaptopDescriptipnServices.MasterLaptopDescriptipn_Upsert(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}