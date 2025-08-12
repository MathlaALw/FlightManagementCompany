using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Aircraft
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AircraftId { get; set; }

        [Required]
        
        // [Index(IsUnique = true)]
        public String TailNumber { get; set; }

        [Required]
        [StringLength(50)]
        public String Model { get; set; }
        [Required]
        public int Capacity { get; set; }


        // navigation properties

        public ICollection<Flight> Flights { get; set; }

        public ICollection<AircraftMaintenance> AircraftMaintenances { get; set; }

    }
}
