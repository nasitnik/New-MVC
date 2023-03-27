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
    public abstract class AbstractMasterTripCancelReason
    {
        public int Id { get; set; }
        public int MasterTripCancelReasonId { get; set; }
        public int CustomerId { get; set; }
        public int DriverId { get; set; }
        public string Name { get; set; }
    }
}

