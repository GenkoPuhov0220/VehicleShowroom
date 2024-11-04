using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleShowroom.Data.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(VehicleId))]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;

    }
}
