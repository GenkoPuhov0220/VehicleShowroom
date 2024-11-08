using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleShowroom.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Description", "ImageUrl", "Kilometers", "NumberOfDoors", "VehicleId" },
                values: new object[,]
                {
                    { 1, "Fast and comfort", "https://d3ok64umd5ysj.cloudfront.net/dev/assets/images/gallery/alpine-white-e91-bmw-335i-wagon-estate-forgestar-f14-bagged-stance-c.jpg", 150000, 4, 1 },
                    { 2, "Lazy car", "https://garrybase.com/images/full/uploads/2021/AWEsL34IiTvPxXp2k8M7JcCdJrsZKJEiqimwpWpi.jpg", 300000, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Color", "FuelType", "IsDelete", "Make", "Model", "Price", "VehicleType", "Year" },
                values: new object[] { 3, "White", "Petrol", false, "AUDI", "A8 Long", 150000m, "Car", new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Description", "ImageUrl", "Kilometers", "NumberOfDoors", "VehicleId" },
                values: new object[] { 3, "Luxury car", "https://frankfurt.apollo.olxcdn.com/v1/files/r8lz4w93so09-BG/image", 22200, 4, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3);
        }
    }
}
