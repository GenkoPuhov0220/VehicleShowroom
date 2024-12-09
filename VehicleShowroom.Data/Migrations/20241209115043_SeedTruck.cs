using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleShowroom.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedTruck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Color", "FuelType", "ImageUrl", "Make", "Model", "Price", "VehicleType", "Year" },
                values: new object[,]
                {
                    { 42, "White", "Diesel", "https://cdn.truckscout24.com/data/listing/img/hdv/ts/18/68/17618278-01.jpg?v=1730896061", "Volvo", "FH16", 220000m, "Truck", new DateTime(2018, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, "Blue", "Diesel", "https://img.youtube.com/vi/BMjpiXe9MEY/sddefault.jpg", "Scania", "R500", 210000m, "Truck", new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, "Silver", "Diesel", "https://www.modelsnavigator.com/buxus/images/fotogaleria/modelsnavigator.com/katalog_produktov/modely_uzitkovych_vozidiel/modely_kamionov/mercedes-benz_actros_mp4_strieborna_farba/TR124.22.jpg", "Mercedes", "Actros", 230000m, "Truck", new DateTime(2020, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, "Red", "Diesel", "https://www.truckpages.co.uk/wp-content/uploads/2024/08/29/1a0034d8d5.jpg.webp", "DAF", "XF", 240000m, "Truck", new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, "Black", "Diesel", "https://cdn.webshopapp.com/shops/76444/files/418915046/650x650x2/solarguard-onderspoiler-iveco-s-way.jpg", "Iveco", "S-Way", 250000m, "Truck", new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, "Green", "Diesel", "https://d29qvoplt93a6w.cloudfront.net/efs/wp/domains/www.exceltruckgroup.com/wp-content/uploads/2022/11/1667569543479.jpg", "Kenworth", "T680", 200000m, "Truck", new DateTime(2017, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, "Yellow", "Diesel", "https://static.truckmarket.com/wp-content/uploads/trucks/129413/2018-peterbilt-579-daycab-472914-23.jpg", "Peterbilt", "579", 205000m, "Truck", new DateTime(2018, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, "Brown", "Diesel", "https://www.macktrucks.com/mack-news/2019/media_13ab286fb6f1e4155c5f435b46c86e439cd34075f.png?width=1200&format=pjpg&optimize=medium", "Mack", "Anthem", 215000m, "Truck", new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, "Purple", "Diesel", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQLN308QJPQH7M4ymPQ2SCWu8MFjnAIAwI_Aw&s", "Freightliner", "Cascadia", 225000m, "Truck", new DateTime(2020, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Trucks",
                columns: new[] { "VehicleId", "CargoCapacity", "Description", "EuroNumber", "HorsePower", "IsDelete", "Transmission", "TruckId" },
                values: new object[,]
                {
                    { 42, 14000, "Efficient hauler", "Euro 6", 750, false, "Manual", 2 },
                    { 43, 13000, "Heavy-duty performer", "Euro 6", 700, false, "Automatic", 3 },
                    { 44, 15000, "Long-haul specialist", "Euro 6", 800, false, "Automatic", 4 },
                    { 45, 16000, "Reliable and powerful", "Euro 6", 850, false, "Manual", 5 },
                    { 46, 14000, "Modern and efficient", "Euro 6", 780, false, "Automatic", 6 },
                    { 47, 12500, "Durable and agile", "Euro 5", 690, false, "Manual", 7 },
                    { 48, 13500, "Cost-effective", "Euro 6", 720, false, "Automatic", 8 },
                    { 49, 14500, "High-performance", "Euro 6", 760, false, "Manual", 9 },
                    { 50, 15500, "Future-ready", "Euro 6", 810, false, "Automatic", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "VehicleId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "VehicleId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "VehicleId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "VehicleId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "VehicleId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "VehicleId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "VehicleId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "VehicleId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "VehicleId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 50);
        }
    }
}
