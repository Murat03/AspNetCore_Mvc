using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class IdentityRoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "09383a61-5a31-4d85-a3e8-190a0d9cfa4c", "a6cf8f2d-db20-4e22-8422-bf8b1ebca7ce", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0dad2913-011c-414d-91d0-20fdc2d17217", "008e0fa0-5459-4c34-9e28-65d7e423794f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51a79ed8-10ed-4a8f-ae72-489d0c9c4feb", "084fa08b-dfb6-4ee6-ae6e-26a56d600316", "Editor", "EDITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09383a61-5a31-4d85-a3e8-190a0d9cfa4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dad2913-011c-414d-91d0-20fdc2d17217");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51a79ed8-10ed-4a8f-ae72-489d0c9c4feb");
        }
    }
}
