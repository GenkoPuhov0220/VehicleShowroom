using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleShowroom.Data.Models
{
    public class Bus
    {
        [Key]
        public int BusId { get; set; }
        public  int Capacity { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        public int HorsePower { get; set; }
        [Required]
        public string Transmission { get; set; } = null!;
        public bool IsDelete { get; set; }
        [Required]
        [ForeignKey(nameof(VehicleId))]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;

    }
}
