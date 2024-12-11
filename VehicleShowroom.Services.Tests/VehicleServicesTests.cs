using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Services.Data;
using VehicleShowroom.Services.Data.Interfaces;
using VehicleShowroom.Web;

namespace VehicleShowroom.Services.Tests
{
    [TestFixture]
    public class VehicleServicesTests
    {
        private Mock<VehicleDbContext> mockDbContext;
        private VehicleServices vehicleServices;

        [SetUp]
        public void Setup()
        {
            mockDbContext = new Mock<VehicleDbContext>();
            vehicleServices = new VehicleServices(mockDbContext.Object);
               
        }

        [Test]
        public async Task IndexGetAllVehicle_ReturnNonDeleted()
        {
            // Arrange
            var vehicles = new List<Vehicle>
            {
                new Vehicle { VehicleId = 1, IsDelete = false },
                new Vehicle { VehicleId = 2, IsDelete = false },
                new Vehicle { VehicleId = 3, IsDelete = true } 
            };

            mockDbContext.Setup(db => db.Vehicles).ReturnsDbSet(vehicles);

            // Act
            var result = await vehicleServices.IndexGetAllAsync();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.All(v => v.IsDelete == false));

        }
        [Test]
        public async Task IndexGetAllVehicle_ReturnAreDeleted()
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle { VehicleId = 1, IsDelete = true },
                new Vehicle { VehicleId = 2, IsDelete = true }
            };

            mockDbContext.Setup(db => db.Vehicles).ReturnsDbSet(vehicles);

            // Act
            var result = await vehicleServices.IndexGetAllAsync();

            // Assert
            Assert.AreEqual(0, result.Count());

        }
        [Test]
        public async Task AddVehicleReturnFalseYearIsInvalid()
        {
            // Arrange
            var vehicles = new List<Vehicle>();
            mockDbContext.Setup(db => db.Vehicles).ReturnsDbSet(vehicles);

            var model = new AddVehicleViewModel
            {
                VehicleType = "Car",
                Make = "Toyota",
                Model = "Corolla",
                Year = "InvalidYear",
                Price = 20000,
                Color = "Red",
                FuelType = "Petrol",
                ImageUrl = "http://example.com/image.jpg"
            };

            // Act
            var result = await vehicleServices.AddVehicleAsync(model);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0, vehicles.Count);
        }
       
    }
}