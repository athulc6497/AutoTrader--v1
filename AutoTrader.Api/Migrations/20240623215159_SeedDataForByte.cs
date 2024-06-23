using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoTrader.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForByte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43a8b4fe-2a66-4c20-8986-7d2880f6c47b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f4c6a06-8aee-4f7f-961f-ed28a3566d45");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "eeafb0ce-1595-480b-9398-490b20be3315", "1", "Admin", "Admin" },
                    { "fbf58d97-fa97-4e8a-8abb-0c600237768c", "2", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                column: "Photo",
                value: new byte[] { 48, 130, 8, 0 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                column: "Photo",
                value: new byte[] { 48, 130, 8, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eeafb0ce-1595-480b-9398-490b20be3315");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbf58d97-fa97-4e8a-8abb-0c600237768c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43a8b4fe-2a66-4c20-8986-7d2880f6c47b", "2", "User", "User" },
                    { "4f4c6a06-8aee-4f7f-961f-ed28a3566d45", "1", "Admin", "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                column: "Photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                column: "Photo",
                value: null);
        }
    }
}
