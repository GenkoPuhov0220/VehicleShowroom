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
                },
                new SuperCar
                {
                    SuperCarId = 4,
                    Kilometers = 3000,
                    NumberOfDoors = 2,
                    Description = "The Huracán EVO features a naturally aspirated 5.2 L V10 engine producing 640 hp and 600 Nm of torque.",
                    Transmission = "7-Speed Automatic",
                    HorsePower = 640,
                    MaxSpeed = "325",
                    Weight = "1382",
                    VehicleId = 20
                },
                new SuperCar
                {
                    SuperCarId = 5,
                    Kilometers = 500,
                    NumberOfDoors = 2,
                    Description = "The Bugatti Chiron boasts an 8.0 L quad-turbocharged W16 engine with 1,479 hp and 1,600 Nm of torque.",
                    Transmission = "7-Speed Dual-Clutch",
                    HorsePower = 1479,
                    MaxSpeed = "420",
                    Weight = "1995",
                    VehicleId = 21
                },
                new SuperCar
                {
                    SuperCarId = 6,
                    Kilometers = 12000,
                    NumberOfDoors = 2,
                    Description = "Powered by a 4.0 L twin-turbocharged V8 engine, the McLaren 720S produces 710 hp and 770 Nm of torque.",
                    Transmission = "7-Speed Dual-Clutch",
                    HorsePower = 710,
                    MaxSpeed = "341",
                    Weight = "1283",
                    VehicleId = 22
                },
                new SuperCar
                {
                    SuperCarId = 7,
                    Kilometers = 8000,
                    NumberOfDoors = 2,
                    Description = "The 911 Turbo S comes with a 3.8 L twin-turbocharged flat-six engine, producing 640 hp and 800 Nm of torque.",
                    Transmission = "8-Speed PDK",
                    HorsePower = 640,
                    MaxSpeed = "330",
                    Weight = "1640",
                    VehicleId = 23
                },
                new SuperCar
                {
                    SuperCarId = 8,
                    Kilometers = 1000,
                    NumberOfDoors = 2,
                    Description = "The Valkyrie has a 6.5 L naturally aspirated V12 engine paired with an electric motor, producing a combined output of 1160 hp.",
                    Transmission = "7-Speed Single Clutch",
                    HorsePower = 1160,
                    MaxSpeed = "402",
                    Weight = "1130",
                    VehicleId = 24
                },
                new SuperCar
                {
                    SuperCarId = 9,
                    Kilometers = 200,
                    NumberOfDoors = 2,
                    Description = "The Jesko Absolut is powered by a 5.0 L twin-turbocharged V8 engine producing 1600 hp with E85 fuel.",
                    Transmission = "9-Speed Koenigsegg Light Speed Transmission",
                    HorsePower = 1600,
                    MaxSpeed = "483",
                    Weight = "1320",
                    VehicleId = 25
                },
            };
            return superCars;
        }
    }
}
