using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeletedStreetNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "Buildings");

            migrationBuilder.RenameColumn(
                name: "QRCode",
                table: "Assets",
                newName: "QrCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QrCode",
                table: "Assets",
                newName: "QRCode");

            migrationBuilder.AddColumn<int>(
                name: "StreetNumber",
                table: "Buildings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
