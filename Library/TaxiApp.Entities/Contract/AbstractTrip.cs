using TaxiApp;
using TaxiApp.Entities.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TaxiApp.Entities.Contract
{
    public abstract class AbstractTrip
    {
        public int Id { get; set; }
        public int MasterTripCancelReasonId { get; set; }

        public int TripId { get; set; }
        public int CustomerId { get; set; }
        public int DriverId { get; set; }
        public string TotalTimeInHours { get; set; }

        
        public string AssignedDriverName { get; set; }
        public string CustomerName { get; set; }
        
        public string AssignedDriverMobileNo { get; set; }
        public string AssignedDriverVehicleNo { get; set; }
        public int AssignedId { get; set; }
        public int MasterServiceBaseId { get; set; }
        public int MasterTripTypeId { get; set; }
        public DateTime DropOffDate { get; set; }
        public DateTime DropOffTime { get; set; }
        public string TotalKiloMeters { get; set; }
        public decimal Discount { get; set; }

        public int OTP { get; set; }

        public string PickUpLat { get; set; }
        public string DropOffLat { get; set; }
        public string PickUpLong { get; set; }
        public string DropOffLong { get; set; }
        public decimal DayPrice { get; set; }
        public decimal NightPrice { get; set; }
        public decimal ConvenyenceFee { get; set; }
        public decimal GST { get; set; }
        public decimal TotalEstimateAmount { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime PickUpTime { get; set; }
        public int NoOfPassengers { get; set; }
        public int TripStatusId { get; set; }
        public string PickUpCity { get; set; }
        public string PickUpState { get; set; }
        public int PickUpPinCode { get; set; }
        public string PickUpAddress { get; set; }
        public int PickUpPhoneNumber { get; set; }
        public string DropOffCity { get; set; }
        public string DropOffState { get; set; }
        public int DropOffPinCode { get; set; }
        public string DropOffAddress { get; set; }
        public int DropOffPhoneNumber { get; set; }
        public int TripRatingByCustomer { get; set; }
        public string TripRemarksByCustomer { get; set; }
        public int TripRatingByDriver { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerPinCode { get; set; }
        public string CustomerMobileNo { get; set; }

        public string CustomerState { get; set; }
        public bool IsDeleted { get; set; }
        public int DeletedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public string TripDateFrom { get; set; }
        public string TripDateTo { get; set; }
        public string TripTimeFrom { get; set; }
        public string TripTimeTo { get; set; }
        public string TotalTime { get; set; }


        [NotMapped]
        public string CreatedDateStr => CreatedDate != null ? CreatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string PickUpDateStr => PickUpDate != null ? PickUpDate.ToString("dd-MMM-yyyy") : "-";
        [NotMapped]
        public string PickUpTimeStr => PickUpTime != null ? PickUpTime.ToString("hh:mm tt") : "-";
        [NotMapped]
        public string DropOffDateStr => DropOffDate != null ? DropOffDate.ToString("dd-MMM-yyyy") : "-";
        [NotMapped]
        public string DropOffTimeStr => DropOffTime != null ? DropOffTime.ToString("hh:mm tt") : "-";
        [NotMapped]
        public string UpdatedDateStr => UpdatedDate != null ? UpdatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string DeletedDateStr => DeletedDate != null ? DeletedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
    }
}

