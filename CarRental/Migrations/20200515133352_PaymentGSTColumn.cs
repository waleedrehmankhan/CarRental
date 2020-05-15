using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class PaymentGSTColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "GST",
                table: "Payments",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GST",
                table: "Payments");
        }
    }
}
