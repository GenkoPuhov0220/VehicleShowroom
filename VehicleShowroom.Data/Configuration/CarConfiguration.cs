using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants.Car;
namespace VehicleShowroom.Data.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.CarId);

            builder
              .Property(c => c.Description)
              .IsRequired()
              .HasMaxLength(DescriptionMaxLenght);
            builder
                .Property(c => c.ImageUrl)
                .IsRequired();
            builder
                .HasData(this.SeedCar());
        }
        private List<Car> SeedCar()
        {
            List<Car> cars = new List<Car>()
            {
                new Car
                {
                    CarId = 1,
                    Kilometers = 150000,
                    NumberOfDoors = 4,
                    Description = "Fast and comfort",
                    ImageUrl = "https://d3ok64umd5ysj.cloudfront.net/dev/assets/images/gallery/alpine-white-e91-bmw-335i-wagon-estate-forgestar-f14-bagged-stance-c.jpg",
                    VehicleId = 1
                },
                new Car
                {
                    CarId = 2,
                    Kilometers = 300000,
                    NumberOfDoors = 4,
                    Description = "Lazy car",
                    ImageUrl = "https://garrybase.com/images/full/uploads/2021/AWEsL34IiTvPxXp2k8M7JcCdJrsZKJEiqimwpWpi.jpg",
                    VehicleId = 2
                },
                new Car
                {
                    CarId = 3,
                    Kilometers = 22200,
                    NumberOfDoors= 4,
                    Description = "Luxury car",
                    ImageUrl = "https://frankfurt.apollo.olxcdn.com/v1/files/r8lz4w93so09-BG/image",
                    VehicleId = 3
                }
            };
            return cars;
        }
    }
}
