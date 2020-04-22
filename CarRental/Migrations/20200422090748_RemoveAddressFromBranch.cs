using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class RemoveAddressFromBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Branchs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Branchs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Branchs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Branchs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Branchs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Branchs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
