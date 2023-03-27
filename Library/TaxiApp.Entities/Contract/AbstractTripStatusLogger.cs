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
    public abstract class AbstractTripStatusLogger
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public int StatusId { get; set; }
        public int PreviousStatusId { get; set; }
        public int CurrentStatusId { get; set; }
        
        public DateTime CreatedDate { get; set; }
      

        [NotMapped]
        public string CreatedDateStr => CreatedDate != null ? CreatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
       
    }
}

