using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carpool.DAL.persistence.relational.migrations
{
    /// <inheritdoc />
    public partial class DbDriverName0311 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DriverName",
                table: "Schedule",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Schedule",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverName",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Schedule");
        }
    }
}
