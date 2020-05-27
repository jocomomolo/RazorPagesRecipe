using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RazorPagesRecipe.Migrations
{
    public partial class AddUtensil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utensil",
                columns: table => new
                {
                    UtensilID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utensil", x => x.UtensilID);
                });

            migrationBuilder.CreateTable(
                name: "RecipeUtensil",
                columns: table => new
                {
                    RecipeID = table.Column<int>(nullable: false),
                    UtensilID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeUtensil", x => new { x.RecipeID, x.UtensilID });
                    table.ForeignKey(
                        name: "FK_RecipeUtensil_Recipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipe",
                        principalColumn: "RecipeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeUtensil_Utensil_UtensilID",
                        column: x => x.UtensilID,
                        principalTable: "Utensil",
                        principalColumn: "UtensilID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeUtensil_UtensilID",
                table: "RecipeUtensil",
                column: "UtensilID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeUtensil");

            migrationBuilder.DropTable(
                name: "Utensil");
        }
    }
}
