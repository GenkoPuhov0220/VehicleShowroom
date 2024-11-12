using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleShowroom.Data.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public int Kilometers { get; set; }
        public int NumberOfDoors { get; set; }
        [Required]
        public string Description { get; set; } = null!;
       
        [Required]
        public string Transmission { get; set; } = null!;
        public int HorsePower { get; set; } 
        [Required]
        [ForeignKey(nameof(VehicleId))]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
    }
}
