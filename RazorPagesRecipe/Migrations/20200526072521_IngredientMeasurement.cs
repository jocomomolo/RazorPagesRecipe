using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RazorPagesRecipe.Migrations
{
    public partial class IngredientMeasurement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurement", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IngredientMeasurement",
                columns: table => new
                {
                    IngredientID = table.Column<int>(nullable: false),
                    MeasurementID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientMeasurement", x => new { x.IngredientID, x.MeasurementID });
                    table.ForeignKey(
                        name: "FK_IngredientMeasurement_Ingredient_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientMeasurement_Measurement_MeasurementID",
                        column: x => x.MeasurementID,
                        principalTable: "Measurement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientMeasurement_MeasurementID",
                table: "IngredientMeasurement",
                column: "MeasurementID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientMeasurement");

            migrationBuilder.DropTable(
                name: "Measurement");
        }
    }
}
