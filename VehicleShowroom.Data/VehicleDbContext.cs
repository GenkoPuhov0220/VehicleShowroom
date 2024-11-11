using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VehicleShowroom.Data.Models;

namespace VehicleShowroom.Data
{
    public class VehicleDbContext : IdentityDbContext
    {

        public VehicleDbContext()
        {
            
        }

        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) 
            : base(options) 
        {

        }

        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Bus> Buses { get; set; } = null!;
        public virtual DbSet<Motorcycle> Motorcycles { get; set; } = null!;
        public virtual DbSet<Truck> Trucks { get; set; } = null!;
        public virtual DbSet<SuperCar> SuperCars { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
