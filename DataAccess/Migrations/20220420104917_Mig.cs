using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Manager",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Contractor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 20, 16, 19, 17, 423, DateTimeKind.Local).AddTicks(7516), "zujwhe81exDNDT7JCW/5R4AovghYGmWjv984ueoutvk=", "OPtsICuv9PMZEGyB4sggSSyiz74=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Contractor");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 20, 15, 28, 29, 567, DateTimeKind.Local).AddTicks(2378), "Dtr6bObat6iexKKx5PkMVCmY0jSLYa5T9H+ZLydAQv0=", "n5WZhK+odr966rkgUAsxh5INMHk=" });
        }
    }
}
