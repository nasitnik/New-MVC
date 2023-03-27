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
    public class DriverController : BaseController
    {
        private readonly AbstractDriverServices abstractDriverServices = null;
        private readonly AbstractTripServices abstractTripServices = null;
        private readonly AbstractTripStatusLoggerServices abstractTripStatusLoggerServices = null;

        public DriverController(AbstractDriverServices abstractDriverServices , AbstractTripServices abstractTripServices,AbstractTripStatusLoggerServices abstractTripStatusLoggerServices)
        {
            this.abstractDriverServices = abstractDriverServices;
            this.abstractTripServices = abstractTripServices;
            this.abstractTripStatusLoggerServices = abstractTripStatusLoggerServices;
        }

        //Driver Index action
        public ActionResult Index()
        {
            return View();
        }

        //Driver Trip action
        public ActionResult TripDetails(string DriverId = "MjIy")
        {
            ViewBag.DriverId = Convert.ToInt32(ConvertTo.Base64Decode(DriverId));
            return View();
        }


        //Salon owner all data get
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ViewAllData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel , bool IsActive = true)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);

                    AbstractDriver Driver = new Driver();
                Driver.IsActive = IsActive;
                var response = abstractDriverServices.Driver_All(pageParam, search, Driver);

                    totalRecord = (int)response.TotalRecords;
                    filteredRecord = (int)response.TotalRecords;

                    return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }

        //Salon owner all Trip list
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ViewAllDataTrips([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel , int DriverId = 0 )
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);
                AbstractTrip Trip = new Trip();
                Trip.DriverId = DriverId;
                var response = abstractTripServices.Trip_All(pageParam, search,Trip);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }

        //Driver status actinact
        [HttpPost]
        public JsonResult ActiveInActive(string ri = "MA==")
        {
            int Id = Convert.ToInt32(ConvertTo.Base64Decode(ri));
            SuccessResult<AbstractDriver> result = abstractDriverServices.Driver_ActInAct(Id);
            //result.Item = null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Driver status actinact
        [HttpPost]
        public JsonResult ApprovedUnApprovedIdProof(string ri = "MA==")
        {
            int Id = Convert.ToInt32(ConvertTo.Base64Decode(ri));
            SuccessResult<AbstractDriver> result = abstractDriverServices.Driver_IdProofApproved(Id);
            result.Item = null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //Driver status actinact
        [HttpPost]
        public JsonResult ApprovedUnApprovedDrivingLicence(string ri = "MA==")
        {
            int Id = Convert.ToInt32(ConvertTo.Base64Decode(ri));
            SuccessResult<AbstractDriver> result = abstractDriverServices.Driver_DriveingLicenceApproved(Id);
            result.Item = null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //Salon change status 
        [HttpPost]
        public JsonResult ChangeStatusTrip(string TripId = "MA==", int statusId = 0)
        {
            AbstractTripStatusLogger TripStatusLogger = new TripStatusLogger();
            TripStatusLogger.Id = Convert.ToInt32(ConvertTo.Base64Decode(TripId));
            TripStatusLogger.StatusId = statusId;
            SuccessResult<AbstractTripStatusLogger> result = abstractTripStatusLoggerServices.Trip_UpsertStatus(TripStatusLogger);
            result.Item = null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetLatLongById(int Id = 0)
        {
            SuccessResult<AbstractDriver> result = abstractDriverServices.Driver_ById(Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}