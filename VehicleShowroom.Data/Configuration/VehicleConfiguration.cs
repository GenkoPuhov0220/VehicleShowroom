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

            builder
                .HasData(this.SeedVehicle());

        }
        private List<Vehicle> SeedVehicle()
        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
                 new Vehicle
                 {
                     VehicleId = 1,
                     VehicleType = "Car",
                     Make = "BMW",
                     Model = "330D E91",
                     Year = new DateTime(2012, 08, 12),
                     Price = 21500,
                     Color = "White",
                     FuelType = "Disel"
                 },
                 new Vehicle
                 {
                     VehicleId = 2,
                     VehicleType = "Car",
                     Make = "Merces",
                     Model = "e-clas E320CDI",
                     Year = new DateTime(2006, 08, 08),
                     Price = 22500,
                     Color = "Black",
                     FuelType = "Disel"
                 },
                 new Vehicle
                 {
                     VehicleId = 3,
                     VehicleType = "Car",
                     Make = "AUDI",
                     Model = "A8 Long",
                     Year = new DateTime(2022, 10, 15),
                     Price = 150000,
                     Color = "White",
                     FuelType = "Petrol"
                 }
            };

            return vehicles;
        }
    }
}
