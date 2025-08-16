using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.DTO
{
    public class BaggageOverweightDto
    {

        
        public int TicketId { get; set; } // Ticket ID
        public string PassengerName { get; set; } // Passenger Full Name
        public double TotalBaggageWeight { get; set; } // Total baggage weight
    }
}
