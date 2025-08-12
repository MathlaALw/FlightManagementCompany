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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        public string PassportNo { get; set; }
        [Required]

        public string Nationality { get; set; }
        [Required]
        public DateTime DOB { get; set; }

        // Navigation properties

        // one-to-many relationship with Booking
        public ICollection<Booking> Bookings { get; set; }
    }
}
