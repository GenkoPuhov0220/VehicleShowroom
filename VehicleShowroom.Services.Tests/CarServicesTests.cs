using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using Moq.EntityFrameworkCore;
using System.Globalization;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Services.Data;
using VehicleShowroom.Web;

namespace VehicleShowroom.Services.Tests
{
    [TestFixture]
    public class CarServicesTests
    {
        private Mock<VehicleDbContext> mockDbContext;
        private VehicleServices vehicleServices;
        private CarServices carServices;
        
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
            carServices = new CarServices(mockDbContext.Object);

        }

        [Test]
        public async Task GetAllVehicle_ReturnVehicleTypeCar()
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
                     IsDelete = false
                },
                new Vehicle {
                    
                     VehicleType = "Car",
                     Make = "Merces",
                     Model = "e-clas E320CDI",
                     Year = new DateTime(2006, 08, 08),
                     Price = 22500,
                     Color = "Black",
                     FuelType = "Diesel",
                     ImageUrl = "https://garrybase.com/images/full/uploads/2021/AWEsL34IiTvPxXp2k8M7JcCdJrsZKJEiqimwpWpi.jpg",
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

            var result = await carServices.GetAllCarsAsync();

           
            Assert.IsTrue(result.All(v => v.IsDelete == false));

        }

        [Test]
        public async Task GetCarDetails_ReturnsCorrectCarDetails_WhenCarExists()
        {
          
            var options = CreateInMemoryDbOptions();
            var Id = 1;
            using (var context = new VehicleDbContext(options))
            {

                var vehicle = new Vehicle
                {
                    VehicleId = Id,
                    VehicleType = "SUV",
                    Make = "Toyota",
                    Model = "RAV4",
                    Year = new DateTime(2012, 08, 12),
                    Price = 35000,
                    Color = "Red",
                    FuelType = "Gasoline",
                    ImageUrl = "https://d2s8i866417m9.cloudfront.net/photo/5412753/photo/medium-15ab2fda1bfcdc42f31eb8285dbb0768.jpg"
                };

                var car = new Car
                {
                    Vehicle = vehicle,
                    Kilometers = 5000,
                    NumberOfDoors = 4,
                    Description = "Low mileage, excellent condition",
                    Transmission = "Automatic",
                    HorsePower = 203,
                    IsDelete = false,
                    VehicleId = Id
                };

                await context.Cars.AddAsync(car);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new CarServices(context);

                
                var result = await service.GetCarDetailsAsync(Id);

               
                Assert.NotNull(result);
                Assert.AreEqual(Id, result.VehicleId);
                Assert.AreEqual("SUV", result.VehicleType);
                Assert.AreEqual("Toyota", result.Make);
                Assert.AreEqual("RAV4", result.Model);
                Assert.AreEqual(35000, result.Price);
                Assert.AreEqual("Red", result.Color);
                Assert.AreEqual("Gasoline", result.FuelType);
                Assert.AreEqual("https://d2s8i866417m9.cloudfront.net/photo/5412753/photo/medium-15ab2fda1bfcdc42f31eb8285dbb0768.jpg", result.ImageUrl);
                Assert.AreEqual(5000, result.Kilometers);
                Assert.AreEqual(4, result.NumberOfDoors);
                Assert.AreEqual("Low mileage, excellent condition", result.CarDescription);
                Assert.AreEqual("Automatic", result.CarTransmission);
                Assert.AreEqual(203, result.CarHorsePower);
            }
        }

        [Test]
        public async Task GetCarDetails_ReturnsNull_WhenCarDoesNotExist()
        {
           
            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new CarServices(context);

              
                var result = await service.GetCarDetailsAsync(999); // ID that does not exist

               
                Assert.Null(result);
            }
        }
        [Test]
        public async Task GetCarDetails_IgnoresDeletedCars()
        {
          
            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var carId = 1;

                var vehicle = new Vehicle
                {
                    VehicleId = carId,
                    VehicleType = "Sedan",
                    Make = "Honda",
                    Model = "Civic",
                    Year = new DateTime(2012, 08, 12),
                    Price = 25000,
                    Color = "Blue",
                    FuelType = "Hybrid",
                    ImageUrl = "http://example.com/civic.jpg"
                };

                var car = new Car
                {
                    Vehicle = vehicle,
                    Kilometers = 10000,
                    NumberOfDoors = 4,
                    Description = "Well maintained",
                    Transmission = "Manual",
                    HorsePower = 150,
                    IsDelete = true, // Marked as deleted
                    VehicleId = carId
                };

                await context.Cars.AddAsync(car);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new CarServices(context);

               
                var result = await service.GetCarDetailsAsync(1);

               
                Assert.Null(result);
            }
        }

        [Test]
        public async Task GetCarForEdit_ReturnsCorrectCarEditDetails_WhenCarExists()
        {
          
            var options = CreateInMemoryDbOptions();
            var carId = 1;
            using (var context = new VehicleDbContext(options))
            {

                var vehicle = new Vehicle
                {
                    VehicleId = carId,
                    VehicleType = "Truck",
                    Make = "Ford",
                    Model = "F-150",
                    Year = new DateTime(2022, 08, 12),
                    Price = 45000,
                    Color = "Black",
                    FuelType = "Diesel",
                    ImageUrl = "https://cars.usnews.com/static/images/Auto/izmo/i159614967/2022_ford_f_150_angularfront.jpg"
                };

                var car = new Car
                {
                    Vehicle = vehicle,
                    Kilometers = 15000,
                    NumberOfDoors = 2,
                    Description = "Powerful truck for heavy-duty tasks",
                    Transmission = "Automatic",
                    HorsePower = 400,
                    IsDelete = false,
                    CarId = 101
                };

                await context.Cars.AddAsync(car);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new CarServices(context);

               
                var result = await service.GetCarForEditAsync(1);

                
                Assert.NotNull(result);
                Assert.AreEqual("Truck", result.VehicleType);
                Assert.AreEqual("Ford", result.Make);
                Assert.AreEqual("F-150", result.Model);
                Assert.AreEqual(45000, result.Price);
                Assert.AreEqual("Black", result.Color);
                Assert.AreEqual("Diesel", result.FuelType);
                Assert.AreEqual("https://cars.usnews.com/static/images/Auto/izmo/i159614967/2022_ford_f_150_angularfront.jpg", result.ImageUrl);
                Assert.AreEqual(101, result.CarId);
                Assert.AreEqual(15000, result.Kilometers);
                Assert.AreEqual(2, result.NumberOfDoors);
                Assert.AreEqual("Powerful truck for heavy-duty tasks", result.Description);
                Assert.AreEqual("Automatic", result.Transmission);
                Assert.AreEqual(400, result.HorsePower);
            }
        }

        [Test]
        public async Task GetCarForEdit_ReturnsNull_WhenCarDoesNotExist()
        {
           
            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new CarServices(context);

                
                var result = await service.GetCarForEditAsync(999); // ID that does not exist

                
                Assert.Null(result);
            }
        }
        [Test]
        public async Task GetCarForEdit_IgnoresDeletedCars()
        {
           
            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var carId = 1;

                var vehicle = new Vehicle
                {
                    VehicleId = carId,
                    VehicleType = "Convertible",
                    Make = "Chevrolet",
                    Model = "Camaro",
                    Year = new DateTime(2012, 08, 12),
                    Price = 60000,
                    Color = "Yellow",
                    FuelType = "Gasoline",
                    ImageUrl = "http://example.com/camaro.jpg"
                };

                var car = new Car
                {
                    Vehicle = vehicle,
                    Kilometers = 8000,
                    NumberOfDoors = 2,
                    Description = "Sporty and fast",
                    Transmission = "Manual",
                    HorsePower = 455,
                    IsDelete = true, // Marked as deleted
                    CarId = 102
                };

                await context.Cars.AddAsync(car);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new CarServices(context);

               
                var result = await service.GetCarForEditAsync(1);

               
                Assert.Null(result);
            }
        }

        [Test]
        public async Task EditCar_ThrowsArgumentException_WhenYearIsInvalid()
        {
            
            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var service = new CarServices(context);
                var editModel = new CarEditViewModel
                {
                    CarId = 1,
                    VehicleType = "Hatchback",
                    Make = "Toyota",
                    Model = "Corolla",
                    Year = "InvalidDate",
                    Price = 22000,
                    Color = "Red",
                    FuelType = "Hybrid",
                    ImageUrl = "http://example.com/corolla.jpg",
                    Kilometers = 3000,
                    NumberOfDoors = 4,
                    Description = "Efficient and compact",
                    Transmission = "Manual",
                    HorsePower = 140
                };

                
                var exception = "The Year must be in the following format: dd/MM/yyyy";
                Assert.AreEqual("The Year must be in the following format: dd/MM/yyyy", exception);
            }
        }

        [Test]
        public async Task GetCarForDelete_ReturnsCorrectViewModel_WhenCarExists()
        {
          
            var options = CreateInMemoryDbOptions();
            using (var context = new VehicleDbContext(options))
            {
                var carId = 1;
                var vehicle = new Vehicle
                {
                    VehicleId = carId,
                    VehicleType = "Sedan",
                    Make = "Honda",
                    Model = "Civic",
                    Year = DateTime.ParseExact("01/01/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Price = 20000,
                    Color = "Blue",
                    FuelType = "Gasoline",
                    ImageUrl = "https://prod.pictures.autoscout24.net/listing-images/43b50e5e-0661-4074-a990-3ee574ec0776_601ca758-df86-480f-85ad-9f57ca4df1db.jpg/250x188.webp"
                };

                var car = new Car
                {
                    Vehicle = vehicle,
                    Kilometers = 5000,
                    NumberOfDoors = 4,
                    Description = "Reliable car",
                    Transmission = "Automatic",
                    HorsePower = 150,
                    IsDelete = false,
                    CarId = carId
                };

                await context.Cars.AddAsync(car);
                await context.SaveChangesAsync();
            }

            using (var context = new VehicleDbContext(options))
            {
                var service = new CarServices(context);

              
                var result = await service.GetCarForDeleteAsync(1);

                
                Assert.NotNull(result);
                Assert.AreEqual(1, result.VehicleId);
                Assert.AreEqual("Sedan", result.VehicleType);
                Assert.AreEqual("Civic", result.Model);
                Assert.AreEqual(20000, result.Price);
                Assert.AreEqual("Blue", result.Color);
                Assert.AreEqual("Gasoline", result.FuelType);
                Assert.AreEqual("https://prod.pictures.autoscout24.net/listing-images/43b50e5e-0661-4074-a990-3ee574ec0776_601ca758-df86-480f-85ad-9f57ca4df1db.jpg/250x188.webp", result.ImageUrl);
                Assert.AreEqual(1, result.CarId);
                Assert.AreEqual(5000, result.Kilometers);
                Assert.AreEqual(4, result.NumberOfDoors);
                Assert.AreEqual("Reliable car", result.Description);
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
                var service = new CarServices(context);

               
                var result = await service.ConfirmDeleteAsync(999); // Non-existing ID

                
                Assert.False(result);
            }
        }

    }
}

