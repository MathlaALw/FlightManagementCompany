using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Ticket
    {

      
        public int TicketId { get; set; }

        public string SeatNumber { get; set; }

       

        public decimal Fare { get; set; }
        public bool CheckedIn {  get; set; }

        // Navigation properties
        // one to many relationship with Booking
        // One ticket can be associated with one booking
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        // one to many relationship with Flight
        // One ticket can be associated with one flight
        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        // one to many relationship with Baggage
        // One ticket can have many baggage items
        public ICollection<Baggage> Baggages { get; set; }



    }
}
