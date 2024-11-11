using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants.SuperCar;
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
              .HasMaxLength(DescriptionMaxLenght);
            builder
                .Property(c => c.ImageUrl)
                .IsRequired();
            builder
                .Property(c => c.Transmission)
                .IsRequired()
                .HasMaxLength(TransmissionMaxLenght);
            builder
               .Property(c => c.MaxSpeed)
               .IsRequired()
               .HasMaxLength(MaxSpeedMaxLenght);
            builder
               .Property(c => c.Weight)
               .IsRequired()
               .HasMaxLength(WeightMaxLenght);
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
                    ImageUrl = "https://ferrari-cdn.thron.com/delivery/public/thumbnail/ferrari/e9677798-7b8b-42b1-becf-387235c70b2a/bocxuw/std/488x325/e9677798-7b8b-42b1-becf-387235c70b2a?scalemode=auto",
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
                    ImageUrl= "https://assets.newatlas.com/dims4/default/7afc3de/2147483647/strip/true/crop/1024x576+0+47/resize/1200x675!/quality/90/?url=http%3A%2F%2Fnewatlas-brightspot.s3.amazonaws.com%2Farchive%2Fpagani-huayra-supercar.jpg",
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
                   ImageUrl = "https://www.exoticcarhacks.com/wp-content/uploads/2024/02/uFcbfiuL-scaled.jpeg",
                   VehicleId = 9
                }
            };
            return superCars;
        }
    }
}
