
namespace VehicleShowroom.Common
{
    public static class EntityValidationMessages
    {
        //Vehicle
        public const string VehicleTypeMessages = "Vehicle type is required";
        public const string VehicleTypeMinLenghtMessages = "Type must be at least 2 characters long.";
        public const string VehicleTypeMaxLenghtMessages = "Type cannot exceed 50 characters.";

        public const string VehicleMakeMessages = "Make is required.";
        public const string VehicleMakeMinLenghtMessages = "Make must be at least 2 characters long.";
        public const string VehicleMakeMaxLenghtMessages = "Make cannot exceed 150 characters.";

        public const string VehicleModelMessages = "Model is required.";
        public const string VehicleModelMinLenghtMessages = "Model must be at least 2 characters long.";
        public const string VehicleModelMaxLenghtMessages = "Model cannot exceed 150 characters.";

        public const string VehiclePriceMessages = "Price is required.";
       

        public const string VehicleColorMessages = "Color is required.";

        public const string VehicleFuelTypeMessages = "FuelType is required.";

        public const string NotVehicle = "There are currently no such vehicle";
    }
}
