using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace House.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addLicense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "License",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "License",
                table: "Neighborhoods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "License",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "License",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "License",
                table: "Neighborhoods");

            migrationBuilder.DropColumn(
                name: "License",
                table: "Cities");
        }
    }
}
