using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants;
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
                .HasMany(v => v.SuperCars)
                .WithOne(m => m.Vehicle)
                .HasForeignKey(m => m.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .Property(v => v.IsDelete)
                .HasDefaultValue(false);

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
                .HasMaxLength(FuelTypeMaxLenght);
            builder
               .Property(b => b.ImageUrl)
               .IsRequired();
            builder
              .Property(b => b.Year)
              .IsRequired();

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
                     FuelType = "Diesel",
                     ImageUrl = "https://d3ok64umd5ysj.cloudfront.net/dev/assets/images/gallery/alpine-white-e91-bmw-335i-wagon-estate-forgestar-f14-bagged-stance-c.jpg"
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
                     FuelType = "Diesel",
                     ImageUrl = "https://garrybase.com/images/full/uploads/2021/AWEsL34IiTvPxXp2k8M7JcCdJrsZKJEiqimwpWpi.jpg"
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
                     FuelType = "Petrol",
                     ImageUrl = "https://frankfurt.apollo.olxcdn.com/v1/files/r8lz4w93so09-BG/image"

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
                     FuelType = "Diesel",
                     ImageUrl = "https://www.lectura-specs.bg/models/renamed/detail_max_retina/avtobusi-za-turisticeski-avtobusi-9700-dd-volvo-buses.jpg"
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
                     FuelType = "Petrol",
                      ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRTUkEaOz8kEyPTk3ansNtGsVrlm4zR0PBuMQ&s"
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
                     FuelType = "Diesel",
                     ImageUrl = "https://www.hobbies.co.uk/media/catalog/product/cache/084ca19aa5ee10728706fd297654f270/1/5/156325man_1.jpg"
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
                     FuelType = "Petrol",
                     ImageUrl = "https://ferrari-cdn.thron.com/delivery/public/thumbnail/ferrari/e9677798-7b8b-42b1-becf-387235c70b2a/bocxuw/std/488x325/e9677798-7b8b-42b1-becf-387235c70b2a?scalemode=auto"
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
                     FuelType = "Petrol",
                     ImageUrl= "https://assets.newatlas.com/dims4/default/7afc3de/2147483647/strip/true/crop/1024x576+0+47/resize/1200x675!/quality/90/?url=http%3A%2F%2Fnewatlas-brightspot.s3.amazonaws.com%2Farchive%2Fpagani-huayra-supercar.jpg"
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
                      FuelType = "Petrol",
                      ImageUrl = "https://www.exoticcarhacks.com/wp-content/uploads/2024/02/uFcbfiuL-scaled.jpeg"
                  }
            };

            return vehicles;
        }
    }
}
