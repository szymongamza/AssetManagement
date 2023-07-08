using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rooms");

            migrationBuilder.AddColumn<bool>(
                name: "ChangedRoom",
                table: "AssetStocktaking",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PreviousRoomId",
                table: "AssetStocktaking",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockNumber",
                table: "Assets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Assets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UserId",
                table: "Assets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Users_UserId",
                table: "Assets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Users_UserId",
                table: "Assets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Assets_UserId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "ChangedRoom",
                table: "AssetStocktaking");

            migrationBuilder.DropColumn(
                name: "PreviousRoomId",
                table: "AssetStocktaking");

            migrationBuilder.DropColumn(
                name: "StockNumber",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Assets");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rooms",
                type: "TEXT",
                nullable: true);
        }
    }
}
