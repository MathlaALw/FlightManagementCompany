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
        
        public int RouteId { get; set; }

      
        public int DistanceKm { get; set; }


        
       


        // Navigation properties
        // one to many relationship with Flight
        // One route can have many flights
        public ICollection<Flight> Flights { get; set; }

        // one to many relationship with Airport
        // One route can have one origin and one destination airport
        public int OriginAirportId { get; set; } 
        public Airport OriginAirport { get; set; } 

        public int DestinationAirportId { get; set; }
        public Airport DestinationAirport { get; set; }

    }
}
