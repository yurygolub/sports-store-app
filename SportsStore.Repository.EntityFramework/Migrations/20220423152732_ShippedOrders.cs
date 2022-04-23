using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsStore.Repository.EntityFramework.Migrations
{
    public partial class ShippedOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLines_Products_ProductId",
                table: "CartLines");

            migrationBuilder.DropIndex(
                name: "IX_CartLines_ProductId",
                table: "CartLines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CartLines_ProductId",
                table: "CartLines",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartLines_Products_ProductId",
                table: "CartLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
