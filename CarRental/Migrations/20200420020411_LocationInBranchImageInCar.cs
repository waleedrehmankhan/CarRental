using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class LocationInBranchImageInCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "Branchs",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "Branchs",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Branchs");
        }
    }
}
