using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ES.BusinessLayer.Migrations
{
    public partial class ImageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProductImage1",
                table: "ElectroProducts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProductImage2",
                table: "ElectroProducts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProductImage3",
                table: "ElectroProducts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProductImage1",
                table: "ApplianceProducts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProductImage2",
                table: "ApplianceProducts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProductImage3",
                table: "ApplianceProducts",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage1",
                table: "ElectroProducts");

            migrationBuilder.DropColumn(
                name: "ProductImage2",
                table: "ElectroProducts");

            migrationBuilder.DropColumn(
                name: "ProductImage3",
                table: "ElectroProducts");

            migrationBuilder.DropColumn(
                name: "ProductImage1",
                table: "ApplianceProducts");

            migrationBuilder.DropColumn(
                name: "ProductImage2",
                table: "ApplianceProducts");

            migrationBuilder.DropColumn(
                name: "ProductImage3",
                table: "ApplianceProducts");
        }
    }
}
