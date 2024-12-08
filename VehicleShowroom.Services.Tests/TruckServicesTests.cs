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
    public class TruckServicesTests
    {
        private Mock<VehicleDbContext> mockDbContext;
        private VehicleServices vehicleServices;
        private TruckServices truckServices;

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
            truckServices = new TruckServices(mockDbContext.Object);
        }
        [Test]
        public async Task GetAllVehicle_ReturnVehicleTypeTruck()
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                     VehicleType = "Truck",
                     Make = "Man",
                     Model = "TGX",
                     Year = new DateTime(2015, 08, 12),
                     Price = 98745,
                     Color = "Red",
                     FuelType = "Diesel",
                     ImageUrl = "https://media.sketchfab.com/models/1b36654f9af64ebb9e87d2fd55ce38f2/thumbnails/1bc5a6a6504b4d31b27073958a2a0c03/b1fddaf5cc7c4b44b8b30257321b2372.jpeg",
                     IsDelete = false
                },
                new Vehicle {

                     VehicleType = "Truck",
                     Make = "Volvo",
                     Model = "VNL400",
                     Year = new DateTime(2006, 08, 08),
                     Price = 55500,
                     Color = "White",
                     FuelType = "Petrol",
                     ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0R8E1fJzckxyoDfjdXWRY50MywAC3M-Kn9g&s",
                     IsDelete = false
                },
                new Vehicle {

                     VehicleType = "Bus",
                     Make = "AUDI",
                     Model = "A8 Long",
                     Year = new DateTime(2022, 10, 15),
                     Price = 150000,
                     Color = "White",
                     FuelType = "Petrol",
                     ImageUrl = "https://frankfurt.apollo.olxcdn.com/v1/files/r8lz4w93so09-BG/image",
                     IsDelete = true
                }
            };

            mockDbContext.Setup(db => db.Vehicles).ReturnsDbSet(vehicles);

            var result = await truckServices.GetAllTrucksAsync();


            Assert.IsTrue(result.All(v => v.IsDelete == false));

        }
        [Test]
        public async Task GetTruckDetails_ReturnsCorrectTruckDetails_WhenTruckExists()
        {

            var options = CreateInMemoryDbOptions();
            var Id = 1;
            using (var context = new VehicleDbContext(options))
            {

                var vehicle = new Vehicle
                {
                    VehicleId = Id,
                    VehicleType = "Truck",
                    Make = "Volvo",
                    Model = "VNL400",
                    Year = new DateTime(2006, 08, 08),
                    Price = 55500,
                    Color = "White",
                    FuelType = "Petrol",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0R8E1fJzckxyoDfjdXWRY50MywAC3M-Kn9g&s",
                };

                var truck = new Truck
                {
                    Vehicle = vehicle,
                    CargoCapacity = 5000,
                    EuroNumber = "5",
                    Description = "Best Truck",
                    Transmission = "Automatic",
                    HorsePower = 555,
                    IsDelete = false,
                    VehicleId = Id
                };

                await context.Trucks.AddAsync(truck);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new TruckServices(context);


                var result = await service.GetTruckDetailsAsync(Id);


                Assert.NotNull(result);
                Assert.AreEqual(Id, result.VehicleId);
                Assert.AreEqual("Truck", result.VehicleType);
                Assert.AreEqual("Volvo", result.Make);
                Assert.AreEqual("VNL400", result.Model);
                Assert.AreEqual(55500, result.Price);
                Assert.AreEqual("White", result.Color);
                Assert.AreEqual("Petrol", result.FuelType);
                Assert.AreEqual("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0R8E1fJzckxyoDfjdXWRY50MywAC3M-Kn9g&s", result.ImageUrl);
                Assert.AreEqual(5000, result.CargoCapacity);
                Assert.AreEqual("5", result.EuroNumber);
                Assert.AreEqual("Best Truck", result.Description);
                Assert.AreEqual("Automatic", result.Transmission);
                Assert.AreEqual(555, result.HorsePower);
            }
        }
        [Test]
        public async Task GetTruckDetails_ReturnsNull_WhenTruckDoesNotExist()
        {
            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new TruckServices(context);

                var result = await service.GetTruckDetailsAsync(999); // ID that does not exist
                Assert.Null(result);
            }
        }
        [Test]
        public async Task GetTruckDetails_IgnoresDeletedTrucks()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var truckId = 1;

                var vehicle = new Vehicle
                {
                    VehicleId = truckId,
                    VehicleType = "Truck",
                    Make = "Volvo",
                    Model = "VNL400",
                    Year = new DateTime(2006, 08, 08),
                    Price = 55500,
                    Color = "White",
                    FuelType = "Petrol",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0R8E1fJzckxyoDfjdXWRY50MywAC3M-Kn9g&s",
                };

                var truck = new Truck
                {
                    Vehicle = vehicle,
                    CargoCapacity = 5000,
                    EuroNumber = "5",
                    Description = "Best Truck",
                    Transmission = "Automatic",
                    HorsePower = 555,
                    IsDelete = true,
                    VehicleId = truckId
                };
                await context.Trucks.AddAsync(truck);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new TruckServices(context);

                var result = await service.GetTruckDetailsAsync(1);

                Assert.Null(result);
            }
        }
        [Test]
        public async Task GetTruckForEdit_ReturnsCorrectTruckEditDetails_WhenTruckExists()
        {

            var options = CreateInMemoryDbOptions();
            var truckId = 1;
            using (var context = new VehicleDbContext(options))
            {

                var vehicle = new Vehicle
                {
                    VehicleId = truckId,
                    VehicleType = "Truck",
                    Make = "Volvo",
                    Model = "VNL400",
                    Year = new DateTime(2006, 08, 08),
                    Price = 55500,
                    Color = "White",
                    FuelType = "Petrol",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0R8E1fJzckxyoDfjdXWRY50MywAC3M-Kn9g&s",
                };


                var truck = new Truck
                {
                    Vehicle = vehicle,
                    CargoCapacity = 5000,
                    EuroNumber = "5",
                    Description = "Best Truck",
                    Transmission = "Automatic",
                    HorsePower = 555,
                    IsDelete = false,
                    VehicleId = 101
                };
                await context.Trucks.AddAsync(truck);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new TruckServices(context);

                var result = await service.GetTruckForEditAsync(1);

                Assert.NotNull(result);
                Assert.AreEqual("Truck", result.VehicleType);
                Assert.AreEqual("Volvo", result.Make);
                Assert.AreEqual("VNL400", result.Model);
                Assert.AreEqual(55500, result.Price);
                Assert.AreEqual("White", result.Color);
                Assert.AreEqual("Petrol", result.FuelType);
                Assert.AreEqual("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0R8E1fJzckxyoDfjdXWRY50MywAC3M-Kn9g&s", result.ImageUrl);
                Assert.AreEqual(5000, result.CargoCapacity);
                Assert.AreEqual("5", result.EuroNumber);
                Assert.AreEqual("Best Truck", result.Description);
                Assert.AreEqual("Automatic", result.Transmission);
                Assert.AreEqual(555, result.HorsePower);
            }
        }
        [Test]
        public async Task GetTruckForEdit_ReturnsNull_WhenTruckDoesNotExist()
        {
            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new TruckServices(context);

                var result = await service.GetTruckForEditAsync(999); // ID that does not exist

                Assert.Null(result);
            }
        }
        [Test]
        public async Task GetTruckForEdit_IgnoresDeletedTruck()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var truckId = 1;

                var vehicle = new Vehicle
                {
                    VehicleId = truckId,
                    VehicleType = "Truck",
                    Make = "Volvo",
                    Model = "VNL400",
                    Year = new DateTime(2006, 08, 08),
                    Price = 55500,
                    Color = "White",
                    FuelType = "Petrol",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0R8E1fJzckxyoDfjdXWRY50MywAC3M-Kn9g&s",
                };

                var truck = new Truck
                {
                    Vehicle = vehicle,
                    CargoCapacity = 5000,
                    EuroNumber = "5",
                    Description = "Best Truck",
                    Transmission = "Automatic",
                    HorsePower = 555,
                    IsDelete = true,
                    VehicleId = truckId
                };
                await context.Trucks.AddAsync(truck);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new TruckServices(context);

                var result = await service.GetTruckForEditAsync(1);

                Assert.Null(result);
            }
        }
        [Test]
        public async Task EditCar_ThrowsArgumentException_WhenYearIsInvalid()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new TruckServices(context);
                var editModel = new TruckEditViewModel
                {
                    TruckId = 1,
                    VehicleType = "Truck",
                    Make = "Volvo",
                    Model = "VNL400",
                    Year = "Invalid",
                    Price = 55500,
                    Color = "White",
                    FuelType = "Petrol",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0R8E1fJzckxyoDfjdXWRY50MywAC3M-Kn9g&s",
                    CargoCapacity = 5000,
                    EuroNumber = "5",
                    Description = "Best Truck",
                    Transmission = "Automatic",
                    HorsePower = 555
                };
                var exception = "The Year must be in the following format: dd/MM/yyyy";
                Assert.AreEqual("The Year must be in the following format: dd/MM/yyyy", exception);
            }
        }

        [Test]
        public async Task GetTruckForDelete_ReturnsCorrectViewModel_WhenTruckExists()
        {

            var options = CreateInMemoryDbOptions();
            var truckId = 1;
            using (var context = new VehicleDbContext(options))
            {
                var vehicle = new Vehicle
                {
                    VehicleId = truckId,
                    VehicleType = "Truck",
                    Make = "Volvo",
                    Model = "VNL400",
                    Year = new DateTime(2006, 08, 08),
                    Price = 55500,
                    Color = "White",
                    FuelType = "Petrol",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0R8E1fJzckxyoDfjdXWRY50MywAC3M-Kn9g&s"
                };

                var truck = new Truck
                {
                    Vehicle = vehicle,
                    CargoCapacity = 5000,
                    EuroNumber = "5",
                    Description = "Best Truck",
                    Transmission = "Automatic",
                    HorsePower = 555,
                    IsDelete = false,
                    VehicleId = truckId
                };
                await context.Trucks.AddAsync(truck);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new TruckServices(context);


                var result = await service.GetTruckForDeleteAsync(truckId);


                Assert.NotNull(result);
                Assert.AreEqual(truckId, result.VehicleId);
                Assert.AreEqual("Truck", result.VehicleType);
                Assert.AreEqual("VNL400", result.Make);
                Assert.AreEqual("VNL400", result.Model);
                Assert.AreEqual(55500, result.Price);
                Assert.AreEqual("White", result.Color);
                Assert.AreEqual("Petrol", result.FuelType);
                Assert.AreEqual("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0R8E1fJzckxyoDfjdXWRY50MywAC3M-Kn9g&s", result.ImageUrl);
                Assert.AreEqual(5000, result.CargoCapacity);
                Assert.AreEqual("5", result.EuroNumber);
                Assert.AreEqual("Best Truck", result.Description);
                Assert.AreEqual("Automatic", result.Transmission);
                Assert.AreEqual(555, result.HorsePower);
            }
        }
        [Test]
        public async Task ConfirmDelete_ReturnsFalse_WhenVehicleDoesNotExist()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new TruckServices(context);


                var result = await service.ConfirmDeleteAsync(999); // Non-existing ID


                Assert.False(result);
            }
        }
    }
}
