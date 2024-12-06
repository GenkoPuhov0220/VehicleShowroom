using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Services.Data;

namespace VehicleShowroom.Services.Tests
{
    [TestFixture]
    public class Tests
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
    }
}