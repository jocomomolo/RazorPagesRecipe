using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesRecipe.Migrations
{
    public partial class RemoveIngredientMeasurementManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientMeasurement");

            migrationBuilder.AddColumn<int>(
                name: "IngredientID",
                table: "Measurement",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "IngredientMeasurement",
                columns: table => new
                {
                    IngredientID = table.Column<int>(type: "integer", nullable: false),
                    MeasurementID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientMeasurement", x => new { x.IngredientID, x.MeasurementID });
                    table.ForeignKey(
                        name: "FK_IngredientMeasurement_Ingredient_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredient",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientMeasurement_Measurement_MeasurementID",
                        column: x => x.MeasurementID,
                        principalTable: "Measurement",
                        principalColumn: "MeasurementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientMeasurement_MeasurementID",
                table: "IngredientMeasurement",
                column: "MeasurementID");
        }
    }
}
