using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Aircraft
    {
        
        public int AircraftId { get; set; }

       
        public String TailNumber { get; set; }

        
        public String Model { get; set; }
       
        public int Capacity { get; set; }


      
    }
}
