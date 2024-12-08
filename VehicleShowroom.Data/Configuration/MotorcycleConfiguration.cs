using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants;
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
                },
                new Motorcycle
                {
                    MotorcycleId = 2,
                    Kw = 73,
                    VehicleId = 26
                },
                new Motorcycle
                {
                    MotorcycleId = 3,
                    Kw = 147,
                    VehicleId = 27
                },
                new Motorcycle
                {
                    MotorcycleId = 4,
                    Kw = 110,
                    VehicleId = 28
                },
                new Motorcycle
                {
                    MotorcycleId = 5,
                    Kw = 155,
                    VehicleId = 29
                },
                new Motorcycle
                {
                    MotorcycleId = 6,
                    Kw = 207,
                    VehicleId = 30
                },
                new Motorcycle
                {
                    MotorcycleId = 7,
                    Kw = 90,
                    VehicleId = 31
                },
                new Motorcycle
                {
                    MotorcycleId = 8,
                    Kw = 123,
                    VehicleId = 32
                },
                new Motorcycle
                {
                    MotorcycleId = 9,
                    Kw = 105,
                    VehicleId = 33
                },
                new Motorcycle
                {
                    MotorcycleId = 10,
                    Kw = 119,
                    VehicleId = 34
                },
                new Motorcycle
                {
                    MotorcycleId = 11,
                    Kw = 100,
                    VehicleId = 35
                }
            };
            return motorcycles;
        }
    }
}
