using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagementCompany.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFlightStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightStatus",
                table: "Flights");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightStatus",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
