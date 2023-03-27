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
    public abstract class AbstractFaq
    {
        public int Id { get; set; }
        
        public string Question { get; set; }
        public string Answer { get; set; }
     
        public int ForFaq { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public int DeletedBy { get; set; }


        [NotMapped]
        public string CreatedDateStr => CreatedDate != null ? CreatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string UpdatedDateStr => UpdatedDate != null ? UpdatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string DeletedDateStr => DeletedDate != null ? DeletedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";

    }
}

