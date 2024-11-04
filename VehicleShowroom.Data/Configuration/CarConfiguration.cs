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

           // builder
             //   .HasOne(c => c.Vehicle)
              //  .WithMany(c => c.Cars)
              //  .HasForeignKey(c => c.VehicleId);

            builder
              .Property(c => c.Description)
              .IsRequired()
              .HasMaxLength(DescriptionMaxLenght);
            builder
                .Property(c => c.ImageUrl)
                .IsRequired();
        }
    }
}
