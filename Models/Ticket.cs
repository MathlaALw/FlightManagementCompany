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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }

        [Required]
        public string SeatNumber { get; set; }

        [Required]

        public decimal Fare { get; set; }
        public bool CheckedIn {  get; set; }

        // Navigation properties

        // one-to-many relationship with Flight
        [ForeignKey("Flight")]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        // one-to-many relationship with Booking
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        // one-to-many relationship with Ticket
        public ICollection<Ticket> Tickets { get; set; }
        
    }
}
