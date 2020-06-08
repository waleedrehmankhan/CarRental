using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class ServiceHistoryNewAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amoune",
                table: "ServiceHistory",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ServicingType",
                table: "ServiceHistory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amoune",
                table: "ServiceHistory");

            migrationBuilder.DropColumn(
                name: "ServicingType",
                table: "ServiceHistory");
        }
    }
}
