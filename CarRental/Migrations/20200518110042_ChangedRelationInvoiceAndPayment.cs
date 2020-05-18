using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class ChangedRelationInvoiceAndPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Payments_PaymentId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_PaymentId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Payments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoiceId",
                table: "Payments",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Invoices_InvoiceId",
                table: "Payments",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Invoices_InvoiceId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_InvoiceId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PaymentId",
                table: "Invoices",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Payments_PaymentId",
                table: "Invoices",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
