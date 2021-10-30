using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartShop.DataLib.Migrations.Data
{
    public partial class ss_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSpec_Products_ProductId",
                table: "ProductSpec");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSpec",
                table: "ProductSpec");

            migrationBuilder.RenameTable(
                name: "ProductSpec",
                newName: "ProductSpecs");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSpec_ProductId",
                table: "ProductSpecs",
                newName: "IX_ProductSpecs_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSpecs",
                table: "ProductSpecs",
                column: "ProductSpecId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSpecs_Products_ProductId",
                table: "ProductSpecs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSpecs_Products_ProductId",
                table: "ProductSpecs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSpecs",
                table: "ProductSpecs");

            migrationBuilder.RenameTable(
                name: "ProductSpecs",
                newName: "ProductSpec");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSpecs_ProductId",
                table: "ProductSpec",
                newName: "IX_ProductSpec_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSpec",
                table: "ProductSpec",
                column: "ProductSpecId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSpec_Products_ProductId",
                table: "ProductSpec",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
