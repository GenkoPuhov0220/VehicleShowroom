namespace VehicleShowroom.Web
{
    public class TruckDeleteViewModel
    {
        public int VehicleId { get; set; }
        public string VehicleType { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Year { get; set; } = null!;
        public decimal Price { get; set; }
        public string Color { get; set; } = null!;
        public string FuelType { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        //Truck
        public int TruckId { get; set; }
        public int CargoCapacity { get; set; }
        public string EuroNumber { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Transmission { get; set; } = null!;
        public int HorsePower { get; set; }
    }
}
