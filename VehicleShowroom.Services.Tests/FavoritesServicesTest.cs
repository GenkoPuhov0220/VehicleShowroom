using Moq;

using VehicleShowroom.Data.Models;
using VehicleShowroom.Data;
using VehicleShowroom.Services.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace VehicleShowroom.Services.Tests
{
    [TestFixture]
    public class FavoritesServicesTest
    {
        [Test]
        public async Task GetIndexFavorites_ReturnUserFavorites_WhenFavoritesExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<VehicleDbContext>()
                .UseInMemoryDatabase(databaseName: "VehicleShowrromTest")
                .Options;

            await using var context = new VehicleDbContext(options);

            // Mock user data
            var userId = "UserIdtests";
            var vehicle = new Vehicle
            {
                VehicleId = 1,
                VehicleType = "Car",
                Model = "Model X",
                Make = "Tesla",
                Year = new DateTime(2012, 08, 12),
                Price = 80000,
                Color = "Red",
                FuelType = "Electric",
                ImageUrl = "UrlTest"
            };

            context.UsersVehicles.Add(new ApplicationUserVehicle
            {
                ApplicationUserId = userId,
                VehicleId = vehicle.VehicleId,
                Vehicle = vehicle
            });
            await context.SaveChangesAsync();

            var userManagerMock = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null
            );

            var service = new FavoritesServices(context, userManagerMock.Object);

            // Act
            var result = await service.GetIndexFavoritesAsync(userId);

            // Assert
            Assert.NotNull(result);
            var favorite = result.FirstOrDefault();
            Assert.NotNull(favorite);
            Assert.AreEqual(vehicle.VehicleType, favorite.VehicleType);
            Assert.AreEqual(vehicle.Model, favorite.Model);
            Assert.AreEqual(vehicle.Make, favorite.Make);
        }
        [Test]
        public async Task GetIndexFavorites_ReturnEmptyList_WhenNoFavoritesExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<VehicleDbContext>()
                .UseInMemoryDatabase(databaseName: "VehicleShowrromTest_Empty")
                .Options;

            await using var context = new VehicleDbContext(options);

            var userManagerMock = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null
            );

            var service = new FavoritesServices(context, userManagerMock.Object);

            // Act
            var result = await service.GetIndexFavoritesAsync("nonExistentUserId");

            // Assert
            Assert.NotNull(result);
            Assert.IsEmpty(result);
        }
       
        [Test]
        public async Task AddToFavorites_ReturnFalse_WhenVehicleDoesNotExist()
        {
            
            var options = new DbContextOptionsBuilder<VehicleDbContext>()
                .UseInMemoryDatabase(databaseName: "VehicleShowroom_AddToFavorite")
                .Options;

            await using var context = new VehicleDbContext(options);

            var userId = "UserIdTest";
            var vehicleId = 1; // No vehicle in the database with this ID

            var userManagerMock = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null
            );

            var service = new FavoritesServices(context, userManagerMock.Object);

            var result = await service.AddToFavoritesAsync(userId, vehicleId);

            Assert.False(result);
            Assert.IsEmpty(context.UsersVehicles);
        }
        
        [Test]
        public async Task RemoveFromFavoritesAsync_ShouldReturnFalse_WhenVehicleDoesNotExist()
        {
          
            var options = new DbContextOptionsBuilder<VehicleDbContext>()
                .UseInMemoryDatabase(databaseName: "RemoveFromFavoritesTestDb2")
                .Options;

            await using var context = new VehicleDbContext(options);

            var userId = "testUserId";
            var vehicleId = 1; // Vehicle with this ID doesn't exist

            var userManagerMock = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null
            );

            var service = new FavoritesServices(context, userManagerMock.Object);

            var result = await service.RemoveFromFavoritesAsync(userId, vehicleId);

            Assert.False(result);
            Assert.IsEmpty(context.UsersVehicles);
        }
    }
}


