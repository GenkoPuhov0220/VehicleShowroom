using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleShowroom.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInformationSuperCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Color", "FuelType", "IsDelete", "Make", "Model", "Price", "VehicleType", "Year" },
                values: new object[,]
                {
                    { 7, "Crimson Red", "Petrol", false, "Ferrari", "F8", 450000m, "Supercar", new DateTime(2022, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Carbon Fiber Black", "Petrol", false, "Pagani", "Huayra", 3400000m, "Supercar", new DateTime(2022, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Lamborghini Yellow", "Petrol", false, "Lamborghini", "Aventador", 550000m, "Supercar", new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SuperCars",
                columns: new[] { "SuperCarId", "Description", "HorsePower", "ImageUrl", "Kilometers", "MaxSpeed", "NumberOfDoors", "Transmission", "VehicleId", "Weight" },
                values: new object[,]
                {
                    { 1, "The F8 Tributo uses the same engine from the 488 Pista, a 3.9 L twin-turbocharged V8 engine with a power output of 720 PS (530 kW; 710 hp) at 8000 rpm and 770 N⋅m (568 lb⋅ft) of torque at 3250 rpm", 710, "https://ferrari-cdn.thron.com/delivery/public/thumbnail/ferrari/e9677798-7b8b-42b1-becf-387235c70b2a/bocxuw/std/488x325/e9677798-7b8b-42b1-becf-387235c70b2a?scalemode=auto", 8500, "350", 2, "Dual-Clutch Automatic", 7, "1400" },
                    { 2, "The Pagani Huayra is a masterpiece of automotive engineering, renowned for its breathtaking design and performance. With an aerodynamic, lightweight body crafted from carbon-titanium, it achieves exceptional speed and agility. The Huayra’s performance is complemented by luxurious Italian craftsmanship and cutting-edge technology, making it a unique blend of art and science on wheels.", 791, "https://assets.newatlas.com/dims4/default/7afc3de/2147483647/strip/true/crop/1024x576+0+47/resize/1200x675!/quality/90/?url=http%3A%2F%2Fnewatlas-brightspot.s3.amazonaws.com%2Farchive%2Fpagani-huayra-supercar.jpg", 1500, "383", 2, "7-Speed Sequential Manual", 8, "1350" },
                    { 3, "The Lamborghini Aventador is an iconic supercar that combines Lamborghini's signature aggressive design with world-class performance. Equipped with a naturally aspirated V12 engine, it delivers a raw and thrilling driving experience. The Aventador is known for its sharp lines, scissor doors, and a commanding presence, making it a favorite among supercar enthusiasts.", 769, "https://www.exoticcarhacks.com/wp-content/uploads/2024/02/uFcbfiuL-scaled.jpeg", 3200, "355", 2, "7-Speed Automated Manual (ISR)", 9, "1575" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperCars",
                keyColumn: "SuperCarId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SuperCars",
                keyColumn: "SuperCarId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SuperCars",
                keyColumn: "SuperCarId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9);
        }
    }
}
