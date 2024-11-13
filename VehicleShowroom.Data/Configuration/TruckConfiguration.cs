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
             .HasMaxLength(TruckDescriptionMaxLenght);
          
            builder
                .Property(c => c.Transmission)
                .IsRequired()
                .HasMaxLength(TruckTransmissionMaxLenght);
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
                   VehicleId = 6
               }
            };

            return trucks;
        }
    }
}
