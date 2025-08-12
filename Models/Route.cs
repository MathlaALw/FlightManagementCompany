using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Route
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RouteId { get; set; }

        [Required]
        public int DistanceKm { get; set; }

        // navigation properties
        // one to one relationship with Airport for departure and arrival airports
        [ForeignKey("DepartureAirportId")] // specifying the foreign key
        public Airport DepartureAirport { get; set; } // navigation property


        [ForeignKey("ArrivalAirportId")] // specifying the foreign key
        public Airport ArrivalAirport { get; set; } // navigation property

        // one to many relationship with Flight
        public ICollection<Flight> Flights { get; set; } // navigation property for flights associated with this route




    }
}
