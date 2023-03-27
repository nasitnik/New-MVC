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
    public class TripController : BaseController
    {
        private readonly AbstractDriverServices abstractDriverServices = null;
        private readonly AbstractTripServices abstractTripServices = null;
        private readonly AbstractTripStatusLoggerServices abstractTripStatusLoggerServices = null;

        public TripController(AbstractDriverServices abstractDriverServices , AbstractTripServices abstractTripServices,AbstractTripStatusLoggerServices abstractTripStatusLoggerServices)
        {
            this.abstractDriverServices = abstractDriverServices;
            this.abstractTripServices = abstractTripServices;
            this.abstractTripStatusLoggerServices = abstractTripStatusLoggerServices;
        }

        //Driver Index action
        public ActionResult Index()
        {
            ViewBag.Driver = MasterDriverDropdown();

            return View();
        }
        //Salon change status 
        [HttpPost]
        public JsonResult AssignedDriver(int TripId = 0, int DriverId = 0)
        {
            AbstractTrip trip = new Trip();
            trip.DriverId = DriverId;
            trip.TripId = TripId;
            trip.CreatedBy = ProjectSession.AdminId;
            SuccessResult<AbstractTrip> result = abstractTripServices.Driver_Assigned(trip);
            result.Item = null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public IList<SelectListItem> MasterDriverDropdown()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                PageParam pageParam = new PageParam();
                pageParam.Offset = 0;
                pageParam.Limit = 0;
                Driver driver = new Driver();
                driver.IsActive = true;
                driver.Gender = "";

                var models = abstractDriverServices.Driver_All(pageParam, "", driver);

                foreach (var master in models.Values)
                {
                    items.Add(new SelectListItem() { Text = master.FirstName + " " + master.LastName.ToString(), Value = Convert.ToString(master.Id) });
                }


                return items;
            }
            catch (Exception)
            {
                return items;
            }
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
        public JsonResult ViewAllData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel ,int DriverId = 0, int CustomerId = 0, string TripDateFrom = "", string TripDateTo = "", string TripTimeFrom = "", string TripTimeTo = "", int TripStatusId = 0)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);

                AbstractTrip Trip = new Trip();
                Trip.TripStatusId = TripStatusId;
                Trip.CustomerId = CustomerId;
                Trip.DriverId = DriverId;
                Trip.TripDateFrom = TripDateFrom;
                Trip.TripDateTo = TripDateTo;
                Trip.TripTimeFrom = TripTimeFrom;
                Trip.TripTimeTo = TripTimeTo;

                var response = abstractTripServices.Trip_All(pageParam, search, Trip);

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
        //[HttpPost]
        //public JsonResult GetLatLongById(int Id = 0)
        //{
        //    SuccessResult<AbstractPromoCode> successResult = abstractPromoCodeServices.PromoCode_ById(Id);
        //    return Json(successResult, JsonRequestBehavior.AllowGet);
        //}
        //Driver status actinact
        [HttpPost]
        public JsonResult ActiveInActive(string ri = "MA==")
        {
            int Id = Convert.ToInt32(ConvertTo.Base64Decode(ri));
            SuccessResult<AbstractDriver> result = abstractDriverServices.Driver_ActInAct(Id);
            //result.Item = null;
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

    }
}