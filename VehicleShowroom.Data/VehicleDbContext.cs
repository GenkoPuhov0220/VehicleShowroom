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
        public virtual DbSet<Customer> Customers {  get; set; } = null!; 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Seed vehicle 
            modelBuilder.Entity<Vehicle>().HasData(
                 new Vehicle
                 {
                     VehicleId = 1,
                     VehicleType = "Car",
                     Make = "BMW",
                     Model = "330D E91",
                     Year = new DateTime(2012, 08, 12),
                     Price = 21500,
                     Color = "White",
                     FuelType = "Disel"
                 },
                 new Vehicle
                 {
                     VehicleId = 2,
                     VehicleType = "Car",
                     Make = "Merces",
                     Model = "e-clas E320CDI",
                     Year = new DateTime(2006, 08, 08),
                     Price = 22500,
                     Color = "Black",
                     FuelType = "Disel"
                 });
        }
    }
}
