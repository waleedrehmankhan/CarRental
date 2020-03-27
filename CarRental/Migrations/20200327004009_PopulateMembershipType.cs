using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class PopulateMembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {   
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (1,'PayAsYouGo', 0, 0, 0)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (2,'Monthly', 30, 1, 10)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (3,'Quaterly', 90, 3, 15)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (4,'Yearly', 300, 12, 20)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
