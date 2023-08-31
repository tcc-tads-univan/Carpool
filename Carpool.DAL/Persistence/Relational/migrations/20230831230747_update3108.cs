using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carpool.DAL.persistence.relational.migrations
{
    /// <inheritdoc />
    public partial class update3108 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampusId",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampusId",
                table: "Schedule");
        }
    }
}
