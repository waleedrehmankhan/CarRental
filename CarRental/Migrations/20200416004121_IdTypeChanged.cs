using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class IdTypeChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarClassification_CarClassificationId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branchs",
                table: "Branchs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarClassification",
                table: "CarClassification");

            migrationBuilder.DropColumn(
                name: "CarID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "BranchID",
                table: "Branchs");

            migrationBuilder.RenameTable(
                name: "CarClassification",
                newName: "Classifications");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cars",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Branchs",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branchs",
                table: "Branchs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classifications",
                table: "Classifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Classifications_CarClassificationId",
                table: "Cars",
                column: "CarClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Classifications_CarClassificationId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branchs",
                table: "Branchs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classifications",
                table: "Classifications");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Branchs");

            migrationBuilder.RenameTable(
                name: "Classifications",
                newName: "CarClassification");

            migrationBuilder.AddColumn<long>(
                name: "CarID",
                table: "Cars",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "BranchID",
                table: "Branchs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "CarID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branchs",
                table: "Branchs",
                column: "BranchID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarClassification",
                table: "CarClassification",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarClassification_CarClassificationId",
                table: "Cars",
                column: "CarClassificationId",
                principalTable: "CarClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
