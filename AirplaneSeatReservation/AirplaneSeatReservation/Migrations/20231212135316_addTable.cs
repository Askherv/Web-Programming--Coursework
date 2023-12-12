using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirplaneSeatReservation.Migrations
{
    /// <inheritdoc />
    public partial class addTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    AircraftID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AircraftModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AircraftSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.AircraftID);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PassengerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerBirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PassengerGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassengerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerID);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    RouteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartureCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalCity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.RouteID);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    UserAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CPassword = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.UserAccountID);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AircraftID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightID);
                    table.ForeignKey(
                        name: "FK_Flight_Aircraft_AircraftID",
                        column: x => x.AircraftID,
                        principalTable: "Aircraft",
                        principalColumn: "AircraftID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_Route_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Route",
                        principalColumn: "RouteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlightID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservation_Flight_FlightID",
                        column: x => x.FlightID,
                        principalTable: "Flight",
                        principalColumn: "FlightID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Passengers_PassengerID",
                        column: x => x.PassengerID,
                        principalTable: "Passengers",
                        principalColumn: "PassengerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AircraftID",
                table: "Flight",
                column: "AircraftID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_RouteID",
                table: "Flight",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_FlightID",
                table: "Reservation",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PassengerID",
                table: "Reservation",
                column: "PassengerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "Route");
        }
    }
}
