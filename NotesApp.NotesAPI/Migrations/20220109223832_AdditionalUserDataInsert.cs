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
                keyValue: "62bb7582-0b5c-44cf-8d53-d1a0d1c48e3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f80e96d1-09be-4843-862a-be406063626f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "cee73eff-4350-4d83-a8a6-bf596bec8f14", "eaf34b4e-4990-4ece-93c8-d38786620a1b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaf34b4e-4990-4ece-93c8-d38786620a1b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cee73eff-4350-4d83-a8a6-bf596bec8f14");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ba6d02d9-74df-4d01-a474-165c08d948ba", "0cffd19c-11c8-4826-a074-deab157dd60b", "Admin", "ADMIN" },
                    { "c36ecb07-a824-4dc0-9e35-245033191581", "9069e0f5-c65e-40a3-b9f1-c28e2381787b", "Moderator", "MODERATOR" },
                    { "d73e4a57-5caf-4d40-a3f0-f607946f845d", "1f66c14d-d9bf-4cf7-bbf6-8538cc203e92", "Basic", "BASIC" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ColorMode", "ConcurrencyStamp", "Email", "EmailConfirmed", "first_name", "image", "last_name", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fecf766e-6b83-412f-859b-e8cd1eaf92aa", 0, 0, "b8758905-36d2-4db8-a7f4-3e59e5ac0c6c", "admin@gmail.com", true, "Karan", null, "singh", false, null, "Admin@gmail.com", "Admin@gmail.com", "AQAAAAEAACcQAAAAEMs2Wu3ia51XAJ2mY76b2w8/9pRIXeY7hGoFGkqwXFCh9NN0IByopHAJ+hXQ8q/JPA==", null, true, "fb81100f-5e22-4abf-a5d5-9ca1189ace3a", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "fecf766e-6b83-412f-859b-e8cd1eaf92aa", "ba6d02d9-74df-4d01-a474-165c08d948ba" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c36ecb07-a824-4dc0-9e35-245033191581");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d73e4a57-5caf-4d40-a3f0-f607946f845d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "fecf766e-6b83-412f-859b-e8cd1eaf92aa", "ba6d02d9-74df-4d01-a474-165c08d948ba" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba6d02d9-74df-4d01-a474-165c08d948ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fecf766e-6b83-412f-859b-e8cd1eaf92aa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "eaf34b4e-4990-4ece-93c8-d38786620a1b", "d6996d6c-b4f3-4215-8467-4e332bf0a4b7", "Admin", "ADMIN" },
                    { "62bb7582-0b5c-44cf-8d53-d1a0d1c48e3d", "e4fe5e14-aea0-4ccf-adbe-03e197c0d759", "Moderator", "MODERATOR" },
                    { "f80e96d1-09be-4843-862a-be406063626f", "7c41b8e1-2874-4074-8639-4db7f64eafc0", "Basic", "BASIC" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ColorMode", "ConcurrencyStamp", "Email", "EmailConfirmed", "first_name", "image", "last_name", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cee73eff-4350-4d83-a8a6-bf596bec8f14", 0, 0, "79e39d09-459f-4f39-bccc-e16cb4ed109d", "admin@gmail.com", true, "Karan", null, "singh", false, null, "Admin@gmail.com", "Admin", "AQAAAAEAACcQAAAAEGEUtFHvnF9NdwELqKK6sTpHZFoJwgIRBP8OKt+0id0ijFSrOzlRKXO6CQ06nEQqmg==", null, true, "686655ca-7501-4df9-9f5b-10d6d9cc8974", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "cee73eff-4350-4d83-a8a6-bf596bec8f14", "eaf34b4e-4990-4ece-93c8-d38786620a1b" });
        }
    }
}
