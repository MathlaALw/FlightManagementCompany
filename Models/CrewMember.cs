using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class CrewMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CrewId { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EnumDataType(typeof(CrewRole))]
        public string Role { get; set; }

        [Required]
        [StringLength(20)]
        public string LicenseNo { get; set; }

        // Navigation properties

        // one-to-many relationship with FlightCrew
        public ICollection<FlightCrew> FlightCrews { get; set; }
    }
}
