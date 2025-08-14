using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.DTO
{
    public class ConnectionLegDto
    {

        public int FromFlightId { get; set; }
        public DateTime FromArrival { get; set; }
        public int ToFlightId { get; set; }
        public DateTime ToDeparture { get; set; }
        public double HoursBetween { get; set; }
    }
}
