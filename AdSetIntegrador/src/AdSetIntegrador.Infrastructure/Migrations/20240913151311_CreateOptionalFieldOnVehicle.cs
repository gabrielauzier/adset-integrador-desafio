using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdSetIntegrador.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateOptionalFieldOnVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Optional",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Optional",
                table: "Vehicles");
        }
    }
}
