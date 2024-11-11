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
                     FuelType = "Diesel"
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
                     FuelType = "Diesel"
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
                 },
                  new Vehicle
                 {
                     VehicleId = 4,
                     VehicleType = "Bus",
                     Make = "Volvo",
                     Model = "9900 DD",
                     Year = new DateTime(2022, 9, 10),
                     Price = 198222,
                     Color = "Brown",
                     FuelType = "Diesel"
                 },
                  new Vehicle
                  {
                     VehicleId = 5,
                     VehicleType = "Motorcycle",
                     Make = "Honda",
                     Model = "450",
                     Year = new DateTime(2022, 9, 10),
                     Price = 19800,
                     Color = "red",
                     FuelType = "Petrol"
                  },
                  new Vehicle
                  {
                     VehicleId = 6,
                     VehicleType = "Truck",
                     Make = "Man",
                     Model = "TGC",
                     Year = new DateTime(2016, 9, 11),
                     Price = 198000,
                     Color = "Orange",
                     FuelType = "Diesel"
                  },
                  new Vehicle
                  {
                     VehicleId = 7,
                     VehicleType = "Supercar",
                     Make = "Ferrari",
                     Model = "F8",
                     Year = new DateTime(2022, 9, 11), 
                     Price= 450000,
                     Color = "Crimson Red",
                     FuelType = "Petrol"
                  },
                  new Vehicle
                  {
                     VehicleId= 8,
                     VehicleType ="Supercar",
                     Make = "Pagani",
                     Model = "Huayra",
                     Year = new DateTime(2022, 01, 09),
                     Price = 3400000,
                     Color ="Carbon Fiber Black",
                     FuelType = "Petrol"
                  },
                  new Vehicle
                  {
                      VehicleId = 9,
                      VehicleType= "Supercar",
                      Make= "Lamborghini",
                      Model= "Aventador",
                      Year = new DateTime(2023, 10, 09),
                      Price =550000,
                      Color = "Lamborghini Yellow",
                      FuelType = "Petrol"
                  }
            };

            return vehicles;
        }
    }
}
