using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RazorPagesRecipe.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientMeasurement_Ingredient_IngredientID",
                table: "IngredientMeasurement");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientMeasurement_Measurement_MeasurementID",
                table: "IngredientMeasurement");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Ingredient_IngredientID",
                table: "RecipeIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Recipe_RecipeID",
                table: "RecipeIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measurement",
                table: "Measurement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Measurement");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "RecipeID",
                table: "Recipe",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Recipe",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CookingTime",
                table: "Recipe",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreparationTime",
                table: "Recipe",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalTime",
                table: "Recipe",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeasurementID",
                table: "Measurement",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "IngredientID",
                table: "Ingredient",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "RecipeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measurement",
                table: "Measurement",
                column: "MeasurementID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "IngredientID");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_CategoryID",
                table: "Recipe",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientMeasurement_Ingredient_IngredientID",
                table: "IngredientMeasurement",
                column: "IngredientID",
                principalTable: "Ingredient",
                principalColumn: "IngredientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientMeasurement_Measurement_MeasurementID",
                table: "IngredientMeasurement",
                column: "MeasurementID",
                principalTable: "Measurement",
                principalColumn: "MeasurementID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Category_CategoryID",
                table: "Recipe",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Ingredient_IngredientID",
                table: "RecipeIngredient",
                column: "IngredientID",
                principalTable: "Ingredient",
                principalColumn: "IngredientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Recipe_RecipeID",
                table: "RecipeIngredient",
                column: "RecipeID",
                principalTable: "Recipe",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientMeasurement_Ingredient_IngredientID",
                table: "IngredientMeasurement");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientMeasurement_Measurement_MeasurementID",
                table: "IngredientMeasurement");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Category_CategoryID",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Ingredient_IngredientID",
                table: "RecipeIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Recipe_RecipeID",
                table: "RecipeIngredient");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_CategoryID",
                table: "Recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measurement",
                table: "Measurement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "CookingTime",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "PreparationTime",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "TotalTime",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "MeasurementID",
                table: "Measurement");

            migrationBuilder.DropColumn(
                name: "IngredientID",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Measurement",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measurement",
                table: "Measurement",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientMeasurement_Ingredient_IngredientID",
                table: "IngredientMeasurement",
                column: "IngredientID",
                principalTable: "Ingredient",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientMeasurement_Measurement_MeasurementID",
                table: "IngredientMeasurement",
                column: "MeasurementID",
                principalTable: "Measurement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Ingredient_IngredientID",
                table: "RecipeIngredient",
                column: "IngredientID",
                principalTable: "Ingredient",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Recipe_RecipeID",
                table: "RecipeIngredient",
                column: "RecipeID",
                principalTable: "Recipe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
