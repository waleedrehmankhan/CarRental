using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class FromAndToBranchKeyInBranchTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualReturnDate",
                table: "Bookings",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "FromBranchId",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToBranchId",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FromBranchId",
                table: "Bookings",
                column: "FromBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ToBranchId",
                table: "Bookings",
                column: "ToBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Branchs_FromBranchId",
                table: "Bookings",
                column: "FromBranchId",
                principalTable: "Branchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Branchs_ToBranchId",
                table: "Bookings",
                column: "ToBranchId",
                principalTable: "Branchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Branchs_FromBranchId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Branchs_ToBranchId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_FromBranchId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ToBranchId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "FromBranchId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ToBranchId",
                table: "Bookings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualReturnDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
