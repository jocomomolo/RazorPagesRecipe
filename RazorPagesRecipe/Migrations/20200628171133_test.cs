using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesRecipe.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Owner_OwnerID",
                table: "Recipe");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerID",
                table: "Recipe",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Owner",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Owner_OwnerID",
                table: "Recipe",
                column: "OwnerID",
                principalTable: "Owner",
                principalColumn: "OwnerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Owner_OwnerID",
                table: "Recipe");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerID",
                table: "Recipe",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Owner",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Owner_OwnerID",
                table: "Recipe",
                column: "OwnerID",
                principalTable: "Owner",
                principalColumn: "OwnerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
