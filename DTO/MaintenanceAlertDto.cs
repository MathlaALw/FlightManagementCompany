using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.DTO
{
    public class MaintenanceAlertDto
    {

      
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public string AircraftTail { get; set; }

        public DateTime LastMaintenance { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public DateTime NextMaintenanceDueDate { get; set; }
        public bool IsDueForMaintenance { get; set; }
    }
    }
