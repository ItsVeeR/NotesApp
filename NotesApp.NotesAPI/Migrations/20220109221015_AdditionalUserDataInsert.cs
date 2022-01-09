using Microsoft.EntityFrameworkCore.Migrations;

namespace NotesApp.NotesAPI.Migrations
{
    public partial class AdditionalUserDataInsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "160ee0a2-f561-423c-afb5-ec8cc1b5defa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d33ed16-aebb-4da5-b881-f4e491005d4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "946c0789-a7da-4774-9992-78f6f3a1f8c2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00ddaeae-7780-44d5-bd26-f84457706992", "c006cbc0-0125-413f-9f18-d76b73d6eb8d", "Admin", "ADMIN" },
                    { "ffa5a9e5-640d-4444-8f71-0efffcfa5a1b", "bd0185d1-f88f-429c-8647-2b1a63fe7b86", "Moderator", "MODERATOR" },
                    { "ca92176a-4dcb-4b2e-a438-653eb3b61c3e", "1e1e1ff3-963d-4a6c-9643-3a11f10d7343", "Basic", "BASIC" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "0675ab25-ccfe-4c54-82b8-3bc2978e5210", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ColorMode", "ConcurrencyStamp", "Email", "EmailConfirmed", "first_name", "image", "last_name", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "39bcc889-1952-4150-9887-3c09b8c55773", 0, 0, "5fc7a93b-bc76-44cc-aa03-ba73157fc61a", "admin@gmail.com", true, "Karan", null, "singh", false, null, "Admin@gmail.com", "Admin", "AQAAAAEAACcQAAAAEATfF32jwlOuMHPGXT3jWlHc9jk0SNKIbrA7DHeDp+jnN2X23FR2IrqgZSVpHZX2fg==", null, true, "6f749eb3-ab2a-4e67-9549-d4696902a943", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "39bcc889-1952-4150-9887-3c09b8c55773", "00ddaeae-7780-44d5-bd26-f84457706992" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca92176a-4dcb-4b2e-a438-653eb3b61c3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffa5a9e5-640d-4444-8f71-0efffcfa5a1b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "39bcc889-1952-4150-9887-3c09b8c55773", "00ddaeae-7780-44d5-bd26-f84457706992" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00ddaeae-7780-44d5-bd26-f84457706992");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39bcc889-1952-4150-9887-3c09b8c55773");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "160ee0a2-f561-423c-afb5-ec8cc1b5defa", "df188a25-b51b-4de4-87a8-aa64f4291035", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "946c0789-a7da-4774-9992-78f6f3a1f8c2", "06767e26-4aa6-464c-9861-a116f63b0351", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d33ed16-aebb-4da5-b881-f4e491005d4a", "2617a4ea-acd2-4a65-b2c3-5f1473b484ab", "Basic", "BASIC" });
        }
    }
}
