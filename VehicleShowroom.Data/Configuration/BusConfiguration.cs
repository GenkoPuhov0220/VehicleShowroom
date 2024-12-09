using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants;
namespace VehicleShowroom.Data.Configuration
{
    public class BusConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(b => b.BusId);

            builder
              .Property(b => b.Description)
              .IsRequired()
              .HasMaxLength(BusDescriptionMaxLenght);
            builder
                .Property(c => c.Transmission)
                .IsRequired()
                .HasMaxLength(BusTransmissionMaxLenght);
         
            builder
                .HasData(this.SeedBus());
        }
        private List<Bus> SeedBus()
        {
            List<Bus> buses = new List<Bus>()
            {
                new Bus
                {
                    BusId = 1,
                    Capacity = 66,
                    Transmission = "Automatic",
                    HorsePower = 445,
                    Description = "Volvo 9700 DD is an extremely flexible double decker that offers impressive capacity and possibilities for different kinds of operations.",
                    VehicleId = 4
                },
                new Bus
                {
                    BusId = 2,
                    Capacity = 66,
                    Transmission = "Automatic",
                    HorsePower = 445,
                    Description = "Volvo 9700 DD is an extremely flexible double decker that offers impressive capacity and possibilities for different kinds of operations.",
                    VehicleId = 36
                },
                new Bus
                {
                    BusId = 3,
                    Capacity = 55,
                    Transmission = "Automatic",
                    HorsePower = 420,
                    Description = "Mercedes-Benz Tourismo is a luxurious coach with great fuel efficiency and comfort.",
                    VehicleId = 37
                },
                new Bus
                {
                    BusId = 4,
                    Capacity = 53,
                    Transmission = "Manual",
                    HorsePower = 410,
                    Description = "Scania Interlink HD is a reliable bus designed for long-distance travel.",
                    VehicleId = 38
                },
                new Bus
                {
                    BusId = 5,
                    Capacity = 50,
                    Transmission = "Automatic",
                    HorsePower = 430,
                    Description = "MAN Lion's Coach is a high-performance coach with excellent safety features.",
                    VehicleId = 39
                },
                new Bus
                {
                    BusId = 6,
                    Capacity = 45,
                    Transmission = "Automatic",
                    HorsePower = 400,
                    Description = "Iveco Crossway offers great versatility and efficiency for urban and suburban travel.",
                    VehicleId = 40
                },
                new Bus
                {
                    BusId = 7,
                    Capacity = 72,
                    Transmission = "Automatic",
                    HorsePower = 450,
                    Description = "Setra S 531 DT is a modern double-decker with exceptional capacity and comfort.",
                    VehicleId = 41
                }
            };
            return buses;
        }
    }
}
