using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedBuildingsToFaculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Buildings_BuildingId",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_BuildingId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Buildings");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Buildings",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BuildingFaculty",
                columns: table => new
                {
                    BuildingsId = table.Column<int>(type: "INTEGER", nullable: false),
                    FacultiesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingFaculty", x => new { x.BuildingsId, x.FacultiesId });
                    table.ForeignKey(
                        name: "FK_BuildingFaculty_Buildings_BuildingsId",
                        column: x => x.BuildingsId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingFaculty_Faculties_FacultiesId",
                        column: x => x.FacultiesId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingFaculty_FacultiesId",
                table: "BuildingFaculty",
                column: "FacultiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingFaculty");

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "Faculties",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Buildings",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Buildings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Buildings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_BuildingId",
                table: "Faculties",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Buildings_BuildingId",
                table: "Faculties",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id");
        }
    }
}
