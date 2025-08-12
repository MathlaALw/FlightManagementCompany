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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BaggageId { get; set; }
        [Required]
        public decimal WeightKg { get; set; }

        [Required]
        public string TagNumber { get; set; }

        // Navigation properties
        // one-to-many relationship with Ticket
        [ForeignKey("Ticket")]
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
    }
}
