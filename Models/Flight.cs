using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightId { get; set; }
        [Required]
        public string FlightNumber { get; set; }
        [Required]
        
        public DateTime DepartureUtc { get; set; }
        [Required]
        public DateTime ArrivalUtc { get; set; }
        [Required]
        [EnumDataType(typeof(FlightStatus))]
        public string Status { get; set; }

        // Navigation properties
        [ForeignKey("Aircraft")]
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }

        // one-to-many relationship with Route
        [ForeignKey("Route")]
        public int RouteId { get; set; }
        public Route Route { get; set; }

        // one-to-many relationship with Ticket
        public ICollection<Ticket> Tickets { get; set; }

        // one-to-many relationship with FlightCrew
        public ICollection<FlightCrew> FlightCrews { get; set; }





    }
}
