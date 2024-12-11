using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants;
namespace VehicleShowroom.Data.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.CarId);

            builder
              .Property(c => c.Description)
              .IsRequired()
              .HasMaxLength(CarDescriptionMaxLenght);
   
            builder
                .Property(c => c.Transmission)
                .IsRequired()
                .HasMaxLength(CarTransmissionMaxLenght);
            
            builder
                .HasData(this.SeedCar());
        }
        private List<Car> SeedCar()
        {
            List<Car> cars = new List<Car>()
            {
                new Car
                {
                    CarId = 1,
                    Kilometers = 150000,
                    NumberOfDoors = 4,
                    Description = "Fast and comfort",
                    Transmission = "Automatic",
                    HorsePower = 245,
                    VehicleId = 1
                },
                new Car
                {
                    CarId = 2,
                    Kilometers = 300000,
                    NumberOfDoors = 4,
                    Description = "Lazy car",
                    Transmission = "Automatic",
                    HorsePower = 224,
                    VehicleId = 2
                },
                new Car
                {
                    CarId = 3,
                    Kilometers = 22200,
                    NumberOfDoors= 4,
                    Description = "Luxury car",
                    Transmission = "Automatic",
                    HorsePower = 356,
                    VehicleId = 3
                },
                new Car
                {
                    CarId = 4,
                    Kilometers = 5000,
                    NumberOfDoors = 4,
                    Description = "Powerful and reliable",
                    Transmission = "Automatic",
                    HorsePower = 375,
                    VehicleId = 10
                },
                new Car
                {
                    CarId = 5,
                    Kilometers = 25000,
                    NumberOfDoors = 5,
                    Description = "Spacious and efficient",
                    Transmission = "CVT",
                    HorsePower = 203,
                    VehicleId = 11
                },
                new Car
                {
                    CarId = 6,
                    Kilometers = 10000,
                    NumberOfDoors = 4,
                    Description = "Luxury electric sedan",
                    Transmission = "Automatic",
                    HorsePower = 1020,
                    VehicleId = 12
                },
                new Car
                {
                    CarId = 7,
                    Kilometers = 60000,
                    NumberOfDoors = 4,
                    Description = "Luxury sedan",
                    Transmission = "Automatic",
                    HorsePower = 204,
                    VehicleId = 13
                },
                new Car
                {
                    CarId = 8,
                    Kilometers = 58912,
                    NumberOfDoors = 5,
                    Description = "Off-road capable",
                    Transmission = "Manual",
                    HorsePower = 285,
                    VehicleId = 14
                },
                new Car
                {
                    CarId = 9,
                    Kilometers = 30000,
                    NumberOfDoors = 4,
                    Description = "Compact and efficient",
                    Transmission = "Automatic",
                    HorsePower = 158,
                    VehicleId = 15
                },
                new Car
                {
                    CarId = 10,
                    Kilometers = 5000,
                    NumberOfDoors = 2,
                    Description = "Powerful sports car",
                    Transmission = "Manual",
                    HorsePower = 450,
                    VehicleId = 16
                },
                new Car
                {
                    CarId = 11,
                    Kilometers = 15000,
                    NumberOfDoors = 2,
                    Description = "Stylish and fast",
                    Transmission = "Automatic",
                    HorsePower = 650,
                    VehicleId = 17
                },
                new Car
                {
                    CarId = 12,
                    Kilometers = 20000,
                    NumberOfDoors = 4,
                    Description = "Reliable and affordable",
                    Transmission = "Automatic",
                    HorsePower = 147,
                    VehicleId = 18
                },
                new Car
                {
                    CarId = 13,
                    Kilometers = 10000,
                    NumberOfDoors = 4,
                    Description = "Sporty and compact",
                    Transmission = "Automatic",
                    HorsePower = 186,
                    VehicleId = 19
                },
            };
            return cars;
        }
    }
}
