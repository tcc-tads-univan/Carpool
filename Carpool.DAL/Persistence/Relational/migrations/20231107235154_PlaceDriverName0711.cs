﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carpool.DAL.persistence.relational.migrations
{
    /// <inheritdoc />
    public partial class PlaceDriverName0711 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlaceId",
                table: "Campus",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Campus");
        }
    }
}
