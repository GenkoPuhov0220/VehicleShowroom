using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleShowroom.Data.Models;
using static VehicleShowroom.Common.EntityValidationConstants.Vehicle;
namespace VehicleShowroom.Data.Configuration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v => v.Id);

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
           .HasMaxLength(FuelTypeLenght);
        }
    }
}
