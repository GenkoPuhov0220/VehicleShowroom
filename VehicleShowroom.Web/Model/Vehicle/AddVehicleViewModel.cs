
using System.ComponentModel.DataAnnotations;
using static VehicleShowroom.Common.EntityValidationConstants;

namespace VehicleShowroom.Web
{
    public class AddVehicleViewModel
    {
        public int VehicleId { get; set; }
        [Required]
        [MinLength(VehicleTypeMinLenght)]
        [MaxLength(VehicleTypeMaxLenght)]
        public string VehicleType { get; set; } = null!;
        [Required]
        [MinLength(MakeMinLenght)]
        [MaxLength(MakeMaxLenght)]
        public string Make { get; set; } = null!;
        [Required]
        [MinLength(ModelMinLenght)]
        [MaxLength(ModelMaxLenght)]
        public string Model { get; set; } = null!;
        [Required]
        public string Year { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        [Required]
        [MinLength(ColorMinLenght)]
        [MaxLength(ColorMaxLenght)]
        public string Color { get; set; } = null!;
        [Required]
        [MinLength(FuelTypeMinLenght)]
        [MaxLength(FuelTypeMaxLenght)]
        public string FuelType { get; set; } = null!;
        [Required]
        public string ImageUrl { get; set; } = null!;

       //Car
        public int? Kilometers { get; set; }
        public int? NumberOfDoors { get; set; }
        public string? CarDescription { get; set; } 
        public string? CarTransmission { get; set; } 
        public int? CarHorsePower { get; set; }

        //Bus
        public int? Capacity { get; set; }
        public string? BusDescription { get; set; } 
        public string? BusTransmission { get; set; }
        public int? BusHorsePower { get; set; }

        //Motorcycle
        public int? Kw { get; set; }

       //SuperCar
        public string? MaxSpeed { get; set; } 
        public string? Weight { get; set; } 
        public int? SuperCarKilometers { get; set; }
        public int? SuperCarDoors { get; set; }
        public string? SuperCarDescription { get; set; }
        public string? SuperCarTransmission { get; set; }
        public int? SuperCarHorsePower { get; set; }

         //Truck
        public int? CargoCapacity { get; set; }
        public string? EuroNumber { get; set; } 
        public string? TruckDescription { get; set; } 
        public string?TruckTransmission { get; set; }
        public int? TruckHorsePower { get; set; }
    }
}
