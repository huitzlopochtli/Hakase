using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class ImageReform1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UploadedImages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ReformedImages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UploadedImages_UserId",
                table: "UploadedImages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedImages_AspNetUsers_UserId",
                table: "UploadedImages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadedImages_AspNetUsers_UserId",
                table: "UploadedImages");

            migrationBuilder.DropIndex(
                name: "IX_UploadedImages_UserId",
                table: "UploadedImages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UploadedImages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ReformedImages");
        }
    }
}
