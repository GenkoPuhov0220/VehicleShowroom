using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleShowroom.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedSuperCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Color", "FuelType", "ImageUrl", "Make", "Model", "Price", "VehicleType", "Year" },
                values: new object[,]
                {
                    { 20, "Verde Mantis", "Petrol", "https://www.ilusso.com/imagetag/3092/main/l/Used-2023-Lamborghini-Huracan-EVO-Spyder-1712261384.jpg", "Lamborghini", "Huracán EVO", 260000m, "Supercar", new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "Blue/Black", "Petrol", "https://news.dupontregistry.com/wp-content/uploads/2023/08/download---2023-07-26t155244.828-scaled.jpg", "Bugatti", "Chiron", 3000000m, "Supercar", new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "Aurora Blue", "Petrol", "https://www.alastairbols.com/wp-content/uploads/2020/03/McLaren-720S-Performance-Aurora-Blue-for-sale-18-of-33.jpg", "McLaren", "720S", 310000m, "Supercar", new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "Jet Black Metallic", "Petrol", "https://vehicle-images.dealerinspire.com/8b2a-210007648/WP0AD2A99PS259634/450d491619af6ccbc6f3ad2e0f1a647e.jpg", "Porsche", "911 Turbo S", 230000m, "Supercar", new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "British Racing Green", "Hybrid", "https://www.astonmartin.com/-/media/aston-martin/images/default-source/models/valkyrie/valkyrie-retouched-nov21.jpg?mw=1920&rev=1e80dbb7953e4852bce3dfc43db4f69a&hash=2C97098139E6221C651689CFD85A296E", "Aston Martin", "Valkyrie", 3000000m, "Supercar", new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "Gunpowder Grey", "Petrol", "https://imodels.com.pl/wp-content/uploads/2023/11/9207180cb86955e787bd27e64fe07933-scaled.jpg", "Koenigsegg", "Jesko Absolut", 3500000m, "Supercar", new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SuperCars",
                columns: new[] { "SuperCarId", "Description", "HorsePower", "IsDelete", "Kilometers", "MaxSpeed", "NumberOfDoors", "Transmission", "VehicleId", "Weight" },
                values: new object[,]
                {
                    { 4, "The Huracán EVO features a naturally aspirated 5.2 L V10 engine producing 640 hp and 600 Nm of torque.", 640, false, 3000, "325", 2, "7-Speed Automatic", 20, "1382" },
                    { 5, "The Bugatti Chiron boasts an 8.0 L quad-turbocharged W16 engine with 1,479 hp and 1,600 Nm of torque.", 1479, false, 500, "420", 2, "7-Speed Dual-Clutch", 21, "1995" },
                    { 6, "Powered by a 4.0 L twin-turbocharged V8 engine, the McLaren 720S produces 710 hp and 770 Nm of torque.", 710, false, 12000, "341", 2, "7-Speed Dual-Clutch", 22, "1283" },
                    { 7, "The 911 Turbo S comes with a 3.8 L twin-turbocharged flat-six engine, producing 640 hp and 800 Nm of torque.", 640, false, 8000, "330", 2, "8-Speed PDK", 23, "1640" },
                    { 8, "The Valkyrie has a 6.5 L naturally aspirated V12 engine paired with an electric motor, producing a combined output of 1160 hp.", 1160, false, 1000, "402", 2, "7-Speed Single Clutch", 24, "1130" },
                    { 9, "The Jesko Absolut is powered by a 5.0 L twin-turbocharged V8 engine producing 1600 hp with E85 fuel.", 1600, false, 200, "483", 2, "9-Speed Koenigsegg Light Speed Transmission", 25, "1320" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperCars",
                keyColumn: "SuperCarId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SuperCars",
                keyColumn: "SuperCarId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SuperCars",
                keyColumn: "SuperCarId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SuperCars",
                keyColumn: "SuperCarId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SuperCars",
                keyColumn: "SuperCarId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SuperCars",
                keyColumn: "SuperCarId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 25);
        }
    }
}
