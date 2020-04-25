using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class RemoveWrongMigrationAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Branchs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Branchs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Branchs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Branchs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Branchs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Branchs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Branchs");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
