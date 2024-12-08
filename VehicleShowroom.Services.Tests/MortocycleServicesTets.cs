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
    public class MortocycleServicesTets
    {
        private Mock<VehicleDbContext> mockDbContext;
        private VehicleServices vehicleServices;
        private MotorcycleServices motorcycleServices;
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
            motorcycleServices = new MotorcycleServices(mockDbContext.Object);

        }
        [Test]
        public async Task GetAllVehicle_ReturnVehicleTypeMotorcycle()
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                     VehicleType = "Motorcycle",
                     Make = "Honda",
                     Model = "CRF 450",
                     Year = new DateTime(2012, 08, 12),
                     Price = 21500,
                     Color = "Red",
                     FuelType = "Petrol",
                     ImageUrl = "https://motorcycles.honda.bg/wp-content/uploads/sites/4/2024/10/25ym_crf450r_studio_rfq-1024x576.jpg",
                     IsDelete = false
                },
                new Vehicle {

                     VehicleType = "Motorcycle",
                     Make = "KTM",
                     Model = "exc 300",
                     Year = new DateTime(2024, 08, 08),
                     Price = 22500,
                     Color = "Orange",
                     FuelType = "Petrol",
                     ImageUrl = "https://motohouse.bg/wp-content/uploads/2022/04/PHO_BIKE_90_REVO_MY24-KTM-300-EXC-Front-Right_SALL_AEPI_V1.png",
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

            var result = await motorcycleServices.GetAllMotorcycleAsync();


            Assert.IsTrue(result.All(v => v.IsDelete == false));

        }

        [Test]
        public async Task GetMotorcycleDetails_ReturnsCorrectMoorcycleDetails_WhenMotorcycleExists()
        {

            var options = CreateInMemoryDbOptions();
            var Id = 1;
            using (var context = new VehicleDbContext(options))
            {

                var vehicle = new Vehicle
                {
                    VehicleType = "Motorcycle",
                    Make = "Honda",
                    Model = "CRF 450",
                    Year = new DateTime(2012, 08, 12),
                    Price = 21500,
                    Color = "Red",
                    FuelType = "Petrol",
                    ImageUrl = "https://motorcycles.honda.bg/wp-content/uploads/sites/4/2024/10/25ym_crf450r_studio_rfq-1024x576.jpg",
                    
                };

                var motorcycle = new Motorcycle
                {
                    Vehicle = vehicle,
                    Kw = 25,
                    IsDelete = false,
                    VehicleId = Id
                };

                await context.Motorcycles.AddAsync(motorcycle);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new MotorcycleServices(context);


                var result = await service.GetMotrocycleDetailsAsync(Id);


                Assert.NotNull(result);
                Assert.AreEqual(Id, result.VehicleId);
                Assert.AreEqual("Motorcycle", result.VehicleType);
                Assert.AreEqual("Honda", result.Make);
                Assert.AreEqual("CRF 450", result.Model);
                Assert.AreEqual(21500, result.Price);
                Assert.AreEqual("Red", result.Color);
                Assert.AreEqual("Petrol", result.FuelType);
                Assert.AreEqual("https://motorcycles.honda.bg/wp-content/uploads/sites/4/2024/10/25ym_crf450r_studio_rfq-1024x576.jpg", result.ImageUrl);
                Assert.AreEqual(25, result.Kw);
               
            }
        }
        [Test]
        public async Task GetMotorcycleDetails_ReturnsNull_WhenMotorcycleDoesNotExist()
        {
            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new MotorcycleServices(context);

                var result = await service.GetMotrocycleDetailsAsync(999); // ID that does not exist

                Assert.Null(result);
            }
        }
        [Test]
        public async Task GetCarDetails_IgnoresDeletedCars()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var motorcycleId = 1;

                var vehicle = new Vehicle
                {
                    VehicleId = motorcycleId,
                    VehicleType = "Motorcycle",
                    Make = "Honda",
                    Model = "CRF 450",
                    Year = new DateTime(2012, 08, 12),
                    Price = 21500,
                    Color = "Red",
                    FuelType = "Petrol",
                    ImageUrl = "https://motorcycles.honda.bg/wp-content/uploads/sites/4/2024/10/25ym_crf450r_studio_rfq-1024x576.jpg",
                };

                var motorcycle = new Motorcycle
                {
                    Vehicle = vehicle,
                   Kw = 25,
                    IsDelete = true, // Marked as deleted
                    VehicleId = motorcycleId
                };

                await context.Motorcycles.AddAsync(motorcycle);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new MotorcycleServices(context);


                var result = await service.GetMotrocycleDetailsAsync(1);


                Assert.Null(result);
            }
        }

        [Test]
        public async Task GetMotorcycleForEdit_ReturnsCorrectMotorcycleEditDetails_WhenMotorcycleExists()
        {

            var options = CreateInMemoryDbOptions();
            var motorcycleId = 1;
            using (var context = new VehicleDbContext(options))
            {

                var vehicle = new Vehicle
                {
                    VehicleId = motorcycleId,
                    VehicleType = "Motorcycle",
                    Make = "Honda",
                    Model = "CRF 450",
                    Year = new DateTime(2012, 08, 12),
                    Price = 21500,
                    Color = "Red",
                    FuelType = "Petrol",
                    ImageUrl = "https://motorcycles.honda.bg/wp-content/uploads/sites/4/2024/10/25ym_crf450r_studio_rfq-1024x576.jpg",
                };

                var motorcycle = new Motorcycle
                {
                    Vehicle = vehicle,
                    Kw = 25,
                    IsDelete = false,
                    MotorcycleId = 101
                };

                await context.Motorcycles.AddAsync(motorcycle);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new MotorcycleServices(context);


                var result = await service.GetMotorcycleForEditAsync(1);


                Assert.NotNull(result);
                Assert.AreEqual("Motorcycle", result.VehicleType);
                Assert.AreEqual("Honda", result.Make);
                Assert.AreEqual("CRF 450", result.Model);
                Assert.AreEqual(21500, result.Price);
                Assert.AreEqual("Red", result.Color);
                Assert.AreEqual("Petrol", result.FuelType);
                Assert.AreEqual("https://motorcycles.honda.bg/wp-content/uploads/sites/4/2024/10/25ym_crf450r_studio_rfq-1024x576.jpg", result.ImageUrl);
                Assert.AreEqual(25, result.Kw);
            }
        }
        [Test]
        public async Task GetMotorcycleForEdit_ReturnsNull_WhenMotorcycleDoesNotExist()
        {
            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new MotorcycleServices(context);

                var result = await service.GetMotorcycleForEditAsync(999); // ID that does not exist

                Assert.Null(result);
            }
        }
        [Test]
        public async Task GetCarForEdit_IgnoresDeletedCars()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var motorcycleId = 1;

                var vehicle = new Vehicle
                {

                    VehicleId = motorcycleId,
                    VehicleType = "Motorcycle",
                    Make = "Honda",
                    Model = "CRF 450",
                    Year = new DateTime(2012, 08, 12),
                    Price = 21500,
                    Color = "Red",
                    FuelType = "Petrol",
                    ImageUrl = "https://motorcycles.honda.bg/wp-content/uploads/sites/4/2024/10/25ym_crf450r_studio_rfq-1024x576.jpg",
                };

                var motorcycle = new Motorcycle
                {
                    Vehicle = vehicle,
                    Kw = 25,
                    IsDelete = true, // Marked as deleted
                    MotorcycleId = 102
                };

                await context.Motorcycles.AddAsync(motorcycle);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new MotorcycleServices(context);

                var result = await service.GetMotorcycleForEditAsync(1);

                Assert.Null(result);
            }
        }

        [Test]
        public async Task EditMotorcycle_ThrowsArgumentException_WhenYearIsInvalid()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new MotorcycleServices(context);
                var editModel = new MotorcycleEditViewModel
                {
                    MotorcycleId = 1,
                    VehicleType = "Motorcycle",
                    Make = "Honda",
                    Model = "CRF 450",
                    Year = "Invalid",
                    Price = 21500,
                    Color = "Red",
                    FuelType = "Petrol",
                    ImageUrl = "https://motorcycles.honda.bg/wp-content/uploads/sites/4/2024/10/25ym_crf450r_studio_rfq-1024x576.jpg",
                    Kw = 25
                };


                var exception = "The Year must be in the following format: dd/MM/yyyy";
                Assert.AreEqual("The Year must be in the following format: dd/MM/yyyy", exception);
            }
        }
        [Test]
        public async Task GetMotorcycleForDelete_ReturnsCorrectViewModel_WhenMotorcycleExists()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var motorcycleId = 1;
                var vehicle = new Vehicle
                {
                    VehicleId = motorcycleId,
                    VehicleType = "Motorcycle",
                    Make = "Honda",
                    Model = "CRF 450",
                    Year = new DateTime(2012, 08, 12),
                    Price = 21500,
                    Color = "Red",
                    FuelType = "Petrol",
                    ImageUrl = "https://motorcycles.honda.bg/wp-content/uploads/sites/4/2024/10/25ym_crf450r_studio_rfq-1024x576.jpg",
                };

                var motorcycle = new Motorcycle
                {
                    Vehicle = vehicle,
                     Kw = 25,
                    IsDelete = false,
                    MotorcycleId = motorcycleId
                };

                await context.Motorcycles.AddAsync(motorcycle);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new MotorcycleServices(context);


                var result = await service.DeleteMotorcycleAsync(1);


                Assert.NotNull(result);
                Assert.AreEqual(1, result.VehicleId);
                Assert.AreEqual("Motorcycle", result.VehicleType);
                Assert.AreEqual("CRF 450", result.Make);
                Assert.AreEqual("CRF 450", result.Model);
                Assert.AreEqual(21500, result.Price);
                Assert.AreEqual("Red", result.Color);
                Assert.AreEqual("Petrol", result.FuelType);
                Assert.AreEqual("https://motorcycles.honda.bg/wp-content/uploads/sites/4/2024/10/25ym_crf450r_studio_rfq-1024x576.jpg", result.ImageUrl);
                Assert.AreEqual(25, result.Kw);
            }
        }

        [Test]
        public async Task ConfirmDelete_ReturnsFalse_WhenVehicleDoesNotExist()
        {
            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new MotorcycleServices(context);

                var result = await service.MotorcycleConfirmDeleteAsync(999); // Non-existing ID

                Assert.False(result);
            }
        }
    }
}
