using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.DTO
{
    public class RouteSummary
    {
        public int RouteId { get; set; }
        public string OriginIata { get; set; } = "";
        public string DestinationIata { get; set; } = "";
        public int FlightsCount { get; set; }
    }
}
