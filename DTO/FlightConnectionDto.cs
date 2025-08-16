using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.DTO
{
    public class FlightConnectionDto
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }  // From Flight
        public DateTime ArrivalTime { get; set; }    // From Flight
        public string SeatNumber { get; set; }      // From Booking
        public int TicketNumber { get; set; }    // From Ticket 
    }
}
