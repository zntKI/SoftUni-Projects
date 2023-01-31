using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class InitialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e52d31a-f28e-4626-9843-ddd2a4b6e78f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f3f6bf0e-99d9-44ae-b9fc-2118d65f386b", 0, "150c2243-6fb7-48f4-aca0-c31c40d2c9e5", "guest@mail.com", false, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEAY/aBtOE5T9KxBOBdZtVc9hqqw5JcjxgB/BIWfmIVfbq2g3A/ng3OsNLwCzPMpctw==", null, false, "a697e48a-d2c0-4514-b68a-f773a2384c68", false, "guest" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 9, 16, 11, 2, 43, 750, DateTimeKind.Local).AddTicks(2342), "f3f6bf0e-99d9-44ae-b9fc-2118d65f386b" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 5, 16, 11, 2, 43, 750, DateTimeKind.Local).AddTicks(2446), "f3f6bf0e-99d9-44ae-b9fc-2118d65f386b" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 10, 6, 11, 2, 43, 750, DateTimeKind.Local).AddTicks(2451), "f3f6bf0e-99d9-44ae-b9fc-2118d65f386b" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2021, 10, 16, 11, 2, 43, 750, DateTimeKind.Local).AddTicks(2455), "f3f6bf0e-99d9-44ae-b9fc-2118d65f386b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3f6bf0e-99d9-44ae-b9fc-2118d65f386b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9e52d31a-f28e-4626-9843-ddd2a4b6e78f", 0, "04f7d69c-381b-4312-ba5a-f5ea0dba4227", "guest@mail.com", false, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEF9EqQ11DSNhbJvI9RZs0KRkfY2OLHfxXlXG08QmDnHoa7llA+hh4VqMu8GPHUa6bA==", null, false, "fad767d0-8534-4abd-8824-5c2dff70dfc5", false, "guest" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 9, 16, 10, 39, 39, 612, DateTimeKind.Local).AddTicks(198), "9e52d31a-f28e-4626-9843-ddd2a4b6e78f" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 5, 16, 10, 39, 39, 612, DateTimeKind.Local).AddTicks(248), "9e52d31a-f28e-4626-9843-ddd2a4b6e78f" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 10, 6, 10, 39, 39, 612, DateTimeKind.Local).AddTicks(254), "9e52d31a-f28e-4626-9843-ddd2a4b6e78f" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2021, 10, 16, 10, 39, 39, 612, DateTimeKind.Local).AddTicks(258), "9e52d31a-f28e-4626-9843-ddd2a4b6e78f" });
        }
    }
}
