using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FacultyBuilding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingFaculty_Buildings_BuildingsId",
                table: "BuildingFaculty");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingFaculty_Faculties_FacultiesId",
                table: "BuildingFaculty");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.RenameColumn(
                name: "FacultiesId",
                table: "BuildingFaculty",
                newName: "FacultyId");

            migrationBuilder.RenameColumn(
                name: "BuildingsId",
                table: "BuildingFaculty",
                newName: "BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingFaculty_FacultiesId",
                table: "BuildingFaculty",
                newName: "IX_BuildingFaculty_FacultyId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Manufacturers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Faculties",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Buildings",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Assets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingFaculty_Buildings_BuildingId",
                table: "BuildingFaculty",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingFaculty_Faculties_FacultyId",
                table: "BuildingFaculty",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingFaculty_Buildings_BuildingId",
                table: "BuildingFaculty");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingFaculty_Faculties_FacultyId",
                table: "BuildingFaculty");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "BuildingFaculty",
                newName: "FacultiesId");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                table: "BuildingFaculty",
                newName: "BuildingsId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingFaculty_FacultyId",
                table: "BuildingFaculty",
                newName: "IX_BuildingFaculty_FacultiesId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Manufacturers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Faculties",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Buildings",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Assets",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssetId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    LastModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_AssetId",
                table: "Maintenances",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingFaculty_Buildings_BuildingsId",
                table: "BuildingFaculty",
                column: "BuildingsId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingFaculty_Faculties_FacultiesId",
                table: "BuildingFaculty",
                column: "FacultiesId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
