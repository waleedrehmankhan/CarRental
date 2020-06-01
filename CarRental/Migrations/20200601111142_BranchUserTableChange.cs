using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class BranchUserTableChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_AspNetUsers_UserId1",
                table: "UserBranches");

            migrationBuilder.DropIndex(
                name: "IX_UserBranches_UserId1",
                table: "UserBranches");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserBranches");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserBranches");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "UserBranches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "UserBranches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_ApplicationUserId1",
                table: "UserBranches",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_AspNetUsers_ApplicationUserId1",
                table: "UserBranches",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_AspNetUsers_ApplicationUserId1",
                table: "UserBranches");

            migrationBuilder.DropIndex(
                name: "IX_UserBranches_ApplicationUserId1",
                table: "UserBranches");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserBranches");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "UserBranches");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserBranches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserBranches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_UserId1",
                table: "UserBranches",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_AspNetUsers_UserId1",
                table: "UserBranches",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
