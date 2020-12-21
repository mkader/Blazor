using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfJoin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberType = table.Column<int>(type: "int", nullable: false),
                    StoreID = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreID);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "DateOfJoin", "Email", "FirstName", "Image", "LastName", "MemberType", "StoreID" },
                values: new object[,]
                {
                    { 100, new DateTime(1980, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bugs.Bunny@dns.com", "Bugs", "images/bugs.png", "Bunny", 0, 1 },
                    { 200, new DateTime(1981, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Winnie.Pooh@dns.com", "Winnie", "images/winnie.png", "Pooh", 2, 2 },
                    { 300, new DateTime(1979, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mickey.Mouse@dns.com", "Mickey", "images/mickey.png", "Mouse", 1, 3 },
                    { 400, new DateTime(1982, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Donald.Duck@dns.com", "Donald", "images/donald.png", "Duck", 0, 4 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreID", "StoreName" },
                values: new object[,]
                {
                    { 1, "TXIRV" },
                    { 2, "WIMAD" },
                    { 3, "NEBEL" },
                    { 4, "TXDFW" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
