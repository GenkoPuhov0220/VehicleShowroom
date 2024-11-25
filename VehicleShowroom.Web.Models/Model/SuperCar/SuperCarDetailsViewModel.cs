namespace VehicleShowroom.Web
{
    public class SuperCarDetailsViewModel
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

        //Super Car
        public int Kilometers { get; set; }
        public int NumberOfDoors { get; set; }
        public string Description { get; set; } = null!;
        public string Transmission { get; set; } = null!;
        public int HorsePower { get; set; }
        public string MaxSpeed { get; set; } = null!;
        public string Weight { get; set; } = null!;
    }
}
