using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class lastmig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 10, 15, 26, 55, 430, DateTimeKind.Local).AddTicks(7257), "Teq8e4GmOYAmNIrR0a/3/X6NjUSVHSbq4EaX3mSGZQ8=", "CcFgiqGLSyHIihvUo0PVa0cUBRM=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 9, 17, 15, 18, 238, DateTimeKind.Local).AddTicks(7685), "KJE09VzkHNcp4MhIrghxrCMvtUDyG0WaEoFC9HolpMw=", "FuQ1py61RfLQAyg8AC5OPUHd7bg=" });
        }
    }
}
