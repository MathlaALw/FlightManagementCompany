using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class AircraftMaintenance
    {
        internal object NextDueDate;

        public int MaintenanceId { get; set; }

       
        public DateTime MaintenanceDate { get; set; }

       

        public string Type { get; set; }

       

        public string Notes { get; set; }

        // // Navigation properties
        // one to many relationship with Aircraft
        // One aircraft can have many maintenance records
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }
        }
}
