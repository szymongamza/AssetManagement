using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomName",
                table: "Rooms",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BuildingName",
                table: "Buildings",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "AssetName",
                table: "Assets",
                newName: "QRCode");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Rooms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Faculties",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Departments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Buildings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Assets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rooms",
                newName: "RoomName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Buildings",
                newName: "BuildingName");

            migrationBuilder.RenameColumn(
                name: "QRCode",
                table: "Assets",
                newName: "AssetName");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Faculties",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
