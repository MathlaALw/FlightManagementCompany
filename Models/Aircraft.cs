using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Aircraft
    {
        [Key]
        public int AircraftId { get; set; }

        [Required]
        public String TailNumber { get; set; }

        [Required]
        [StringLength(50)]
        public String Model { get; set; }
        [Required]
        public int Capacity { get; set; }


    }
}
