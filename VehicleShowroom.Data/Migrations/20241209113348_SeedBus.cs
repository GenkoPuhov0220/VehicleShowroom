using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleShowroom.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedBus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Color", "FuelType", "ImageUrl", "Make", "Model", "Price", "VehicleType", "Year" },
                values: new object[,]
                {
                    { 36, "Brown", "Diesel", "https://www.volvobuses.com/content/dam/volvo-buses/markets/master/coaches/complete-coaches/volvo-9900/2326x800-volvo-9900-CGI.jpg", "Volvo", "9900 DD", 198222m, "Bus", new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, "White", "Diesel", "https://www.route-one.net/wp-content/uploads/2021/07/MB-Tourismo-Access-test-drive-1.jpg", "Mercedes-Benz", "Tourismo", 210000m, "Bus", new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, "Blue", "Diesel", "https://apecauto.com/images/seo/model/scania/interlink.png", "Scania", "Interlink HD", 195000m, "Bus", new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, "Silver", "Diesel", "https://man.com.ge/storage/213/conversions/man-bus-lions-coach-technical-data-stage-16-9_width_800_height_450-webp.webp", "MAN", "Lion's Coach", 205000m, "Bus", new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, "Yellow", "Diesel", "https://www.truck1.eu/img/auto/fullview/9831/9831_8025162586282.jpg", "Iveco", "Crossway", 175000m, "Bus", new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, "Red", "Diesel", "https://p.turbosquid.com/ts-thumb/xu/9lCBc6/qWUpWEQM/setra_s_531_dt_tourist_bus_0006_02_2560x1440/jpg/1557836774/1920x1080/fit_q87/a84af1ae08057a519cbe2f1bce71f7ea2523dafa/setra_s_531_dt_tourist_bus_0006_02_2560x1440.jpg", "Setra", "S 531 DT", 220000m, "Bus", new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "Capacity", "Description", "HorsePower", "IsDelete", "Transmission", "VehicleId" },
                values: new object[,]
                {
                    { 2, 66, "Volvo 9700 DD is an extremely flexible double decker that offers impressive capacity and possibilities for different kinds of operations.", 445, false, "Automatic", 36 },
                    { 3, 55, "Mercedes-Benz Tourismo is a luxurious coach with great fuel efficiency and comfort.", 420, false, "Automatic", 37 },
                    { 4, 53, "Scania Interlink HD is a reliable bus designed for long-distance travel.", 410, false, "Manual", 38 },
                    { 5, 50, "MAN Lion's Coach is a high-performance coach with excellent safety features.", 430, false, "Automatic", 39 },
                    { 6, 45, "Iveco Crossway offers great versatility and efficiency for urban and suburban travel.", 400, false, "Automatic", 40 },
                    { 7, 72, "Setra S 531 DT is a modern double-decker with exceptional capacity and comfort.", 450, false, "Automatic", 41 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 41);
        }
    }
}
