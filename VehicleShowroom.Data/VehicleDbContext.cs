using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VehicleShowroom.Data.Models;

namespace VehicleShowroom.Data
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext()
        {
            
        }

        public VehicleDbContext(DbContextOptions options) 
            : base(options) 
        {

        }

        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
