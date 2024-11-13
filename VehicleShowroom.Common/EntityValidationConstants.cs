
namespace VehicleShowroom.Common
{
    public static class EntityValidationConstants
    {
        public static class Vehicle
        {
            public const int VehicleTypeMinLenght = 2;
            public const int VehicleTypeMaxLenght = 50;
            public const int MakeMinLenght = 3;
            public const int MakeMaxLenght = 150;
            public const int ModelMinLenght = 3;
            public const int ModelMaxLenght = 150;
            public const int ColorMinLenght = 2;
            public const int ColorMaxLenght = 70;
            public const int FuelTypeMinLenght = 2;
            public const int FuelTypeMaxLenght = 50;
            public const string YearFormating = "MM/dd/yyyy";
        }
        public static class SuperCar
        {
            public const int SuperCarDescriptionMinLenght = 10;
            public const int SuperCarDescriptionMaxLenght = 1000;
            public const int SuperCarTransmissionMinLenght = 10;
            public const int SuperCarTransmissionMaxLenght = 100;
            public const int SuperCarMaxSpeedMinLenght = 2;
            public const int SuperCarMaxSpeedMaxLenght = 600;
            public const int SuperCarWeightMinLenght = 2;
            public const int SuperCarWeightMaxLenght = 1700;
        }
        public static class Car
        {
            public const int CarDescriptionMinLenght = 10;
            public const int CarDescriptionMaxLenght = 1000;
            public const int CarTransmissionMinLenght = 10;
            public const int CarTransmissionMaxLenght = 100;
        }
        public static class Bus
        {
            public const int BusDescriptionMinLenght = 10;
            public const int BusDescriptionMaxLenght = 1000;
            public const int BusTransmissionMinLenght = 10;
            public const int BusTransmissionMaxLenght = 100;
        }
        public static class Truck
        {
            public const int EuroNumberMinLenght = 10;
            public const int EuroNumberMaxLenght = 10;
            public const int TruckDescriptionMinLenght = 10;
            public const int TruckDescriptionMaxLenght = 1000;
            public const int TruckTransmissionMinLenght = 10;
            public const int TruckTransmissionMaxLenght = 100;
        }
        public static class Motorcycle 
        {
            public const int MotorcycleDescriptionMinLenght = 10;
            public const int MotorcycleDescriptionMaxLenght = 1000;
        }


    }
}
