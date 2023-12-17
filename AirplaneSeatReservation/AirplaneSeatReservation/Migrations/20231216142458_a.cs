using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirplaneSeatReservation.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartureDate",
                table: "Itinerary",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartureTime",
                table: "Itinerary",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "Itinerary");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Itinerary");
        }
    }
}
