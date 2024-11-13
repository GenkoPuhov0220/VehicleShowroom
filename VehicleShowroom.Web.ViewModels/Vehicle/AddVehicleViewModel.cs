


namespace VehicleShowroom.Web.ViewModels.Vehicle
{
    public class AddVehicleViewModel
    {
            public int VehicleId { get; set; }
            public string VehicleType { get; set; } = null!;
            public string Make { get; set; } = null!;
            
            public string Model { get; set; } = null!;
            
            public DateTime Year { get; set; }
            
            public decimal Price { get; set; }
            
            public string Color { get; set; } = null!;
            
            public string FuelType { get; set; } = null!;
            
            public string ImageUrl { get; set; } = null!;

            // Car-specific properties
            public int? Kilometers { get; set; }
            public int? NumberOfDoors { get; set; }
            public string? CarDescription { get; set; }
            public string? CarTransmission { get; set; }
            public int? CarHorsePower { get; set; }

            // Bus-specific properties
            public int? Capacity { get; set; }
            public string? BusDescription { get; set; }
            public string? BusTransmission { get; set; }
            public int? BusHorsePower { get; set; }

            // Motorcycle-specific properties
            public int? Kw { get; set; }

            // SuperCar-specific properties
            public string? MaxSpeed { get; set; }
            public string? Weight { get; set; }
            public int? SuperCarKilometers { get; set; }
            public int? SuperCarDoors { get; set; }
            public string? SuperCarDescription { get; set; }
            public string? SuperCarTransmission { get; set; }
            public int? SuperCarHorsePower { get; set; }

            // Truck-specific properties
            public int? CargoCapacity { get; set; }
            public string? EuroNumber { get; set; }
            public string? TruckDescription { get; set; }
            public string? TruckTransmission { get; set; }
            public int? TruckHorsePower { get; set; }

    }
}
