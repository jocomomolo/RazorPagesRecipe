using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RazorPagesRecipe.Migrations
{
    public partial class ChangeMeasurementToOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_Ingredient_IngredientID",
                table: "Measurement");

            migrationBuilder.DropIndex(
                name: "IX_Measurement_IngredientID",
                table: "Measurement");

            migrationBuilder.DropColumn(
                name: "IngredientID",
                table: "Measurement");

            migrationBuilder.AlterColumn<int>(
                name: "MeasurementID",
                table: "Measurement",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_Ingredient_MeasurementID",
                table: "Measurement",
                column: "MeasurementID",
                principalTable: "Ingredient",
                principalColumn: "IngredientID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_Ingredient_MeasurementID",
                table: "Measurement");

            migrationBuilder.AlterColumn<int>(
                name: "MeasurementID",
                table: "Measurement",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "IngredientID",
                table: "Measurement",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Measurement_IngredientID",
                table: "Measurement",
                column: "IngredientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_Ingredient_IngredientID",
                table: "Measurement",
                column: "IngredientID",
                principalTable: "Ingredient",
                principalColumn: "IngredientID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
