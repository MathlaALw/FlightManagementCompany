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

        
    }
}
