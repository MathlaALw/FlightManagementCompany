using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.DTO
{
    public class ItinSegmentDto // Represents a segment of an itinerary for a flight
    {
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepUtc { get; set; }
        public DateTime ArrUtc { get; set; }
    }
}
