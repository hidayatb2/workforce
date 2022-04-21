using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mignullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 21, 15, 7, 58, 180, DateTimeKind.Local).AddTicks(4464), "lBw6p8u6PFToVpr7qB+sw9xpsV8cbZMb0oZmj4UbaQg=", "nzH2nD77J0vFgq97APk/XEL0cj8=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 21, 14, 16, 15, 692, DateTimeKind.Local).AddTicks(9307), "pytQ4/N0Fv9JsMMqFDoDXFePmvjb66LDvFHA1hOTQ8E=", "7ZNHvpMsjqTQBkPOIgRNHA9LBRk=" });
        }
    }
}
