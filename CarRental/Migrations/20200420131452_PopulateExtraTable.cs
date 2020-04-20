using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class PopulateExtraTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO EXTRAS ( Name, Price) VALUES ('Baby Capsule', 35.0)");
            migrationBuilder.Sql("INSERT INTO EXTRAS ( Name, Price) VALUES ('Baby Seat', 35.0)");
            migrationBuilder.Sql("INSERT INTO EXTRAS ( Name, Price) VALUES ('Booster Seat', 35.0)");
            migrationBuilder.Sql("INSERT INTO EXTRAS ( Name, Price) VALUES ('Customer on P @ $7.00 Per Day.', 7.0)");
            migrationBuilder.Sql("INSERT INTO EXTRAS ( Name, Price) VALUES ('Driver Under 25(min 21yrs) @ $7.00 Per Day.', 7.0)");
            migrationBuilder.Sql("INSERT INTO EXTRAS ( Name, Price) VALUES ('G.P.S @ $9.90 Per Day.', 9.90)");
            migrationBuilder.Sql("INSERT INTO EXTRAS ( Name, Price) VALUES ('TROLLY @ $10.00 Per Day.', 10.0)");
            migrationBuilder.Sql("INSERT INTO EXTRAS ( Name, Price) VALUES ('Tyre & Windscreen Cover @ $3.90 Per Day.', 3.90)");
            migrationBuilder.Sql("INSERT INTO EXTRAS ( Name, Price) VALUES ('Additional Drivers', 11.0)");
            migrationBuilder.Sql("INSERT INTO EXTRAS ( Name, Price) VALUES ('Excess reduced to $500.00 @ $15.00 Per Day', 15.0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
