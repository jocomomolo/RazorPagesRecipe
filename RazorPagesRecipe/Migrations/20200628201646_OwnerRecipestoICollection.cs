using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesRecipe.Migrations
{
    public partial class OwnerRecipestoICollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Category_CategoryID",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Owner_OwnerID",
                table: "Recipe");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerID",
                table: "Recipe",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Recipe",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Category_CategoryID",
                table: "Recipe",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Owner_OwnerID",
                table: "Recipe",
                column: "OwnerID",
                principalTable: "Owner",
                principalColumn: "OwnerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Category_CategoryID",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Owner_OwnerID",
                table: "Recipe");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerID",
                table: "Recipe",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Recipe",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Category_CategoryID",
                table: "Recipe",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Owner_OwnerID",
                table: "Recipe",
                column: "OwnerID",
                principalTable: "Owner",
                principalColumn: "OwnerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
