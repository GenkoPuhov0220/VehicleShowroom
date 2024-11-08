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
            builder
                .Property(c => c.Transmission)
                .IsRequired()
                .HasMaxLength(TransmissionMaxLenght);
            builder
                .HasData(this.SeedTrucks());
        }
       private List<Truck> SeedTrucks()
        {
            List<Truck> trucks = new List<Truck>()
            {
               new Truck
               {
                   TruckId = 1,
                   CargoCapacity = 12000,
                   EuroNumber = "Euro 6",
                   Description = "Best truck",
                   HorsePower = 650,
                   Transmission = "Automatic",
                   ImageUrl = "https://www.hobbies.co.uk/media/catalog/product/cache/084ca19aa5ee10728706fd297654f270/1/5/156325man_1.jpg",
                   VehicleId = 6
               }
            };

            return trucks;
        }
    }
}
