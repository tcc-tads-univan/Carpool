using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carpool.DAL.persistence.relational.migrations
{
    /// <inheritdoc />
    public partial class completedStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Schedule",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Schedule");
        }
    }
}
