
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleShowroom.Data.Models
{
    public class VehicleImages
    {
        public int VehicleImagesId { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [ForeignKey(nameof(VehicleId))]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
    }
}
