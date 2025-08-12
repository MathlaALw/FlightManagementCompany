using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Airport
    {
        [Key]
        public int AirportID { get; set; }

        [Required]
        [StringLength(3,MinimumLength =3)] // IATA codes are Exactly 3 letters
        public string IATA { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        public string TimeZone { get; set; }
    }
}
