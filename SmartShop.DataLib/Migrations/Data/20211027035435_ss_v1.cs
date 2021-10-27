using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartShop.DataLib.Migrations.Data
{
    public partial class ss_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IamgeName",
                table: "ProductImages");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "ProductImages",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "ProductImages");

            migrationBuilder.AddColumn<string>(
                name: "IamgeName",
                table: "ProductImages",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
