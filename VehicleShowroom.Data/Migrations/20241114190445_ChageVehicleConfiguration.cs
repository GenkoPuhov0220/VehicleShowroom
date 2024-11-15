using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleShowroom.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChageVehicleConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperCars_Vehicles_VehicleId",
                table: "SuperCars");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperCars_Vehicles_VehicleId",
                table: "SuperCars",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperCars_Vehicles_VehicleId",
                table: "SuperCars");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperCars_Vehicles_VehicleId",
                table: "SuperCars",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
