using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Flight
    {
        
        public int FlightId { get; set; }
        
        public string FlightNumber { get; set; }
      
        
        public DateTime DepartureUtc { get; set; }
       
        public DateTime ArrivalUtc { get; set; }
       
        public string Status { get; set; }

       




    }
}
