using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirplaneSeatReservation.Migrations
{
    /// <inheritdoc />
    public partial class vtguncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Flight");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "Flight",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
