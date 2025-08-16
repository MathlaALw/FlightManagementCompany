using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.DTO
{
    public class PassengerConnectionDto
    {
        public int PassengerId { get; set; }
        public string Name { get; set; }
        public List<FlightBookingDto> ConnectingFlights { get; set; }
    }
}
