using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.DTO
{
    public class OnTimePerformanceDto
    {
        public int TotalFlights { get; set; }
        public int OnTimeFlights { get; set; }
        public double OnTimePercentage { get; set; }
        public int DelayedFlights { get; set; }
    }
}
