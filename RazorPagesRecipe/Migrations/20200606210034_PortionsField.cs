﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesRecipe.Migrations
{
    public partial class PortionsField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Portions",
                table: "Recipe",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Portions",
                table: "Recipe");
        }
    }
}
