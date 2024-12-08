using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleShowroom.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Color", "FuelType", "ImageUrl", "Make", "Model", "Price", "VehicleType", "Year" },
                values: new object[,]
                {
                    { 10, "Black", "Gasoline", "https://di-uploads-pod39.dealerinspire.com/portorchardford/uploads/2016/12/18-f150.jpg", "Ford", "F-150", 35000m, "Car", new DateTime(2018, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Blue", "Hybrid", "https://www.seegertoyota.com/static/dealer-12152/2020_Rav4_US_XLE-FWD_08W9_002.png", "Toyota", "RAV4", 30000m, "Car", new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Red", "Electric", "https://ev-database.org/img/auto/Tesla_Model_S_2016/Tesla_Model_S_2016-01@2x.jpg", "Tesla", "Model S", 79999m, "Car", new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Grey", "Diesel", "https://images.clickdealer.co.uk/vehicles/5833/5833074/large1/136953099.jpg", "Audi", "A6", 32000m, "Car", new DateTime(2017, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Green", "Gasoline", "https://example.com/jeep-wrangler.jpg", "Jeep", "Wrangler", 42000m, "Car", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Blue", "Gasoline", "https://media.ed.edmunds-media.com/honda/civic/2019/oem/2019_honda_civic_sedan_si_fq_oem_1_1600.jpg", "Honda", "Civic", 20000m, "Car", new DateTime(2019, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "Yellow", "Gasoline", "https://i.redd.it/lp5hnu6nyui51.jpg", "Ford", "Mustang", 55000m, "Car", new DateTime(2021, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Orange", "Gasoline", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT1G0QIvzNfjUC6aBI2TBa1SJsAMs9SSCDsJA&s", "Chevrolet", "Camaro", 62000m, "Car", new DateTime(2020, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "White", "Gasoline", "https://www.earnhardthyundai.com/blogs/4378/wp-content/uploads/2021/08/What-Are-the-2022-Hyundai-Elantra-N-Performance-Specs_o.jpg", "Hyundai", "Elantra", 22000m, "Car", new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "Red", "Gasoline", "https://www.carscoops.com/wp-content/uploads/2019/11/2020-Mazda3.jpg", "Mazda", "Mazda3", 23000m, "Car", new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Description", "HorsePower", "IsDelete", "Kilometers", "NumberOfDoors", "Transmission", "VehicleId" },
                values: new object[,]
                {
                    { 4, "Powerful and reliable", 375, false, 5000, 4, "Automatic", 10 },
                    { 5, "Spacious and efficient", 203, false, 25000, 5, "CVT", 11 },
                    { 6, "Luxury electric sedan", 1020, false, 10000, 4, "Automatic", 12 },
                    { 7, "Luxury sedan", 204, false, 60000, 4, "Automatic", 13 },
                    { 8, "Off-road capable", 285, false, 58912, 5, "Manual", 14 },
                    { 9, "Compact and efficient", 158, false, 30000, 4, "Automatic", 15 },
                    { 10, "Powerful sports car", 450, false, 5000, 2, "Manual", 16 },
                    { 11, "Stylish and fast", 650, false, 15000, 2, "Automatic", 17 },
                    { 12, "Reliable and affordable", 147, false, 20000, 4, "Automatic", 18 },
                    { 13, "Sporty and compact", 186, false, 10000, 4, "Automatic", 19 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19);
        }
    }
}
