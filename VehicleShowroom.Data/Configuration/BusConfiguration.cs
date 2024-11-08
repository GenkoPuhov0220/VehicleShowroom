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
              .HasMaxLength(DescriptionMaxLenght);
            builder
                .Property(b => b.ImageUrl)
                .IsRequired();
            builder
                .Property(c => c.Transmission)
                .IsRequired()
                .HasMaxLength(TransmissionMaxLenght);

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
                    ImageUrl = "https://www.lectura-specs.bg/models/renamed/detail_max_retina/avtobusi-za-turisticeski-avtobusi-9700-dd-volvo-buses.jpg",
                    VehicleId = 4
                }
            };
            return buses;
        }
    }
}
