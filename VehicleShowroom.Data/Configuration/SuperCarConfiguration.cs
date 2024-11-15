using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants;
namespace VehicleShowroom.Data.Configuration
{
    public class SuperCarConfiguration : IEntityTypeConfiguration<SuperCar>
    {
        public void Configure(EntityTypeBuilder<SuperCar> builder)
        {
            builder.HasKey(c => c.SuperCarId);

            builder
              .Property(c => c.Description)
              .IsRequired()
              .HasMaxLength(SuperCarDescriptionMaxLenght);
            builder
                .Property(c => c.Transmission)
                .IsRequired()
                .HasMaxLength(SuperCarTransmissionMaxLenght);
            builder
               .Property(c => c.MaxSpeed)
               .IsRequired()
               .HasMaxLength(SuperCarMaxSpeedMaxLenght);
            builder
               .Property(c => c.Weight)
               .IsRequired()
               .HasMaxLength(SuperCarWeightMaxLenght);
            builder
                .HasData(this.SeedSuperCar());
        }
        private List<SuperCar> SeedSuperCar()
        {
            List<SuperCar> superCars = new List<SuperCar>()
            {
                new SuperCar
                {
                    SuperCarId = 1,
                    Kilometers = 8500,
                    NumberOfDoors = 2,
                    Description = "The F8 Tributo uses the same engine from the 488 Pista, a 3.9 L twin-turbocharged V8 engine with a power output of 720 PS (530 kW; 710 hp) at 8000 rpm and 770 N⋅m (568 lb⋅ft) of torque at 3250 rpm",
                    Transmission = "Dual-Clutch Automatic",
                    HorsePower = 710,
                    MaxSpeed = "350",
                    Weight = "1400",
                    VehicleId = 7
                },
                new SuperCar
                {
                    SuperCarId = 2,
                    Kilometers = 1500,
                    NumberOfDoors = 2,
                    Description = "The Pagani Huayra is a masterpiece of automotive engineering, renowned for its breathtaking design and performance. With an aerodynamic, lightweight body crafted from carbon-titanium, it achieves exceptional speed and agility. The Huayra’s performance is complemented by luxurious Italian craftsmanship and cutting-edge technology, making it a unique blend of art and science on wheels.",
                    Transmission = "7-Speed Sequential Manual",
                    HorsePower = 791,
                    MaxSpeed = "383",
                    Weight = "1350",
                    VehicleId = 8
                },
                new SuperCar
                {
                   SuperCarId = 3,
                   Kilometers = 3200,
                   NumberOfDoors = 2,
                   Description = "The Lamborghini Aventador is an iconic supercar that combines Lamborghini's signature aggressive design with world-class performance. Equipped with a naturally aspirated V12 engine, it delivers a raw and thrilling driving experience. The Aventador is known for its sharp lines, scissor doors, and a commanding presence, making it a favorite among supercar enthusiasts.",
                   Transmission = "7-Speed Automated Manual (ISR)",
                   HorsePower = 769,
                   MaxSpeed = "355",
                   Weight = "1575",
                   VehicleId = 9
                }
            };
            return superCars;
        }
    }
}
