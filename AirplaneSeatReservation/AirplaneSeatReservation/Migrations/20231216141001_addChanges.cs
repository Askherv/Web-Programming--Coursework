using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirplaneSeatReservation.Migrations
{
    /// <inheritdoc />
    public partial class addChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Route_RouteID",
                table: "Flight");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.RenameColumn(
                name: "RouteID",
                table: "Flight",
                newName: "ItineraryID");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_RouteID",
                table: "Flight",
                newName: "IX_Flight_ItineraryID");

            migrationBuilder.CreateTable(
                name: "Itinerary",
                columns: table => new
                {
                    ItineraryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureAirport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalAirport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itinerary", x => x.ItineraryID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Itinerary_ItineraryID",
                table: "Flight",
                column: "ItineraryID",
                principalTable: "Itinerary",
                principalColumn: "ItineraryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Itinerary_ItineraryID",
                table: "Flight");

            migrationBuilder.DropTable(
                name: "Itinerary");

            migrationBuilder.RenameColumn(
                name: "ItineraryID",
                table: "Flight",
                newName: "RouteID");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_ItineraryID",
                table: "Flight",
                newName: "IX_Flight_RouteID");

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    RouteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureCity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.RouteID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Route_RouteID",
                table: "Flight",
                column: "RouteID",
                principalTable: "Route",
                principalColumn: "RouteID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
