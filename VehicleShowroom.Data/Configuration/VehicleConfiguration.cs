using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants.Vehicle;
namespace VehicleShowroom.Data.Configuration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v => v.VehicleId);

            builder
                 .HasMany(v => v.Cars)
                 .WithOne(c => c.Vehicle)
                 .HasForeignKey(c => c.VehicleId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(v => v.Buses)
                .WithOne(b => b.Vehicle)
                .HasForeignKey(b => b.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(v => v.Trucks)
                .WithOne(t => t.Vehicle)
                .HasForeignKey(t => t.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(v => v.Motorcycles)
                .WithOne(m => m.Vehicle)
                .HasForeignKey(m => m.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(v => v.Price)
                .HasColumnType("decimal(18,2)");

            builder
                .Property(v => v.VehicleType)
                .IsRequired()
                .HasMaxLength(VehicleTypeMaxLenght);

            builder
                .Property(v => v.Make)
                .IsRequired()
                .HasMaxLength(MakeMaxLenght);

            builder
                .Property(v => v.Model)
                .IsRequired()
                .HasMaxLength(ModelMaxLenght);

            builder
                .Property(v => v.Color)
                .IsRequired()
                .HasMaxLength(ColorMaxLenght);

            builder
                .Property(v => v.FuelType)
                .IsRequired()
                .HasMaxLength(FuelTypeLenght);

        }
    }
}
