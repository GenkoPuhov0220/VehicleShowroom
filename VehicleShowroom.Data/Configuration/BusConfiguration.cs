using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants.Bus;
namespace VehicleShowroom.Data.Configuration
{
    public class BusConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(b => b.BusId);

            //builder
             //  .HasOne(b => b.Vehicle)
             //  .WithMany(v => v.Buses)
             //  .HasForeignKey(b => b.VehicleId);

            builder
              .Property(b => b.Description)
              .IsRequired()
              .HasMaxLength(DescriptionMaxLenght);
            builder
                .Property(b => b.ImageUrl)
                .IsRequired();
        }
    }
}
