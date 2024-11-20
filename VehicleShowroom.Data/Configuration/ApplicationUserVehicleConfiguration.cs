using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleShowroom.Data.Models;

namespace VehicleShowroom.Data.Configuration
{
    public class ApplicationUserVehicleConfiguration : IEntityTypeConfiguration<ApplicationUserVehicle>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserVehicle> builder)
        {
            builder
                .HasKey(uv => new { uv.ApplicationUserId, uv.VehicleId });

            builder
                .HasOne(uv => uv.Vehicle)
                .WithMany(uv => uv.UserVehicles)
                .HasForeignKey(uv => uv.VehicleId);

            builder
                .HasOne(uv => uv.ApplicationUser)
                .WithMany(uv => uv.ApplicationUserVehicles)
                .HasForeignKey(uv => uv.ApplicationUserId);
        }
    }
}
