using System.ComponentModel.DataAnnotations;
namespace VehicleShowroom.Web
{
    using static VehicleShowroom.Common.EntityValidationMessages;
    public class CarEditViewModel
    {
        public int VehicleId { get; set; }

        [Required(ErrorMessage = VehicleTypeMessages)]
        public string VehicleType { get; set; } = null!;

        [Required(ErrorMessage = VehicleMakeMessages)]
        public string Make { get; set; } = null!;

        [Required(ErrorMessage = VehicleModelMessages)]
        public string Model { get; set; } = null!;

        [Required]
        public string Year { get; set; } = null!;

        [Required(ErrorMessage = VehiclePriceMessages)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = VehicleColorMessages)]
        public string Color { get; set; } = null!;

        [Required(ErrorMessage = VehicleFuelTypeMessages)]
        public string FuelType { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        //Car
        public int CarId { get; set; }
        public int Kilometers { get; set; }
        public int NumberOfDoors { get; set; }
        public string? Description { get; set; }
        public string? Transmission { get; set; }
        public int HorsePower { get; set; }
    }
}
