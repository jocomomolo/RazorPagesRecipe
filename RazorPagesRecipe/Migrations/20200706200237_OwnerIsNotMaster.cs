using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesRecipe.Migrations
{
    public partial class OwnerIsNotMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Category_CategoryID",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Owner");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Recipe",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Category_CategoryID",
                table: "Recipe",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Category_CategoryID",
                table: "Recipe");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Recipe",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Owner",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Category_CategoryID",
                table: "Recipe",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
