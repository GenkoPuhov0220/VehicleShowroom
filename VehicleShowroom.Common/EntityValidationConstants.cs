
namespace VehicleShowroom.Common
{
    public static class EntityValidationConstants
    {
        public static class Vehicle
        {
            public const int VehicleTypeMaxLenght = 50;
            public const int MakeMaxLenght = 150;
            public const int ModelMaxLenght = 150;
            public const int ColorMaxLenght = 70;
            public const int FuelTypeLenght = 50;
            public const string YearFormating = "MM/dd/yyyy";
        }
        public static class Customer
        {
            public const int FirstNameMaxLenght = 50;
            public const int LastNameMaxLenght = 50;
            public const int PhoneNumberMaxLenght = 70;

        }
        public static class Car
        {
            public const int DescriptionMaxLenght = 1000;
            public const int TransmissionMaxLenght = 100;
        }
        public static class Bus
        {
            public const int DescriptionMaxLenght = 1000;
            public const int TransmissionMaxLenght = 100;
        }
        public static class Truck
        {
            public const int EuroNumberMaxLenght = 10;
            public const int DescriptionMaxLenght = 1000;
            public const int TransmissionMaxLenght = 100;
        }
        public static class Motorcycle 
        {
            public const int DescriptionMaxLenght = 1000;
        }


    }
}
