using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AssetStocktaking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingFaculty",
                table: "BuildingFaculty");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BuildingFaculty",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "Assets",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingFaculty",
                table: "BuildingFaculty",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Stocktakings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClosedUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsClosed = table.Column<bool>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocktakings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocktakings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetStocktaking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssetId = table.Column<int>(type: "INTEGER", nullable: false),
                    StocktakingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStocktaking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetStocktaking_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetStocktaking_Stocktakings_StocktakingId",
                        column: x => x.StocktakingId,
                        principalTable: "Stocktakings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingFaculty_BuildingId",
                table: "BuildingFaculty",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetStocktaking_AssetId",
                table: "AssetStocktaking",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetStocktaking_StocktakingId",
                table: "AssetStocktaking",
                column: "StocktakingId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocktakings_RoomId",
                table: "Stocktakings",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetStocktaking");

            migrationBuilder.DropTable(
                name: "Stocktakings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingFaculty",
                table: "BuildingFaculty");

            migrationBuilder.DropIndex(
                name: "IX_BuildingFaculty_BuildingId",
                table: "BuildingFaculty");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BuildingFaculty");

            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "Assets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingFaculty",
                table: "BuildingFaculty",
                columns: new[] { "BuildingId", "FacultyId" });
        }
    }
}
