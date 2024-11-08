using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleShowroom.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMotorcycleAndFixDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Motorcycles");

            migrationBuilder.AddColumn<string>(
                name: "Transmission",
                table: "Trucks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Transmission",
                table: "Cars",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Transmission",
                table: "Buses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 1,
                column: "Transmission",
                value: "Automatic");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                column: "Transmission",
                value: "Automatic");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                column: "Transmission",
                value: "Automatic");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                column: "Transmission",
                value: "Automatic");

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Color", "FuelType", "IsDelete", "Make", "Model", "Price", "VehicleType", "Year" },
                values: new object[] { 5, "red", "Petrol", false, "Honda", "450", 19800m, "Motorcycle", new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Motorcycles",
                columns: new[] { "MotorcycleId", "ImageUrl", "Kw", "VehicleId" },
                values: new object[] { 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRTUkEaOz8kEyPTk3ansNtGsVrlm4zR0PBuMQ&s", 45, 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "MotorcycleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Buses");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Motorcycles",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }
    }
}
