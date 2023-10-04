using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApptmentmentScheduler.Models.Models
{
    public class Appointment
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]  
        public string? Name { get; set; }

        public string? Description { get; set; }   
        [Required]  
        public DateTime DateTime { get; set; }
        
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }  

    }
}
