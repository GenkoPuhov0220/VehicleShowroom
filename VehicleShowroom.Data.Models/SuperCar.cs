using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleShowroom.Data.Models
{
    public class SuperCar
    {
        [Key]
        public int SuperCarId { get; set; }
        public int Kilometers { get; set; }
        public int NumberOfDoors { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public string ImageUrl { get; set; } = null!;
        [Required]
        public string Transmission { get; set; } = null!;
        public int HorsePower { get; set; }
        [Required]
        public string MaxSpeed { get; set; } = null!;
        [Required]
        public string Weight { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(VehicleId))]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
    }
}
