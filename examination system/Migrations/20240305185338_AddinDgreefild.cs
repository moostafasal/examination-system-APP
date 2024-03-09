﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace examination_system.Migrations
{
    /// <inheritdoc />
    public partial class AddinDgreefild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Degree",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Exams");
        }
    }
}
