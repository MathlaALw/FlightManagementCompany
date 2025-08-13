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
        
        public int FlightId { get; set; }
        
        public string FlightNumber { get; set; }
      
        
        public DateTime DepartureUtc { get; set; }
       
        public DateTime ArrivalUtc { get; set; }
       
        public string Status { get; set; }



        // Navigation properties
        // one to many relationship with Ticket
        // One flight can have many tickets
        public ICollection<Ticket> Tickets { get; set; }

        // one to many relationship with FlightCrew
        // One flight can have many crew members
        public ICollection<FlightCrew> FlightCrew { get; set; }

        // one to many relationship with Aircraft
        // One flight can be assigned to one aircraft
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }

        // one to many relationship with Route
        // One flight can be assigned to one route
        public int RouteId { get; set; }
        public Route Route { get; set; }


    }
}
