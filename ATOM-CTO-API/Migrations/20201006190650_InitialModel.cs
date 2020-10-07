using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATOM_CTO_API.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationPoints",
                columns: table => new
                {
                    Latitude = table.Column<decimal>(type: "DECIMAL(9,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "DECIMAL(9,6)", nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationPoints", x => new { x.Latitude, x.Longitude });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationPoints");
        }
    }
}
