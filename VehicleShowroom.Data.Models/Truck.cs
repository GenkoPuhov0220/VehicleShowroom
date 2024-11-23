using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleShowroom.Data.Models
{
    public class Truck
    {
        [Key]
        public int TruckId { get; set; }
        public int CargoCapacity { get; set; }
        [Required]
        public string EuroNumber { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
 
        [Required]
        public string Transmission { get; set; } = null!;
        public int HorsePower { get; set; }
        public bool IsDelete { get; set; }
        [Required]
        [ForeignKey(nameof(VehicleId))]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;

    }
}
