using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Services.Data;
using VehicleShowroom.Services.Data.Interfaces;
using VehicleShowroom.Web;

namespace VehicleShowroom.Services.Tests
{
    [TestFixture]
    public class BusServicesTests
    {
        private Mock<VehicleDbContext> mockDbContext;
        private VehicleServices vehicleServices;
        private BusServices busServices;

        private DbContextOptions<VehicleDbContext> CreateInMemoryDbOptions()
        {
            return new DbContextOptionsBuilder<VehicleDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [SetUp]
        public void Setup()
        {
            mockDbContext = new Mock<VehicleDbContext>();
            vehicleServices = new VehicleServices(mockDbContext.Object);
            busServices = new BusServices(mockDbContext.Object);
        }
        [Test]
        public async Task GetAllVehicle_ReturnVehicleTypeBuses()
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                     VehicleType = "Car",
                     Make = "BMW",
                     Model = "330D E91",
                     Year = new DateTime(2012, 08, 12),
                     Price = 21500,
                     Color = "White",
                     FuelType = "Diesel",
                     ImageUrl = "https://d3ok64umd5ysj.cloudfront.net/dev/assets/images/gallery/alpine-white-e91-bmw-335i-wagon-estate-forgestar-f14-bagged-stance-c.jpg",
                     IsDelete = true
                },
                new Vehicle {

                     VehicleType = "Bus",
                     Make = "Mercedes",
                     Model = "Sprinter",
                     Year = new DateTime(2006, 08, 08),
                     Price = 22500,
                     Color = "White",
                     FuelType = "Diesel",
                     ImageUrl = "https://d2e5b8shawuel2.cloudfront.net/vehicle/267639/hlv/original.jpg",
                     IsDelete = false
                },
                new Vehicle {

                     VehicleType = "Bus",
                     Make = "Man",
                     Model = "Lion's Coach",
                     Year = new DateTime(2022, 10, 15),
                     Price = 1500000,
                     Color = "White",
                     FuelType = "Diesel",
                     ImageUrl = "https://www.plantmachineryvehicles.com/cloud/2021/07/08/MAN-Lions-Coach-2017.jpg",
                     IsDelete = false
                }
            };
            mockDbContext.Setup(db => db.Vehicles).ReturnsDbSet(vehicles);
            var result = await busServices.GetAllBusesAsync();
            Assert.IsTrue(result.All(v => v.IsDelete == false));
        }

        [Test]
        public async Task GetBusesDetails_ReturnsCorrectBusDetails_WhenBusesExists()
        {

            var options = CreateInMemoryDbOptions();
            var Id = 1;
            using (var context = new VehicleDbContext(options))
            {

                var vehicle = new Vehicle
                {
                    VehicleId = Id,
                    VehicleType = "Bus",
                    Make = "Man",
                    Model = "Lion's Coach",
                    Year = new DateTime(2022, 10, 15),
                    Price = 1500000,
                    Color = "White",
                    FuelType = "Diesel",
                    ImageUrl = "https://www.plantmachineryvehicles.com/cloud/2021/07/08/MAN-Lions-Coach-2017.jpg"
                };

                var bus = new Bus
                {
                    Vehicle = vehicle,
                    Description = "Low mileage, excellent condition",
                    Transmission = "Automatic",
                    HorsePower = 203,
                    Capacity = 55,
                    IsDelete = false,
                    VehicleId = Id
                };

                await context.Buses.AddAsync(bus);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new BusServices(context);

                var result = await service.GetBusDetailsAsync(Id);

                Assert.NotNull(result);
                Assert.AreEqual(Id, result.VehicleId);
                Assert.AreEqual("Bus", result.VehicleType);
                Assert.AreEqual("Man", result.Make);
                Assert.AreEqual("Lion's Coach", result.Model);
                Assert.AreEqual(1500000, result.Price);
                Assert.AreEqual("White", result.Color);
                Assert.AreEqual("Diesel", result.FuelType);
                Assert.AreEqual("https://www.plantmachineryvehicles.com/cloud/2021/07/08/MAN-Lions-Coach-2017.jpg", result.ImageUrl);
                Assert.AreEqual(55, result.Capacity);
                Assert.AreEqual("Low mileage, excellent condition", result.Description);
                Assert.AreEqual("Automatic", result.Transmission);
                Assert.AreEqual(203, result.HorsePower);
            }
        }

        [Test]
        public async Task GetBusDetails_ReturnsNull_WhenBusDoesNotExist()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new BusServices(context);

                var result = await service.GetBusDetailsAsync(999); // ID that does not exist

                Assert.Null(result);
            }
        }
        [Test]
        public async Task GetBusDetails_IgnoresDeletedBuses()
        {

            var options = CreateInMemoryDbOptions();
            var busId = 1;
            using (var context = new VehicleDbContext(options))
            {

                var vehicle = new Vehicle
                {
                    VehicleId = busId,
                    VehicleType = "Bus",
                    Make = "Volvo",
                    Model = "7900",
                    Year = new DateTime(2022, 08, 12),
                    Price = 250000,
                    Color = "Blue",
                    FuelType = "Electric",
                    ImageUrl = "https://www.volvobuses.com/content/dam/volvo-buses/markets/master/city-and-intercity/complete-buses/volvo-7900-electric/1860x1050-Volvo-7900-Electric-front45.jpg"
                };

                var bus = new Bus
                {
                    Vehicle = vehicle,
                    Capacity = 55,
                    Description = "Well maintained",
                    Transmission = "Automatic",
                    HorsePower = 150,
                    IsDelete = true, // Marked as deleted
                    VehicleId = busId
                };

                await context.Buses.AddAsync(bus);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new BusServices(context);

                var result = await service.GetBusDetailsAsync(busId);

                Assert.Null(result);
            }
        }

        [Test]
        public async Task GetBusForEdit_ReturnsCorrectbuSEditDetails_WhenBusExists()
        {
            var options = CreateInMemoryDbOptions();
            var busId = 1;
            using (var context = new VehicleDbContext(options))
            {

                var vehicle = new Vehicle
                {
                    VehicleId = busId,
                    VehicleType = "Bus",
                    Make = "Scania",
                    Model = "Touring",
                    Year = new DateTime(2022, 08, 12),
                    Price = 450000,
                    Color = "White",
                    FuelType = "Diesel",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTCi99udO3AjuMaYUvsG-r56LglqenvXXZb-A&s"
                };

                var bus = new Bus
                {
                    Vehicle = vehicle,
                    Description = "Powerful truck for heavy-duty tasks",
                    Transmission = "Automatic",
                    Capacity = 55,
                    HorsePower = 400,
                    IsDelete = false,
                    BusId = 101
                };

                await context.Buses.AddAsync(bus);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new BusServices(context);

                var result = await service.GetBusForEditAsync(1);

                Assert.NotNull(result);
                Assert.AreEqual("Bus", result.VehicleType);
                Assert.AreEqual("Scania", result.Make);
                Assert.AreEqual("Touring", result.Model);
                Assert.AreEqual(450000, result.Price);
                Assert.AreEqual("White", result.Color);
                Assert.AreEqual("Diesel", result.FuelType);
                Assert.AreEqual("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTCi99udO3AjuMaYUvsG-r56LglqenvXXZb-A&s", result.ImageUrl);
                Assert.AreEqual(101, result.BusId);
                Assert.AreEqual(55, result.Capacity);
                Assert.AreEqual("Powerful truck for heavy-duty tasks", result.Description);
                Assert.AreEqual("Automatic", result.Transmission);
                Assert.AreEqual(400, result.HorsePower);
            }
        }

        [Test]
        public async Task GetBusForEdit_ReturnsNull_WhenBusDoesNotExist()
        {
            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new BusServices(context);

                var result = await service.GetBusForEditAsync(999); // ID that does not exist

                Assert.Null(result);
            }
        }

        [Test]
        public async Task GetBusForEdit_IgnoresDeletedBuses()
        {

            var options = CreateInMemoryDbOptions();
            var busId = 1;
            using (var context = new VehicleDbContext(options))
            {

                var vehicle = new Vehicle
                {
                    VehicleId = busId,
                    VehicleType = "Bus",
                    Make = "Scania",
                    Model = "Irizar",
                    Year = new DateTime(2022, 11, 12),
                    Price = 600000,
                    Color = "Graphite",
                    FuelType = "Diesel",
                    ImageUrl = "https://i.ytimg.com/vi/JN-UKJp1vQ0/maxresdefault.jpg"
                };

                var bus = new Bus
                {
                    Vehicle = vehicle,
                    Description = "Comfort and fast",
                    Transmission = "Automatic",
                    Capacity = 100,
                    HorsePower = 455,
                    IsDelete = true, // Marked as deleted
                    BusId = 102
                };

                await context.Buses.AddAsync(bus);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new BusServices(context);

                var result = await service.GetBusForEditAsync(1);

                Assert.Null(result);
            }
        }

        [Test]
        public async Task EditBus_ThrowsArgumentException_WhenYearIsInvalid()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new BusServices(context);
                var editModel = new BusEditViewModel
                {
                    BusId = 1,
                    VehicleType = "Bus",
                    Make = "Scania",
                    Model = "Irizar",
                    Year = "InvalidDate",
                    Price = 600000,
                    Color = "Graphite",
                    FuelType = "Diesel",
                    ImageUrl = "https://i.ytimg.com/vi/JN-UKJp1vQ0/maxresdefault.jpg",
                    Capacity = 100,
                    Description = "Comfort and fast",
                    Transmission = "Automatic",
                    HorsePower = 140
                };


                var exception = "The Year must be in the following format: dd/MM/yyyy";
                Assert.AreEqual("The Year must be in the following format: dd/MM/yyyy", exception);
            }
        }
        [Test]
        public async Task DeleteBuses_ReturnsCorrectViewModel_WhenBusExists()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var busId = 1;
                var vehicle = new Vehicle
                {
                    VehicleId = busId,
                    VehicleType = "Bus",
                    Make = "Scania",
                    Model = "Irizar",
                    Year = new DateTime(2022, 11, 12),
                    Price = 600000,
                    Color = "Graphite",
                    FuelType = "Diesel",
                    ImageUrl = "https://i.ytimg.com/vi/JN-UKJp1vQ0/maxresdefault.jpg"
                };

                var bus = new Bus
                {
                    Vehicle = vehicle,
                    Description = "Comfort and fast",
                    Transmission = "Automatic",
                    Capacity = 100,
                    HorsePower = 150,
                    IsDelete = false,
                    BusId = busId
                };

                await context.Buses.AddAsync(bus);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new BusServices(context);


                var result = await service.DeleteBusAsync(1);


                Assert.NotNull(result);
                Assert.AreEqual(1, result.VehicleId);
                Assert.AreEqual("Bus", result.VehicleType);
                Assert.AreEqual("Irizar", result.Model);
                Assert.AreEqual("Irizar", result.Make);
                Assert.AreEqual(600000, result.Price);
                Assert.AreEqual("Graphite", result.Color);
                Assert.AreEqual("Diesel", result.FuelType);
                Assert.AreEqual("https://i.ytimg.com/vi/JN-UKJp1vQ0/maxresdefault.jpg", result.ImageUrl);
                Assert.AreEqual(1, result.BusId);
                Assert.AreEqual("Comfort and fast", result.Description);
                Assert.AreEqual("Automatic", result.Transmission);
                Assert.AreEqual(150, result.HorsePower);
            }
        }

        [Test]
        public async Task ConfirmDelete_ReturnsFalse_WhenVehicleDoesNotExist()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new BusServices(context);

                var result = await service.BusConfirmDeleteAsync(999); // Non-existing ID

                Assert.False(result);
            }
        }
    }
}
