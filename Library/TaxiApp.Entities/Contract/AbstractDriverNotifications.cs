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
    public abstract class AbstractDriverNotifications
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int CustomerId { get; set; }
        public int TripId { get; set; }
        public string Message { get; set; }
        public string TotalTimeInHours { get; set; }

        
        public bool IsRead { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        [NotMapped]
        public string CreatedDateStr => CreatedDate != null ? CreatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
    }
}

