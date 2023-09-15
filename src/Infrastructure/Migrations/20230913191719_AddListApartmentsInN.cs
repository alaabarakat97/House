using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace House.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddListApartmentsInN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Neighborhoods_NeighborhoodId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Apartments");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_NeighborhoodId1",
                table: "Apartments",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Neighborhood",
                table: "Apartments",
                column: "NeighborhoodId",
                principalTable: "Neighborhoods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Neighborhood",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_NeighborhoodId1",
                table: "Apartments");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Apartments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Neighborhoods_NeighborhoodId",
                table: "Apartments",
                column: "NeighborhoodId",
                principalTable: "Neighborhoods",
                principalColumn: "Id");
        }
    }
}
