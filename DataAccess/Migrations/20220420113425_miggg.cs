using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class miggg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserStatus",
                table: "generalRequestDB",
                newName: "Status");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 20, 17, 4, 24, 531, DateTimeKind.Local).AddTicks(5676), "eXiB5Vht7XivPkvZtoAfxPeWiBDlUGE5ho+i+9Zaqp8=", "3Akpg9UvLt8lUJkVB1rwC5/kH+c=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "generalRequestDB",
                newName: "UserStatus");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 20, 16, 19, 17, 423, DateTimeKind.Local).AddTicks(7516), "zujwhe81exDNDT7JCW/5R4AovghYGmWjv984ueoutvk=", "OPtsICuv9PMZEGyB4sggSSyiz74=" });
        }
    }
}
