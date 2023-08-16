using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carpool.DAL.persistence.relational.migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "College",
                columns: table => new
                {
                    CollegeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollegeName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Acronym = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_College", x => x.CollegeId);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ScheduleTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    RidePrice = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    Accepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    CampusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampusName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LineAddress = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CollegeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.CampusId);
                    table.ForeignKey(
                        name: "FK_Campus_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campus_CollegeId",
                table: "Campus",
                column: "CollegeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campus");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "College");
        }
    }
}
