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
    public abstract class AbstractCustomer
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Otp { get; set; }
        public bool IsIdProofApproved { get; set; }
        public int IsRcApproved { get; set; }
        public string FirstName { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerState { get; set; }
        public string RcCard { get; set; }
        public int TripCount { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public bool IsResetPassword { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string DOB { get; set; }
        public string ProfilePicture { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int IsActiveForFilter { get; set; }
        public int Type { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int DeletedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public string IdProof { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int PinCode { get; set; }
        public string  Address { get; set; }

        [NotMapped]
        public string CreatedDateStr => CreatedDate != null ? CreatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string UpdatedDateStr => UpdatedDate != null ? UpdatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string DeletedDateStr => DeletedDate != null ? DeletedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
    }
}

