using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants.Bus;
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
                }
            };
            return buses;
        }
    }
}
