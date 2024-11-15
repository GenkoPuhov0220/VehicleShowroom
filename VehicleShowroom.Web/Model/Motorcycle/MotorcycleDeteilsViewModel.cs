namespace VehicleShowroom.Web
{
    public class MotorcycleDeteilsViewModel
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
        //Motorcycle
        public int Kw { get; set; }


    }
}

