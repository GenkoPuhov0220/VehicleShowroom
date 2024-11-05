using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleShowroom.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInformationInVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Color", "FuelType", "IsDelete", "Make", "Model", "Price", "VehicleType", "Year" },
                values: new object[,]
                {
                    { 1, "White", "Disel", false, "BMW", "330D E91", 21500m, "Car", new DateTime(2012, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Black", "Disel", false, "Merces", "e-clas E320CDI", 22500m, "Car", new DateTime(2006, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2);
        }
    }
}
