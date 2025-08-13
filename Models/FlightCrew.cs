using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class FlightCrew
    {

        public string RoleOnFlight { get; set; }

        // Navigation properties
        // one to many relationship with Flight
        // One flight can have many crew members
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        // one to many relationship with CrewMember
        // One crew member can be assigned to many flights
        public int CrewId { get; set; }
        public CrewMember CrewMember { get; set; }
    }
}
