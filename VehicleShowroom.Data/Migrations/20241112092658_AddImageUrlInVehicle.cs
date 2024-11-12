using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleShowroom.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlInVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "SuperCars");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Buses");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://d3ok64umd5ysj.cloudfront.net/dev/assets/images/gallery/alpine-white-e91-bmw-335i-wagon-estate-forgestar-f14-bagged-stance-c.jpg");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://garrybase.com/images/full/uploads/2021/AWEsL34IiTvPxXp2k8M7JcCdJrsZKJEiqimwpWpi.jpg");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://frankfurt.apollo.olxcdn.com/v1/files/r8lz4w93so09-BG/image");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://www.lectura-specs.bg/models/renamed/detail_max_retina/avtobusi-za-turisticeski-avtobusi-9700-dd-volvo-buses.jpg");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRTUkEaOz8kEyPTk3ansNtGsVrlm4zR0PBuMQ&s");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://www.hobbies.co.uk/media/catalog/product/cache/084ca19aa5ee10728706fd297654f270/1/5/156325man_1.jpg");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://ferrari-cdn.thron.com/delivery/public/thumbnail/ferrari/e9677798-7b8b-42b1-becf-387235c70b2a/bocxuw/std/488x325/e9677798-7b8b-42b1-becf-387235c70b2a?scalemode=auto");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://assets.newatlas.com/dims4/default/7afc3de/2147483647/strip/true/crop/1024x576+0+47/resize/1200x675!/quality/90/?url=http%3A%2F%2Fnewatlas-brightspot.s3.amazonaws.com%2Farchive%2Fpagani-huayra-supercar.jpg");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://www.exoticcarhacks.com/wp-content/uploads/2024/02/uFcbfiuL-scaled.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Trucks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "SuperCars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Motorcycles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Buses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "BusId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.lectura-specs.bg/models/renamed/detail_max_retina/avtobusi-za-turisticeski-avtobusi-9700-dd-volvo-buses.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://d3ok64umd5ysj.cloudfront.net/dev/assets/images/gallery/alpine-white-e91-bmw-335i-wagon-estate-forgestar-f14-bagged-stance-c.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://garrybase.com/images/full/uploads/2021/AWEsL34IiTvPxXp2k8M7JcCdJrsZKJEiqimwpWpi.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://frankfurt.apollo.olxcdn.com/v1/files/r8lz4w93so09-BG/image");

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "MotorcycleId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRTUkEaOz8kEyPTk3ansNtGsVrlm4zR0PBuMQ&s");

            migrationBuilder.UpdateData(
                table: "SuperCars",
                keyColumn: "SuperCarId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://ferrari-cdn.thron.com/delivery/public/thumbnail/ferrari/e9677798-7b8b-42b1-becf-387235c70b2a/bocxuw/std/488x325/e9677798-7b8b-42b1-becf-387235c70b2a?scalemode=auto");

            migrationBuilder.UpdateData(
                table: "SuperCars",
                keyColumn: "SuperCarId",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://assets.newatlas.com/dims4/default/7afc3de/2147483647/strip/true/crop/1024x576+0+47/resize/1200x675!/quality/90/?url=http%3A%2F%2Fnewatlas-brightspot.s3.amazonaws.com%2Farchive%2Fpagani-huayra-supercar.jpg");

            migrationBuilder.UpdateData(
                table: "SuperCars",
                keyColumn: "SuperCarId",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://www.exoticcarhacks.com/wp-content/uploads/2024/02/uFcbfiuL-scaled.jpeg");

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "VehicleId",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://www.hobbies.co.uk/media/catalog/product/cache/084ca19aa5ee10728706fd297654f270/1/5/156325man_1.jpg");
        }
    }
}
