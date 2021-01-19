using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ES.BusinessLayer.Migrations.Shop
{
    public partial class Shop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplianceBrands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplianceBrands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "ApplianceCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplianceCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ElectroBrands",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectroBrands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "ElectroCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectroCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ApplianceProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Mark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ProductImage1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProductImage2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProductImage3 = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplianceProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplianceProducts_ApplianceBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "ApplianceBrands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplianceProducts_ApplianceCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ApplianceCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElectroProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    BrandID = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Mark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ProductImage1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProductImage2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProductImage3 = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectroProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ElectroProducts_ElectroBrands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "ElectroBrands",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElectroProducts_ElectroCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ElectroCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplianceProducts_BrandId",
                table: "ApplianceProducts",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplianceProducts_CategoryId",
                table: "ApplianceProducts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectroProducts_BrandID",
                table: "ElectroProducts",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_ElectroProducts_CategoryId",
                table: "ElectroProducts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplianceProducts");

            migrationBuilder.DropTable(
                name: "ElectroProducts");

            migrationBuilder.DropTable(
                name: "ApplianceBrands");

            migrationBuilder.DropTable(
                name: "ApplianceCategories");

            migrationBuilder.DropTable(
                name: "ElectroBrands");

            migrationBuilder.DropTable(
                name: "ElectroCategories");
        }
    }
}
