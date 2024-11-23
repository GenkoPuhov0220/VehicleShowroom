namespace VehicleShowroom.Web
{
    public class CarDeleteVehicleViewModel
    {
        public int VehicleId { get; set; }
        public string VehicleType { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Year { get; set; } = null;
        public decimal Price { get; set; }
        public string Color { get; set; } = null!;
        public string FuelType { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        public int? CarId { get; set; }
        public int? Kilometers { get; set; }
        public int? NumberOfDoors { get; set; }
        public string? Description { get; set; }
        public string? Transmission { get; set; }
        public int? HorsePower { get; set; }
    }
}
