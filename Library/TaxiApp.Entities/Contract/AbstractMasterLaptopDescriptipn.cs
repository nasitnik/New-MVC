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
    public abstract class AbstractMasterLaptopDescriptipn
    {
        public int Id { get; set; }
        public int Laptop { get; set; }
        public int MasterHourId { get; set; }
        public decimal IsActive { get;set;}
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public string LaptopCompany { get; set; }
        public string LaptopProcessor { get; set; }
        public string LaptopGeneration { get; set; }
        public string LaptopRam { get; set; }
        public string LaptopHdd { get; set; }
        public string LaptopSsd { get; set; }
        public string LaptopScreen { get; set; }
       
        [NotMapped]
        public string CreatedDateStr => CreatedDate != null ? CreatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string UpdatedDateStr => UpdatedDate != null ? UpdatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";


    }
}

