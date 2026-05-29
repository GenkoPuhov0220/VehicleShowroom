using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleShowroom.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehiclesImages",
                columns: table => new
                {
                    VehicleImagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesImages", x => x.VehicleImagesId);
                    table.ForeignKey(
                        name: "FK_VehiclesImages_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesImages_VehicleId",
                table: "VehiclesImages",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiclesImages");
        }
    }
}
