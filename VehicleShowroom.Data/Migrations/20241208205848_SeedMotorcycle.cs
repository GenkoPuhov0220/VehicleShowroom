using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleShowroom.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMotorcycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Color", "FuelType", "ImageUrl", "Make", "Model", "Price", "VehicleType", "Year" },
                values: new object[,]
                {
                    { 26, "Blue", "Petrol", "https://cdn.dealerspike.com/imglib/v1/800x600/imglib/Assets/Inventory/94/0D/940D9D71-4E7E-4D5B-8D0A-6453F832FCED.jpg", "Yamaha", "MT-07", 7800m, "Motorcycle", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, "Green", "Petrol", "https://imotorbike-wp-media.s3.ap-southeast-1.amazonaws.com/2020/11/2021-Kawasaki-Ninja-ZX-10RR-2-1-1000x600.jpg", "Kawasaki", "Ninja ZX-10R", 15000m, "Motorcycle", new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, "Red", "Petrol", "https://suzukicycles.com/-/media/project/cycles/images/products/motorcycles/gsx-r750/2022/promo/2022_gsx-r750_header_2500x1227.jpg?mw=2560&w=2560&hash=4F73518A00243A0350150515346531DA", "Suzuki", "GSX-R750", 12500m, "Motorcycle", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, "White", "Petrol", "https://images.ctfassets.net/o6sr41tx16eu/7M52Hm6hoBznVK87muKiTM/646a09e80cd8dbd7c6b60a4228a46d10/DUCATI_PANIGALE_V2__2__UC173828_High_1920x960.jpg", "Ducati", "Panigale V2", 18000m, "Motorcycle", new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, "Black", "Petrol", "https://img.gta5-mods.com/q95/images/bmw-s1000rr-2021-black-livery/eb828f-bmws1000rr1-compressed.jpg", "BMW", "S1000RR", 19000m, "Motorcycle", new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, "Orange", "Petrol", "https://ricks-motorcycles.com/wp-content/uploads/2021/11/Harley-Davidson-Sportster-S-Ricks-Custombike-002.jpg", "Harley-Davidson", "Sportster S", 15000m, "Motorcycle", new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, "Silver", "Petrol", "https://cdn.dealerwebs.co.uk/uploads/images/triumph/2023/street-triple-765-r/street-triple-r-f-2.jpg", "Triumph", "Street Triple", 12000m, "Motorcycle", new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, "Orange", "Petrol", "https://press.ktm.com/Content/598149/26736ab1-8a7c-450c-8339-26e87cad5364/1200/2400/.jpg", "KTM", "Duke 890", 11000m, "Motorcycle", new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, "Red", "Petrol", "https://riders.drivemag.com/wp-content/uploads/2020/08/2021-Honda-CBR600RR-production-form-01.jpg", "Honda", "CBR600RR", 14000m, "Motorcycle", new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, "Blue", "Petrol", "https://www.philharmonicmoto.com/wp-content/uploads/2024/11/01-Aprilia_RS-660_Blue-Marlin-600x450.jpg", "Aprilia", "RS 660", 13500m, "Motorcycle", new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Motorcycles",
                columns: new[] { "MotorcycleId", "IsDelete", "Kw", "VehicleId" },
                values: new object[,]
                {
                    { 2, false, 73, 26 },
                    { 3, false, 147, 27 },
                    { 4, false, 110, 28 },
                    { 5, false, 155, 29 },
                    { 6, false, 207, 30 },
                    { 7, false, 90, 31 },
                    { 8, false, 123, 32 },
                    { 9, false, 105, 33 },
                    { 10, false, 119, 34 },
                    { 11, false, 100, 35 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "MotorcycleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "MotorcycleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "MotorcycleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "MotorcycleId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "MotorcycleId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "MotorcycleId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "MotorcycleId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "MotorcycleId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "MotorcycleId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "MotorcycleId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 35);
        }
    }
}
