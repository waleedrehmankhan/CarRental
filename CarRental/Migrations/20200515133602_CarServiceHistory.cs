using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class CarServiceHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceHistory_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistory_CarId",
                table: "ServiceHistory",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceHistory");
        }
    }
}
