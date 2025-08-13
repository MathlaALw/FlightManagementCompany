using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Baggage
    {
        public int BaggageId { get; set; }
       
        public decimal WeightKg { get; set; }

        
        public string TagNumber { get; set; }

        
    }
}
