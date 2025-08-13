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

        // Navigation properties
        // one to many relationship with Ticket
        // One baggage can be associated with one ticket
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
