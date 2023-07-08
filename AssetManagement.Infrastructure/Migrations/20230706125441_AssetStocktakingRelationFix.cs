using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AssetStocktakingRelationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetStocktaking_Assets_AssetsId",
                table: "AssetStocktaking");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetStocktaking_Stocktakings_StocktakingsId",
                table: "AssetStocktaking");

            migrationBuilder.DropTable(
                name: "AssetStocktakings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetStocktaking",
                table: "AssetStocktaking");

            migrationBuilder.RenameColumn(
                name: "StocktakingsId",
                table: "AssetStocktaking",
                newName: "StocktakingId");

            migrationBuilder.RenameColumn(
                name: "AssetsId",
                table: "AssetStocktaking",
                newName: "IsScanned");

            migrationBuilder.RenameIndex(
                name: "IX_AssetStocktaking_StocktakingsId",
                table: "AssetStocktaking",
                newName: "IX_AssetStocktaking_StocktakingId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AssetStocktaking",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "AssetId",
                table: "AssetStocktaking",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScannedTime",
                table: "AssetStocktaking",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetStocktaking",
                table: "AssetStocktaking",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AssetStocktaking_AssetId",
                table: "AssetStocktaking",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetStocktaking_Assets_AssetId",
                table: "AssetStocktaking",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetStocktaking_Stocktakings_StocktakingId",
                table: "AssetStocktaking",
                column: "StocktakingId",
                principalTable: "Stocktakings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetStocktaking_Assets_AssetId",
                table: "AssetStocktaking");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetStocktaking_Stocktakings_StocktakingId",
                table: "AssetStocktaking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetStocktaking",
                table: "AssetStocktaking");

            migrationBuilder.DropIndex(
                name: "IX_AssetStocktaking_AssetId",
                table: "AssetStocktaking");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AssetStocktaking");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "AssetStocktaking");

            migrationBuilder.DropColumn(
                name: "ScannedTime",
                table: "AssetStocktaking");

            migrationBuilder.RenameColumn(
                name: "StocktakingId",
                table: "AssetStocktaking",
                newName: "StocktakingsId");

            migrationBuilder.RenameColumn(
                name: "IsScanned",
                table: "AssetStocktaking",
                newName: "AssetsId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetStocktaking_StocktakingId",
                table: "AssetStocktaking",
                newName: "IX_AssetStocktaking_StocktakingsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetStocktaking",
                table: "AssetStocktaking",
                columns: new[] { "AssetsId", "StocktakingsId" });

            migrationBuilder.CreateTable(
                name: "AssetStocktakings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssetId = table.Column<int>(type: "INTEGER", nullable: false),
                    StocktakingId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsScanned = table.Column<bool>(type: "INTEGER", nullable: false),
                    ScannedTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStocktakings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetStocktakings_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetStocktakings_Stocktakings_StocktakingId",
                        column: x => x.StocktakingId,
                        principalTable: "Stocktakings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetStocktakings_AssetId",
                table: "AssetStocktakings",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetStocktakings_StocktakingId",
                table: "AssetStocktakings",
                column: "StocktakingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetStocktaking_Assets_AssetsId",
                table: "AssetStocktaking",
                column: "AssetsId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetStocktaking_Stocktakings_StocktakingsId",
                table: "AssetStocktaking",
                column: "StocktakingsId",
                principalTable: "Stocktakings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
