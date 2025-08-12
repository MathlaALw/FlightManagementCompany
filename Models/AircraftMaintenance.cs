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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaintenanceId { get; set; }

        [Required]
        public DateTime MaintenanceDate { get; set; }

        [Required]

        public string Type { get; set; }

        [Required]

        public string Notes { get; set; }

        // Navigation properties
        [ForeignKey("Aircraft")]
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }
    }
}
