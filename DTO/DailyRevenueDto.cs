using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.DTO
{
    public class DailyRevenueDto
    {
        internal decimal CumulativeRevenue;

        public DateTime Date { get; set; }
        public decimal DailyRevenue { get; set; }

    }
}
