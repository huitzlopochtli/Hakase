using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class addedThumbnailToMaterials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailUrl1",
                table: "Materials",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailUrl2",
                table: "Materials",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailUrl3",
                table: "Materials",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailUrl4",
                table: "Materials",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageThumbnailUrl1",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ImageThumbnailUrl2",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ImageThumbnailUrl3",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ImageThumbnailUrl4",
                table: "Materials");
        }
    }
}
