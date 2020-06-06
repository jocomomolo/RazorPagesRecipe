using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesRecipe.Migrations
{
    public partial class VegetarianField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Vegetarian",
                table: "Recipe",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vegetarian",
                table: "Recipe");
        }
    }
}
