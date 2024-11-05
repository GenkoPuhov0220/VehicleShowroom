using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants.Truck;
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
             .HasMaxLength(DescriptionMaxLenght);

            builder
                .Property(t => t.ImageUrl)
                .IsRequired();
        }
    }
}
