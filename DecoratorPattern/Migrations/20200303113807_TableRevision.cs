using Microsoft.EntityFrameworkCore.Migrations;

namespace DecoratorPattern.Migrations
{
    public partial class TableRevision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produts_Merchants_Merchant_id",
                table: "Produts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produts",
                table: "Produts");

            migrationBuilder.RenameTable(
                name: "Produts",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Produts_Merchant_id",
                table: "Products",
                newName: "IX_Products_Merchant_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Merchants_Merchant_id",
                table: "Products",
                column: "Merchant_id",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Merchants_Merchant_id",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Produts");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Merchant_id",
                table: "Produts",
                newName: "IX_Produts_Merchant_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produts",
                table: "Produts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produts_Merchants_Merchant_id",
                table: "Produts",
                column: "Merchant_id",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
