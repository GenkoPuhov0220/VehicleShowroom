using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants.SuperCar;
namespace VehicleShowroom.Data.Configuration
{
    public class SuperCarConfiguration : IEntityTypeConfiguration<SuperCar>
    {
        public void Configure(EntityTypeBuilder<SuperCar> builder)
        {
            builder.HasKey(c => c.SuperCarId);

            builder
              .Property(c => c.Description)
              .IsRequired()
              .HasMaxLength(DescriptionMaxLenght);
            builder
                .Property(c => c.ImageUrl)
                .IsRequired();
            builder
                .Property(c => c.Transmission)
                .IsRequired()
                .HasMaxLength(TransmissionMaxLenght);
            builder
               .Property(c => c.MaxSpeed)
               .IsRequired()
               .HasMaxLength(MaxSpeedMaxLenght);
            builder
               .Property(c => c.Weight)
               .IsRequired()
               .HasMaxLength(WeightMaxLenght);

        }
    }
}
