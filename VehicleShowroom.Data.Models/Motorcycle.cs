using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleShowroom.Data.Models
{
    public class Motorcycle
    {
        [Key]
        public int MotorcycleId { get; set; }
        public int Kw { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public string ImageUrl { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(VehicleId))]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
    }
}
