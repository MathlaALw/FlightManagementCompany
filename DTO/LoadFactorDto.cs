using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.DTO
{
    public class LoadFactorDto
    {
        public string FlightNumber { get; set; }
        public decimal LoadFactor { get; set; } // percentage
    }
}
