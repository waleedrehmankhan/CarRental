using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class BugsInBranchUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "StaffId",
                table: "UserBranches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_StaffId",
                table: "UserBranches",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_AspNetUsers_StaffId",
                table: "UserBranches",
                column: "StaffId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_AspNetUsers_StaffId",
                table: "UserBranches");

            migrationBuilder.DropIndex(
                name: "IX_UserBranches_StaffId",
                table: "UserBranches");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "UserBranches");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "UserBranches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "UserBranches",
                type: "nvarchar(450)",
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
    }
}
