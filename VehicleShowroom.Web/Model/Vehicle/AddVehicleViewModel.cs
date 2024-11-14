
using System.ComponentModel.DataAnnotations;
using static VehicleShowroom.Common.EntityValidationConstants.Vehicle;
using static VehicleShowroom.Common.EntityValidationConstants.Car;
using static VehicleShowroom.Common.EntityValidationConstants.Bus;
using static VehicleShowroom.Common.EntityValidationConstants.SuperCar;
using static VehicleShowroom.Common.EntityValidationConstants.Truck;
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
        public DateTime Year { get; set; }
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
        //[Required]
        public int? Kilometers { get; set; }
        //[Required]
        public int? NumberOfDoors { get; set; }
       // [Required]
        //[MinLength(CarDescriptionMinLenght)]
        //[MaxLength(CarDescriptionMaxLenght)]
        public string? CarDescription { get; set; } 
        //[Required]
        //[MinLength(CarTransmissionMinLenght)]
        //[MaxLength(CarTransmissionMaxLenght)]
        public string? CarTransmission { get; set; } 
       // [Required]
        public int? CarHorsePower { get; set; }

        //Bus
       // [Required]
        public int? Capacity { get; set; }
       // [Required]
        //[MinLength(BusDescriptionMinLenght)]
        //[MaxLength(BusDescriptionMaxLenght)]
        public string? BusDescription { get; set; } 
       // [Required]
        //[MinLength(BusTransmissionMinLenght)]
        //[MaxLength(BusTransmissionMaxLenght)]
        public string? BusTransmission { get; set; }
        //[Required]
        public int? BusHorsePower { get; set; }

        //Motorcycle
        public int? Kw { get; set; }

        //SuperCar
       // [Required]
       // [MinLength(SuperCarMaxSpeedMinLenght)]
       // [MaxLength(SuperCarMaxSpeedMaxLenght)]
        public string? MaxSpeed { get; set; } 
        //[Required]
        //[MinLength(SuperCarWeightMinLenght)]
       // [MaxLength(SuperCarWeightMaxLenght)]
        public string? Weight { get; set; } 
        public int? SuperCarKilometers { get; set; }
        public int? SuperCarDoors { get; set; }
        //[Required]
        //[MinLength(SuperCarDescriptionMinLenght)]
       // [MaxLength(SuperCarDescriptionMaxLenght)]
        public string? SuperCarDescription { get; set; }
        //[Required]
        //[MinLength(SuperCarTransmissionMinLenght)]
       // [MaxLength(SuperCarTransmissionMaxLenght)]
        public string? SuperCarTransmission { get; set; }
        public int? SuperCarHorsePower { get; set; }

         //Truck
        public int? CargoCapacity { get; set; }
        //[Required]
        //[MinLength(EuroNumberMinLenght)]
       // [MaxLength(EuroNumberMaxLenght)]
        public string? EuroNumber { get; set; } 
        //[Required]
        //[MinLength(TruckDescriptionMinLenght)]
        //[MaxLength(TruckDescriptionMaxLenght)]
        public string? TruckDescription { get; set; } 
        //[Required]
        //[MinLength(TruckTransmissionMinLenght)]
        //[MaxLength(TruckTransmissionMaxLenght)]
        public string?TruckTransmission { get; set; }
        public int? TruckHorsePower { get; set; }
    }
}
