using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Airport
    {
       
        public int AirportID { get; set; }

        public string IATA { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        
        public string Country { get; set; }

        
        public string TimeZone { get; set; }


        // Navigation properties
        // one to many relationship with Route
        // One airport can be the origin or destination of many routes
        public ICollection<Route> OriginRoutes { get; set; }
        public  ICollection<Route> DestinationRoutes { get; set; }
       

    }
}
