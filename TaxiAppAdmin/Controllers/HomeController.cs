using TaxiAppAdmin.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTables.Mvc;
using TaxiApp.Common;
using TaxiApp.Common.Paging;
using TaxiApp.Entities.Contract;
using TaxiApp.Entities.V1;
using TaxiApp.Services.Contract;
using TaxiAppAdmin.Pages;

namespace TaxiAppAdmin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly AbstractCustomerServices abstractCustomerServices = null;
        private readonly AbstractTripServices abstractTripServices = null;
        private readonly AbstractDriverServices abstractDriverServices = null;

        public HomeController(AbstractCustomerServices abstractCustomerServices, AbstractTripServices abstractTripServices, AbstractDriverServices abstractDriverServices)
        {
            this.abstractCustomerServices = abstractCustomerServices;
            this.abstractTripServices = abstractTripServices;
            this.abstractDriverServices = abstractDriverServices;
        }
        public ActionResult Index()
        {

            //int totaltrip = 0;
            //int totalcustomers = 0;
            //int totaldrivers = 0;
            //int assignedtrips = 0;
            //int unAssignedtrips = 0;
            //int completedtrips = 0;
            ///* int pendingtrips = 0;*/
            //int confirmedtrips = 0;
            //int rejectedtrips = 0;

            //PageParam pageParam = new PageParam();
            //pageParam.Offset = 0;
            //pageParam.Limit = 0;
            //string search = "";

            //Customer customer = new Customer();
            //customer.IsActiveForFilter = 2;
            //customer.Gender = "";
            //var responsemodal = abstractCustomerServices.Customer_All(pageParam, search, customer);
            //totalcustomers = (int)responsemodal.TotalRecords;

            //Driver driver = new Driver();
            //driver.IsActiveForFilter = 2;
            //driver.Gender = "";
            //var responseUserFavourites = abstractDriverServices.Driver_All(pageParam, search, driver);
            //totaldrivers = (int)responseUserFavourites.TotalRecords;

            //Trip trip3 = new Trip();
            //trip3.TripStatusId = 3;
            //var responseTripVisits = abstractTripServices.Trip_All(pageParam, search, trip3);
            //assignedtrips = (int)responseTripVisits.TotalRecords;

            //Trip trip1 = new Trip();
            //trip1.TripStatusId = 1;
            //var responseTripUnVisits = abstractTripServices.Trip_All(pageParam, search, trip1);
            //unAssignedtrips = (int)responseTripUnVisits.TotalRecords;

            //Trip trip = new Trip();
            //trip.TripStatusId = 0;
            //var responseUnAssignedTrips = abstractTripServices.Trip_All(pageParam, search, trip);
            //totaltrip = (int)responseUnAssignedTrips.TotalRecords;

            //Trip rejecttrip = new Trip();
            //rejecttrip.TripStatusId = 2;
            //var responseRejectedTrips = abstractTripServices.Trip_All(pageParam, search, rejecttrip);
            //rejectedtrips = (int)responseRejectedTrips.TotalRecords;

            //Trip confirmtrip = new Trip();
            //confirmtrip.TripStatusId = 4;
            //var responseConfirmedTrips = abstractTripServices.Trip_All(pageParam, search, confirmtrip);
            //confirmedtrips = (int)responseConfirmedTrips.TotalRecords;

            //Trip completetrip = new Trip();
            //completetrip.TripStatusId = 5;
            //var responseCompletedTrips = abstractTripServices.Trip_All(pageParam, search, completetrip);
            //completedtrips = (int)responseCompletedTrips.TotalRecords;


            //ViewBag.TotalTripsCount = totaltrip;
            //ViewBag.TotalCustomersCount = totalcustomers;
            //ViewBag.TotalDriversCount = totaldrivers;
            //ViewBag.AssignedTripsCount = assignedtrips;
            //ViewBag.UnAssignedTripsCount = unAssignedtrips;
            //ViewBag.RejectedTripsCount = rejectedtrips;
            //ViewBag.TotalConfirmedCount = confirmedtrips;
            //ViewBag.TotalCompletedCount = completedtrips;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ViewAllAssignedTripData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string TripDateFrom = "", string TripDateTo = "", string TripTimeFrom = "", string TripTimeTo = "", int TripStatusId = 0)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);

                AbstractTrip Trip = new Trip();
                Trip.TripStatusId = 3;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ViewAllUnAssignedTripData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string TripDateFrom = "", string TripDateTo = "", string TripTimeFrom = "", string TripTimeTo = "", int TripStatusId = 0)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);

                AbstractTrip Trip = new Trip();
                Trip.TripStatusId = 1;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ViewAllRejectedTripData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string TripDateFrom = "", string TripDateTo = "", string TripTimeFrom = "", string TripTimeTo = "", int TripStatusId = 0)
        {
            {

                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);

                AbstractTrip Trip = new Trip();
                Trip.TripStatusId = 2;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ViewAllConfirmedTripData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string TripDateFrom = "", string TripDateTo = "", string TripTimeFrom = "", string TripTimeTo = "", int TripStatusId = 0)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);

                AbstractTrip Trip = new Trip();
                Trip.TripStatusId = 4;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ViewAllCompletedTripData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string TripDateFrom = "", string TripDateTo = "", string TripTimeFrom = "", string TripTimeTo = "", int TripStatusId = 0)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);

                AbstractTrip trip = new Trip();
                trip.TripStatusId = 5;
                trip.TripDateFrom = TripDateFrom;
                trip.TripDateTo = TripDateTo;
                trip.TripTimeFrom = TripTimeFrom;
                trip.TripTimeTo = TripTimeTo;
                var response = abstractTripServices.Trip_All(pageParam, search, trip);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult ActiveInActive(string ri = "MA==")
        {
            int Id = Convert.ToInt32(ConvertTo.Base64Decode(ri));
            SuccessResult<AbstractDriver> result = abstractDriverServices.Driver_ActInAct(Id);
            //result.Item = null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}