
using System.ComponentModel.DataAnnotations;
namespace VehicleShowroom.Web
{
    public class CarDetailsViewModel
    {
        //Vehicle
        public int VehicleId { get; set; }
        public string VehicleType { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Year { get; set; } = null!;
        public decimal Price { get; set; }
        public string Color { get; set; } = null!;
        public string FuelType { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        //Car
        public int Kilometers { get; set; }
        public int NumberOfDoors { get; set; }
        public string CarDescription { get; set; } = null!;
        public string? CarTransmission { get; set; }
        public int? CarHorsePower { get; set; }
    }
}
