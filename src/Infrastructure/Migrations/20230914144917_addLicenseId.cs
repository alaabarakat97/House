using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace House.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addLicenseId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "License",
                table: "Regions",
                newName: "LicenseId");

            migrationBuilder.RenameColumn(
                name: "License",
                table: "Neighborhoods",
                newName: "LicenseId");

            migrationBuilder.RenameColumn(
                name: "License",
                table: "Cities",
                newName: "LicenseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LicenseId",
                table: "Regions",
                newName: "License");

            migrationBuilder.RenameColumn(
                name: "LicenseId",
                table: "Neighborhoods",
                newName: "License");

            migrationBuilder.RenameColumn(
                name: "LicenseId",
                table: "Cities",
                newName: "License");
        }
    }
}
