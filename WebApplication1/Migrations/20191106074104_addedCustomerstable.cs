using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class addedCustomerstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "8fe2089c-de36-4d32-9781-e61436b26b30", "bc0da250-7431-4e98-b291-590bbceecebb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "965f17f2-f5ce-4356-95b4-08375d30156e", "36b7665c-596f-464a-98a9-e095cb672927" });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    UserCreated = table.Column<string>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UserModified = table.Column<string>(nullable: true),
                    FNameHira = table.Column<string>(nullable: false),
                    LNameHira = table.Column<string>(nullable: false),
                    FNameKata = table.Column<string>(nullable: false),
                    LNameKata = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    PhoneMobile = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d7bbf60-b3c4-496d-9192-9bd2f2f435d7", "f32c63e1-3d25-46d6-b7d6-eb848c3f6176", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4f25b97-33e2-44ae-acde-b151afe926d8", "33b2ec22-2ac3-4a19-8ace-18b0793ac07b", "Customer", "CUSTOMER" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1d7bbf60-b3c4-496d-9192-9bd2f2f435d7", "f32c63e1-3d25-46d6-b7d6-eb848c3f6176" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e4f25b97-33e2-44ae-acde-b151afe926d8", "33b2ec22-2ac3-4a19-8ace-18b0793ac07b" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "965f17f2-f5ce-4356-95b4-08375d30156e", "36b7665c-596f-464a-98a9-e095cb672927", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8fe2089c-de36-4d32-9781-e61436b26b30", "bc0da250-7431-4e98-b291-590bbceecebb", "Customer", "CUSTOMER" });
        }
    }
}
