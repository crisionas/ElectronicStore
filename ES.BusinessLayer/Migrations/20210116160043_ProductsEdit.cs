using Microsoft.EntityFrameworkCore.Migrations;

namespace ES.BusinessLayer.Migrations
{
    public partial class ProductsEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplianceProducts_ElectroCategories_CategoryId",
                table: "ApplianceProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplianceProducts_ApplianceCategories_CategoryId",
                table: "ApplianceProducts",
                column: "CategoryId",
                principalTable: "ApplianceCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplianceProducts_ApplianceCategories_CategoryId",
                table: "ApplianceProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplianceProducts_ElectroCategories_CategoryId",
                table: "ApplianceProducts",
                column: "CategoryId",
                principalTable: "ElectroCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
