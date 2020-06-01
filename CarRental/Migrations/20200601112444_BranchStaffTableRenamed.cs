using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class BranchStaffTableRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBranches");

            migrationBuilder.CreateTable(
                name: "BranchStaffs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchStaffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchStaffs_Branchs_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchStaffs_AspNetUsers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchStaffs_BranchId",
                table: "BranchStaffs",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchStaffs_StaffId",
                table: "BranchStaffs",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchStaffs");

            migrationBuilder.CreateTable(
                name: "UserBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBranches_Branchs_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBranches_AspNetUsers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_BranchId",
                table: "UserBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_StaffId",
                table: "UserBranches",
                column: "StaffId");
        }
    }
}
