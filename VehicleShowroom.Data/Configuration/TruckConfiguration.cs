using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants;
namespace VehicleShowroom.Data.Configuration
{
    public class TruckConfiguration : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.HasKey(t => t.VehicleId);
            builder
                .Property(t => t.EuroNumber)
                .IsRequired()
                .HasMaxLength(EuroNumberMaxLenght);
            builder
             .Property(t => t.Description)
             .IsRequired()
             .HasMaxLength(TruckDescriptionMaxLenght);
          
            builder
                .Property(c => c.Transmission)
                .IsRequired()
                .HasMaxLength(TruckTransmissionMaxLenght);
          
            builder
                .HasData(this.SeedTrucks());
        }
       private List<Truck> SeedTrucks()
        {
            List<Truck> trucks = new List<Truck>()
            {
               new Truck
               {
                   TruckId = 1,
                   CargoCapacity = 12000,
                   EuroNumber = "Euro 6",
                   Description = "Best truck",
                   HorsePower = 650,
                   Transmission = "Automatic",
                   VehicleId = 6
               },
               new Truck
                {
                    TruckId = 2,
                    CargoCapacity = 14000,
                    EuroNumber = "Euro 6",
                    Description = "Efficient hauler",
                    HorsePower = 750,
                    Transmission = "Manual",
                    VehicleId = 42
                },
                new Truck
                {
                    TruckId = 3,
                    CargoCapacity = 13000,
                    EuroNumber = "Euro 6",
                    Description = "Heavy-duty performer",
                    HorsePower = 700,
                    Transmission = "Automatic",
                    VehicleId = 43
                },
                new Truck
                {
                    TruckId = 4,
                    CargoCapacity = 15000,
                    EuroNumber = "Euro 6",
                    Description = "Long-haul specialist",
                    HorsePower = 800,
                    Transmission = "Automatic",
                    VehicleId = 44
                },
                new Truck
                {
                    TruckId = 5,
                    CargoCapacity = 16000,
                    EuroNumber = "Euro 6",
                    Description = "Reliable and powerful",
                    HorsePower = 850,
                    Transmission = "Manual",
                    VehicleId = 45
                },
                new Truck
                {
                    TruckId = 6,
                    CargoCapacity = 14000,
                    EuroNumber = "Euro 6",
                    Description = "Modern and efficient",
                    HorsePower = 780,
                    Transmission = "Automatic",
                    VehicleId = 46
                },
                new Truck
                {
                    TruckId = 7,
                    CargoCapacity = 12500,
                    EuroNumber = "Euro 5",
                    Description = "Durable and agile",
                    HorsePower = 690,
                    Transmission = "Manual",
                    VehicleId = 47
                },
                new Truck
                {
                    TruckId = 8,
                    CargoCapacity = 13500,
                    EuroNumber = "Euro 6",
                    Description = "Cost-effective",
                    HorsePower = 720,
                    Transmission = "Automatic",
                    VehicleId = 48
                },
                new Truck
                {
                    TruckId = 9,
                    CargoCapacity = 14500,
                    EuroNumber = "Euro 6",
                    Description = "High-performance",
                    HorsePower = 760,
                    Transmission = "Manual",
                    VehicleId = 49
                },
                new Truck
                {
                    TruckId = 10,
                    CargoCapacity = 15500,
                    EuroNumber = "Euro 6",
                    Description = "Future-ready",
                    HorsePower = 810,
                    Transmission = "Automatic",
                    VehicleId = 50
                }
            };

            return trucks;
        }
    }
}
