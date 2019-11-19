using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class CustomerMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b91635e1-9198-47ae-84a1-00037834bdaf", "cf8573ec-fc9a-4928-bd60-465627fe0622" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "cf45ccd3-3898-477f-9ba0-b449fbe9b597", "d2a856b7-0481-4ef7-b64e-d76935e57a53" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc83b5c4-fc27-4722-883f-d349326adb2b", "7c18914f-004d-4520-8081-e01e47ebdb29", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dad00ffb-457a-4cd4-aa04-d6b9e951c68a", "37f13de1-31e9-450b-bf79-7eefcf12fc5c", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "dad00ffb-457a-4cd4-aa04-d6b9e951c68a", "37f13de1-31e9-450b-bf79-7eefcf12fc5c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "fc83b5c4-fc27-4722-883f-d349326adb2b", "7c18914f-004d-4520-8081-e01e47ebdb29" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf45ccd3-3898-477f-9ba0-b449fbe9b597", "d2a856b7-0481-4ef7-b64e-d76935e57a53", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b91635e1-9198-47ae-84a1-00037834bdaf", "cf8573ec-fc9a-4928-bd60-465627fe0622", "Customer", "CUSTOMER" });
        }
    }
}
