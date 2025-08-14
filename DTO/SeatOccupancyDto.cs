using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.DTO
{
    public class SeatOccupancyDto
    {
        public string AircraftTail { get; set; }
        public string SeatNumber { get; set; }
        public int TimesOccupied { get; set; }
    }
}
