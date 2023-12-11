using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirplaneSeatReservation.Migrations
{
    /// <inheritdoc />
    public partial class addTablechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassengerName",
                table: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "PassengerID",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PassengerID",
                table: "Reservation",
                column: "PassengerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Passengers_PassengerID",
                table: "Reservation",
                column: "PassengerID",
                principalTable: "Passengers",
                principalColumn: "PassengerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Passengers_PassengerID",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_PassengerID",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "PassengerID",
                table: "Reservation");

            migrationBuilder.AddColumn<string>(
                name: "PassengerName",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
