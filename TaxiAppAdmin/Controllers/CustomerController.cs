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
    public class CustomerController : BaseController
    {
        private readonly AbstractCustomerServices abstractCustomerServices = null;
        private readonly AbstractTripServices abstractTripServices = null;
        private readonly AbstractTripStatusLoggerServices abstractTripStatusLoggerServices = null;
        private readonly AbstractDriverServices  abstractDriverServices = null;

        public CustomerController(AbstractCustomerServices abstractCustomerServices , AbstractTripServices abstractTripServices,AbstractTripStatusLoggerServices abstractTripStatusLoggerServices, AbstractDriverServices abstractDriverServices)
        {
            this.abstractCustomerServices = abstractCustomerServices;
            this.abstractTripServices = abstractTripServices;
            this.abstractTripStatusLoggerServices = abstractTripStatusLoggerServices;
            this.abstractDriverServices = abstractDriverServices;
        }

        //Customer Index action
        public ActionResult Index()
        {
            return View();
        }

        //Customer Trip action
        //public ActionResult TripDetails(string CustomerId = "MjIy")
        //{
        //    ViewBag.CustomerId = Convert.ToInt32(ConvertTo.Base64Decode(CustomerId));
        //    ViewBag.Driver = MasterDriverDropdown();
        //       return View();
        //}
        //public IList<SelectListItem> MasterDriverDropdown()
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    try
        //    {
        //        PageParam pageParam = new PageParam();
        //        pageParam.Offset = 0;
        //        pageParam.Limit = 0;
        //        Driver driver = new Driver();


        //        var models = abstractDriverServices.Driver_All(pageParam, "", driver);

        //        foreach (var master in models.Values)
        //        {
        //            items.Add(new SelectListItem() { Text = master.FirstName+" " +master.LastName.ToString(), Value = Convert.ToString(master.Id) });
        //        }


        //        return items;
        //    }
        //    catch (Exception)
        //    {
        //        return items;
        //    }
        //}

        ////Salon owner all data get
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public JsonResult ViewAllData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel ,  int CustomerId = 0,string Gender = "",int IsActiveForFilter = 0)
        //{
        //    {
        //        int totalRecord = 0;
        //        int filteredRecord = 0;

        //        PageParam pageParam = new PageParam();
        //        pageParam.Offset = requestModel.Start;
        //        pageParam.Limit = requestModel.Length;

        //        string search = Convert.ToString(requestModel.Search.Value);

        //            AbstractCustomer Customer = new Customer();
        //        Customer.CustomerId = CustomerId;
        //        Customer.IsActiveForFilter = IsActiveForFilter;
        //        Customer.Gender = Gender;
        //        var response = abstractCustomerServices.Customer_All(pageParam, search, Customer);

        //            totalRecord = (int)response.TotalRecords;
        //            filteredRecord = (int)response.TotalRecords;

        //            return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
        //    }
        //}

        ////Salon owner all Trip list
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public JsonResult ViewAllDataTrips([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel , int CustomerId = 0,int TripStatusId = 0)
        //{
        //    {
        //        int totalRecord = 0;
        //        int filteredRecord = 0;

        //        PageParam pageParam = new PageParam();
        //        pageParam.Offset = requestModel.Start;
        //        pageParam.Limit = requestModel.Length;

        //        string search = Convert.ToString(requestModel.Search.Value);
        //        AbstractTrip Trip = new Trip();
        //        Trip.CustomerId = CustomerId;
        //        Trip.TripStatusId = TripStatusId;
        //        var response = abstractTripServices.Trip_All(pageParam, search,Trip);

        //        totalRecord = (int)response.TotalRecords;
        //        filteredRecord = (int)response.TotalRecords;

        //        return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
        //    }
        //}

        ////Customer status actinact
        //[HttpPost]
        //public JsonResult ActiveInActive(string ri = "MA==")
        //{
        //    int Id = Convert.ToInt32(ConvertTo.Base64Decode(ri));
        //    SuccessResult<AbstractCustomer> result = abstractCustomerServices.Customer_ActInAct(Id);
        //    //result.Item = null;
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        ////Driver status actinact
        //[HttpPost]
        //public JsonResult ApprovedUnApprovedIdProof(string ri = "MA==")
        //{
        //    int Id = Convert.ToInt32(ConvertTo.Base64Decode(ri));
        //    SuccessResult<AbstractCustomer> result = abstractCustomerServices.Customer_IdProofApproved(Id);
        //    result.Item = null;
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        ////Customer status actinact
        //[HttpPost]
        //public JsonResult ApprovedUnApprovedRcCard(string ri = "MA==")
        //{
        //    int Id = Convert.ToInt32(ConvertTo.Base64Decode(ri));
        //    SuccessResult<AbstractCustomer> result = abstractCustomerServices.Customer_RcCardApproved(Id);
        //    result.Item = null;
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        ////Salon change status 
        //[HttpPost]
        //public JsonResult ChangeStatusTrip(string TripId = "MA==", int statusId = 0)
        //{
        //    AbstractTripStatusLogger TripStatusLogger = new TripStatusLogger();
        //    TripStatusLogger.Id = Convert.ToInt32(ConvertTo.Base64Decode(TripId));
        //    TripStatusLogger.StatusId = statusId;
        //    SuccessResult<AbstractTripStatusLogger> result = abstractTripStatusLoggerServices.Trip_UpsertStatus(TripStatusLogger);
        //    result.Item = null;
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
       

    }
}