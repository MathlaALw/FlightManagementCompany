using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Passenger
    {
       
        public int PassengerId { get; set; }

       
        public string FullName { get; set; }

        
        public string PassportNo { get; set; }
       

        public string Nationality { get; set; }
        
        public DateTime DOB { get; set; }


        // Navigation property 
        // one to many relationship with Booking
        public ICollection<Booking> Bookings { get; set; }
    }
}
