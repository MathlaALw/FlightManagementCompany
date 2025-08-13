using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Booking
    {

        
        public int BookingId { get; set; }

        
        public string BookingRef { get; set; }

       

        public DateTime BookingDate { get; set; }

       
        public BookingStatus Status { get; set; }

        // Navigation property
        // one to many relationship with Ticket
        // One booking can have many tickets
        public ICollection<Ticket> Tickets { get; set; }

        // one to many relationship with Passenger
        // One booking can be associated with many passengers
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
    }
}
