using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class CrewMember
    {
       
        public int CrewId { get; set; }
        
        public string FullName { get; set; }

        
        public CrewRole Role { get; set; }

        
        public string? LicenseNo { get; set; } // optional field --  ? -> indicates that this field can be null

        // Navigation property to link to FlightCrew
        // one to many relationship with FlightCrew
        // One crew member can be assigned to many flights
        public ICollection<FlightCrew> FlightCrews { get; set; }

    }
}
