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
                }
            };
            return cars;
        }
    }
}
