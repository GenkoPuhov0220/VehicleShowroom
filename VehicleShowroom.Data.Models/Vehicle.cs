using System.ComponentModel.DataAnnotations;

namespace VehicleShowroom.Data.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string VehicleType { get; set; } = null!;
        [Required]
        public string Make { get; set; } = null!;
        [Required]
        public string Model { get; set; } = null!;
        [Required]
        public DateTime Year { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Color { get; set; } = null!;
        [Required]
        public string FuelType { get; set; } = null!;

    }
}
