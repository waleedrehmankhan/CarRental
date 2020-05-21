using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class AddressSuburbField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PriceType",
                table: "Extras",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suburb",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suburb",
                table: "Branchs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Suburb",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Suburb",
                table: "Branchs");

            migrationBuilder.AlterColumn<string>(
                name: "PriceType",
                table: "Extras",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
