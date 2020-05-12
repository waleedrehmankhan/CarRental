using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class SeedUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO AspNetRoles ( Id, Name, NormalizedName ) VALUES (1, 'Admin', 'Admin')");
            migrationBuilder.Sql("INSERT INTO AspNetRoles ( Id, Name, NormalizedName ) VALUES (2, 'Staff', 'Staff')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
