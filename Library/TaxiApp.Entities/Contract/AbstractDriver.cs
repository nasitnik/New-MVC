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
    public abstract class AbstractDriver
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int IsIdProofApproved { get; set; }
        public int IsActiveForFilter { get; set; }
        public int IsDrivingLicenceApproved { get; set; }
        public int Type { get; set; }
        public string IsActve { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MsgRec { get; set; }
        public string MobileNo { get; set; }
        public bool IsMobileVerified { get; set; }
        public bool IsResetPassword { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string ProfilePicture { get; set; }
        public string LicenceNo { get; set; }
        public string PucNo { get; set; }
        public string LICNo  { get; set; }
        public string VehicleNo { get; set; }
        public string ChasisNo { get; set; }
        public string Password { get; set; }
        public string CPassword { get; set; }
        public decimal DriverRatings { get; set; }
        public string BloodGroup { get; set; }
        public float DISTANCE { get; set; }
        public int CustomerId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
        public int TripCount { get; set; }
        public string MsgJsonRes { get; set; }

        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public bool IsOnline { get; set; }
        public int DeletedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IdProof { get; set; }
        public string LiveLong { get; set; }
        public string LiveLat { get; set; }
        public string DrivingLicence { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int PinCode { get; set; }
        public string Address { get; set; }
        //public double LiveLat { get; set; }
        //public double LiveLong { get; set; }

        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }

        [NotMapped]
        public string CreatedDateStr => CreatedDate != null ? CreatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string UpdatedDateStr => UpdatedDate != null ? UpdatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string DeletedDateStr => DeletedDate != null ? DeletedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
    }
}


