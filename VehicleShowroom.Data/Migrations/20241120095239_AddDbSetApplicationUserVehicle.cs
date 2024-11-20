using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleShowroom.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSetApplicationUserVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserVehicle_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserVehicle_Vehicles_VehicleId",
                table: "ApplicationUserVehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserVehicle",
                table: "ApplicationUserVehicle");

            migrationBuilder.RenameTable(
                name: "ApplicationUserVehicle",
                newName: "UsersVehicles");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserVehicle_VehicleId",
                table: "UsersVehicles",
                newName: "IX_UsersVehicles_VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersVehicles",
                table: "UsersVehicles",
                columns: new[] { "ApplicationUserId", "VehicleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersVehicles_AspNetUsers_ApplicationUserId",
                table: "UsersVehicles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersVehicles_Vehicles_VehicleId",
                table: "UsersVehicles",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersVehicles_AspNetUsers_ApplicationUserId",
                table: "UsersVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersVehicles_Vehicles_VehicleId",
                table: "UsersVehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersVehicles",
                table: "UsersVehicles");

            migrationBuilder.RenameTable(
                name: "UsersVehicles",
                newName: "ApplicationUserVehicle");

            migrationBuilder.RenameIndex(
                name: "IX_UsersVehicles_VehicleId",
                table: "ApplicationUserVehicle",
                newName: "IX_ApplicationUserVehicle_VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserVehicle",
                table: "ApplicationUserVehicle",
                columns: new[] { "ApplicationUserId", "VehicleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserVehicle_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserVehicle",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserVehicle_Vehicles_VehicleId",
                table: "ApplicationUserVehicle",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
