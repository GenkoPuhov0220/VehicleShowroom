﻿namespace VehicleShowroom.Web
{
    using System.ComponentModel.DataAnnotations;
    using static VehicleShowroom.Common.EntityValidationMessages;

    public class TruckEditViewModel
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

        public int TruckId { get; set; }
        public int CargoCapacity { get; set; }
        public string EuroNumber { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Transmission { get; set; } = null!;
        public int HorsePower { get; set; }
    }
}
