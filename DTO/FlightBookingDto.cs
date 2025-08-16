using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.DTO
{
    public class FlightBookingDto
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public string DepartureAirport { get; set; }  // Airport Name/City
        public string ArrivalAirport { get; set; }    // Airport Name/City
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string SeatNumber { get; set; }        // From Booking

    }
}
