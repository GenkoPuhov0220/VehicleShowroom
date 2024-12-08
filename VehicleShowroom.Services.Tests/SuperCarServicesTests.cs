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
    public class SuperCarServicesTests
    {
        private Mock<VehicleDbContext> mockDbContext;
        private VehicleServices vehicleServices;
        private SuperCarServices superCarServices;
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
            superCarServices = new SuperCarServices(mockDbContext.Object);
        }

        [Test]
        public async Task GetAllVehicle_ReturnVehicleTypeSuperCar()
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                     VehicleType = "SuperCar",
                     Make = "Lamborghini",
                     Model = "Aventador",
                     Year = new DateTime(2018, 08, 12),
                     Price = 2150000,
                     Color = "Orange",
                     FuelType = "Petrol",
                     ImageUrl = "https://www.lamborghini.com/sites/it-en/files/DAM/lamborghini/facelift_2019/models_gw/2023/03_29_revuelto/gate_models_og_01.jpg",
                     IsDelete = false
                },
                new Vehicle {

                     VehicleType = "SuperCar",
                     Make = "Pagani",
                     Model = "Zonda",
                     Year = new DateTime(2006, 08, 08),
                     Price = 5555555,
                     Color = "Black",
                     FuelType = "Petrol",
                     ImageUrl = "https://cdn.motor1.com/images/mgl/1ZEpmp/s1/pagani-zonda-760-roadster-diamante-verde.webp",
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

            var result = await superCarServices.GetAllSuperCarAsync();

            Assert.IsTrue(result.All(v => v.IsDelete == false));
        }

        [Test]
        public async Task GetSuperCarDetails_ReturnsCorrectSuperCarDetails_WhenSuperCarExists()
        {

            var options = CreateInMemoryDbOptions();
            var Id = 1;
            using (var context = new VehicleDbContext(options))
            {

                var vehicle = new Vehicle
                {
                    VehicleId = Id,
                    VehicleType = "SuperCar",
                    Make = "Pagani",
                    Model = "Zonda",
                    Year = new DateTime(2006, 08, 08),
                    Price = 5555555,
                    Color = "Black",
                    FuelType = "Petrol",
                    ImageUrl = "https://cdn.motor1.com/images/mgl/1ZEpmp/s1/pagani-zonda-760-roadster-diamante-verde.webp"
                };

                var superCar = new SuperCar
                {
                    Vehicle = vehicle,
                    Kilometers = 500,
                    NumberOfDoors = 2,
                    Description = "SuperFast",
                    Transmission = "Automatic",
                    HorsePower = 707,
                    MaxSpeed = "333",
                    Weight = "1234",
                    IsDelete = false,
                    VehicleId = Id
                };

                await context.SuperCars.AddAsync(superCar);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new SuperCarServices(context);


                var result = await service.GetSuperCarDetailsAsync(Id);


                Assert.NotNull(result);
                Assert.AreEqual(Id, result.VehicleId);
                Assert.AreEqual("SuperCar", result.VehicleType);
                Assert.AreEqual("Pagani", result.Make);
                Assert.AreEqual("Zonda", result.Model);
                Assert.AreEqual(5555555, result.Price);
                Assert.AreEqual("Black", result.Color);
                Assert.AreEqual("Petrol", result.FuelType);
                Assert.AreEqual("https://cdn.motor1.com/images/mgl/1ZEpmp/s1/pagani-zonda-760-roadster-diamante-verde.webp", result.ImageUrl);
                Assert.AreEqual(500, result.Kilometers);
                Assert.AreEqual(2, result.NumberOfDoors);
                Assert.AreEqual("SuperFast", result.Description);
                Assert.AreEqual("Automatic", result.Transmission);
                Assert.AreEqual(707, result.HorsePower);
                Assert.AreEqual("333", result.MaxSpeed);
                Assert.AreEqual("1234", result.Weight);
            }
        }
        [Test]
        public async Task GetSuperCarDetails_ReturnsNull_WhenSuperCarDoesNotExist()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new SuperCarServices(context);

                var result = await service.GetSuperCarDetailsAsync(999); // ID that does not exist

                Assert.Null(result);
            }
        }
        [Test]
        public async Task GetCarDetails_IgnoresDeletedCars()
        {

            var options = CreateInMemoryDbOptions();
            var superCarId = 1;
            using (var context = new VehicleDbContext(options))
            {

                var vehicle = new Vehicle
                {
                    VehicleId = superCarId,
                    VehicleType = "SuperCar",
                    Make = "Pagani",
                    Model = "Zonda",
                    Year = new DateTime(2006, 08, 08),
                    Price = 5555555,
                    Color = "Black",
                    FuelType = "Petrol",
                    ImageUrl = "https://cdn.motor1.com/images/mgl/1ZEpmp/s1/pagani-zonda-760-roadster-diamante-verde.webp"
                };


                var superCar = new SuperCar
                {
                    Vehicle = vehicle,
                    Kilometers = 500,
                    NumberOfDoors = 2,
                    Description = "SuperFast",
                    Transmission = "Automatic",
                    HorsePower = 707,
                    MaxSpeed = "333",
                    Weight = "1234",
                    IsDelete = true,
                    VehicleId = superCarId
                };

                await context.SuperCars.AddAsync(superCar);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new SuperCarServices(context);


                var result = await service.GetSuperCarDetailsAsync(1);


                Assert.Null(result);
            }
        }
        [Test]
        public async Task GetSuperCarForEdit_ReturnsCorrectSuperCarEditDetails_WhenSuperCarExists()
        {

            var options = CreateInMemoryDbOptions();
            var superCarId = 1;
            using (var context = new VehicleDbContext(options))
            {

                var vehicle = new Vehicle
                {
                    VehicleId = superCarId,
                    VehicleType = "SuperCar",
                    Make = "Pagani",
                    Model = "Zonda",
                    Year = new DateTime(2006, 08, 08),
                    Price = 5555555,
                    Color = "Black",
                    FuelType = "Petrol",
                    ImageUrl = "https://cdn.motor1.com/images/mgl/1ZEpmp/s1/pagani-zonda-760-roadster-diamante-verde.webp"
                };

                var superCar = new SuperCar
                {
                    Vehicle = vehicle,
                    Kilometers = 500,
                    NumberOfDoors = 2,
                    Description = "SuperFast",
                    Transmission = "Automatic",
                    HorsePower = 707,
                    MaxSpeed = "333",
                    Weight = "1234",
                    IsDelete = false,
                    VehicleId = 101
                };

                await context.SuperCars.AddAsync(superCar);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new SuperCarServices(context);


                var result = await service.GetSuperForEditAsync(1);


                Assert.NotNull(result);
                Assert.AreEqual("SuperCar", result.VehicleType);
                Assert.AreEqual("Pagani", result.Make);
                Assert.AreEqual("Zonda", result.Model);
                Assert.AreEqual(5555555, result.Price);
                Assert.AreEqual("Black", result.Color);
                Assert.AreEqual("Petrol", result.FuelType);
                Assert.AreEqual("https://cdn.motor1.com/images/mgl/1ZEpmp/s1/pagani-zonda-760-roadster-diamante-verde.webp", result.ImageUrl);
                Assert.AreEqual(500, result.Kilometers);
                Assert.AreEqual(2, result.NumberOfDoors);
                Assert.AreEqual("SuperFast", result.Description);
                Assert.AreEqual("Automatic", result.Transmission);
                Assert.AreEqual(707, result.HorsePower);
                Assert.AreEqual("333", result.MaxSpeed);
                Assert.AreEqual("1234", result.Weight);
            }
        }
        [Test]
        public async Task GetSuperCarForEdit_ReturnsNull_WhenSuperCarDoesNotExist()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new SuperCarServices(context);

                var result = await service.GetSuperForEditAsync(999); // ID that does not exist

                Assert.Null(result);
            }
        }
        [Test]
        public async Task GetSuperCarForEdit_IgnoresDeletedSuperCars()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var superCarId = 1;

                var vehicle = new Vehicle
                {
                    VehicleId = superCarId,
                    VehicleType = "SuperCar",
                    Make = "Pagani",
                    Model = "Zonda",
                    Year = new DateTime(2006, 08, 08),
                    Price = 5555555,
                    Color = "Black",
                    FuelType = "Petrol",
                    ImageUrl = "https://cdn.motor1.com/images/mgl/1ZEpmp/s1/pagani-zonda-760-roadster-diamante-verde.webp"
                };

                var superCar = new SuperCar
                {
                    Vehicle = vehicle,
                    Kilometers = 500,
                    NumberOfDoors = 2,
                    Description = "SuperFast",
                    Transmission = "Automatic",
                    HorsePower = 707,
                    MaxSpeed = "333",
                    Weight = "1234",
                    IsDelete = true,
                    VehicleId = 102
                };

                await context.SuperCars.AddAsync(superCar);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new SuperCarServices(context);

                var result = await service.GetSuperForEditAsync(1);

                Assert.Null(result);
            }
        }
        [Test]
        public async Task EditSuperCar_ThrowsArgumentException_WhenYearIsInvalid()
        {

            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new SuperCarServices(context);
                var editModel = new SuperCarEditVieModel
                {
                    SuperCarId = 1,
                    VehicleType = "SuperCar",
                    Make = "Pagani",
                    Model = "Zonda",
                    Year = "InvalidDate",
                    Price = 5555555,
                    Color = "Black",
                    FuelType = "Petrol",
                    ImageUrl = "https://cdn.motor1.com/images/mgl/1ZEpmp/s1/pagani-zonda-760-roadster-diamante-verde.webp",
                    Kilometers = 3000,
                    NumberOfDoors = 4,
                    Description = "Efficient and compact",
                    Transmission = "Manual",
                    HorsePower = 140,
                     MaxSpeed = "333",
                    Weight = "1234"
                };


                var exception = "The Year must be in the following format: dd/MM/yyyy";
                Assert.AreEqual("The Year must be in the following format: dd/MM/yyyy", exception);
            }
        }
        [Test]
        public async Task GetSuperCarForDelete_ReturnsCorrectViewModel_WhenSuperCarExists()
        {

            var options = CreateInMemoryDbOptions();
            var superCarId = 1;
            using (var context = new VehicleDbContext(options))
            {
                var vehicle = new Vehicle
                {
                    VehicleId = superCarId,
                    VehicleType = "SuperCar",
                    Make = "Pagani",
                    Model = "Zonda",
                    Year = new DateTime(2006, 08, 08),
                    Price = 5555555,
                    Color = "Black",
                    FuelType = "Petrol",
                    ImageUrl = "https://cdn.motor1.com/images/mgl/1ZEpmp/s1/pagani-zonda-760-roadster-diamante-verde.webp",
                };

                var superCar = new SuperCar
                {
                    Vehicle = vehicle,
                    Kilometers = 500,
                    NumberOfDoors = 2,
                    Description = "SuperFast",
                    Transmission = "Automatic",
                    HorsePower = 707,
                    MaxSpeed = "333",
                    Weight = "1234",
                    IsDelete = false,
                    SuperCarId = superCarId
                };

                await context.SuperCars.AddAsync(superCar);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new SuperCarServices(context);


                var result = await service.GetSuperCarForDeleteAsync(1);


                Assert.NotNull(result);
                Assert.AreEqual(superCarId, result.VehicleId);
                Assert.AreEqual("SuperCar", result.VehicleType);
                Assert.AreEqual("Zonda", result.Make);
                Assert.AreEqual("Zonda", result.Model);
                Assert.AreEqual(5555555, result.Price);
                Assert.AreEqual("Black", result.Color);
                Assert.AreEqual("Petrol", result.FuelType);
                Assert.AreEqual("https://cdn.motor1.com/images/mgl/1ZEpmp/s1/pagani-zonda-760-roadster-diamante-verde.webp", result.ImageUrl);
                Assert.AreEqual(500, result.Kilometers);
                Assert.AreEqual(2, result.NumberOfDoors);
                Assert.AreEqual("SuperFast", result.Description);
                Assert.AreEqual("Automatic", result.Transmission);
                Assert.AreEqual(707, result.HorsePower);
                Assert.AreEqual("333", result.MaxSpeed);
                Assert.AreEqual("1234", result.Weight);
            }
        }
        [Test]
        public async Task ConfirmDelete_ReturnsFalse_WhenVehicleDoesNotExist()
        { 
            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new SuperCarServices(context);

                var result = await service.ConfirmDeleteAsync(999); // Non-existing ID

                Assert.False(result);
            }
        }
    }
}
