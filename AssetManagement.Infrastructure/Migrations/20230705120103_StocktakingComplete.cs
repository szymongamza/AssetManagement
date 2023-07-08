using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StocktakingComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetStocktakingComplete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssetId = table.Column<int>(type: "INTEGER", nullable: false),
                    StocktakingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStocktakingComplete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetStocktakingComplete_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetStocktakingComplete_Stocktakings_StocktakingId",
                        column: x => x.StocktakingId,
                        principalTable: "Stocktakings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetStocktakingComplete_AssetId",
                table: "AssetStocktakingComplete",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetStocktakingComplete_StocktakingId",
                table: "AssetStocktakingComplete",
                column: "StocktakingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetStocktakingComplete");
        }
    }
}
