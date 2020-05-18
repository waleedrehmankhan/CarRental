using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class NewFieldsInPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPaid",
                table: "Payments");

            migrationBuilder.AddColumn<string>(
                name: "PaymentType",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiptNumber",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Invoices",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ReceiptNumber",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Invoices");

            migrationBuilder.AddColumn<bool>(
                name: "isPaid",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
