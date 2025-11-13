using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserAndRoleTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "admin-role-stamp-static", "Admin", "ADMIN" },
                    { "2", "user-role-stamp-static", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "admin-user-id", 0, "admin-concurrency-stamp-static", "admin@dotnetacademy.com", true, false, null, "ADMIN@DOTNETACADEMY.COM", "ADMIN@DOTNETACADEMY.COM", "AQAAAAIAAYagAAAAEOgHHAPxCzc9Q3h54P4MfcJFcbnKjXN52yKG/aI31U6jfRYWLVWpGSVo0+nPBwpMVg==", null, false, "admin-security-stamp-static", false, "admin@dotnetacademy.com" },
                    { "regular-user-id", 0, "user-concurrency-stamp-static", "user@dotnetacademy.com", true, false, null, "USER@DOTNETACADEMY.COM", "USER@DOTNETACADEMY.COM", "AQAAAAIAAYagAAAAELnjWmX8OcR7M4S5V4j7lXvNbCvOuCGiB9Km4TtBd6Zy5AcVzjlc9ByWz9ynXxUL2w==", null, false, "user-security-stamp-static", false, "user@dotnetacademy.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "admin-user-id" },
                    { "2", "regular-user-id" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "admin-user-id" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "regular-user-id" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id");
        }
    }
}
