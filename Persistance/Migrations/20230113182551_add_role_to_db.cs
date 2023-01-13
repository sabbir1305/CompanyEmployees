using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addroletodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ace9f938-d99c-41e5-aba9-8c484651b5f2", "402e4a21-8b6d-4d18-93b5-83638d7c77fd", "Manager", "MANAGER" },
                    { "f8b8c034-19b9-42d2-9fe1-189aad5fdf2d", "65085bcf-51a4-4428-ad7a-db02a9c91184", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ace9f938-d99c-41e5-aba9-8c484651b5f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8b8c034-19b9-42d2-9fe1-189aad5fdf2d");
        }
    }
}
