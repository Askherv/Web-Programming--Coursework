using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirplaneSeatReservation.Migrations
{
    /// <inheritdoc />
    public partial class auth4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Admin",
                newName: "AdminPassword");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Admin",
                newName: "AdminEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdminPassword",
                table: "Admin",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "AdminEmail",
                table: "Admin",
                newName: "Email");
        }
    }
}
