using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants.Motorcycle;
namespace VehicleShowroom.Data.Configuration
{
    public class MotorcycleConfiguration : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder.HasKey(m => m.MotorcycleId);

            builder
                .HasData(this.SeedMotorcycles());
        }
        private List<Motorcycle> SeedMotorcycles()
        {
            List<Motorcycle> motorcycles = new List<Motorcycle>()
            {
                new Motorcycle
                {
                    MotorcycleId = 1,
                    Kw = 45,
                    VehicleId = 5,
                }
            };
            return motorcycles;
        }
    }
}
