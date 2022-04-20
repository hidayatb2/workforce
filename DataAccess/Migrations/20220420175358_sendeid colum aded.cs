using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class sendeidcolumaded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentUserId",
                table: "generalRequestDB",
                newName: "SenderId");

            migrationBuilder.AddColumn<Guid>(
                name: "RecieverId",
                table: "generalRequestDB",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 20, 23, 23, 56, 457, DateTimeKind.Local).AddTicks(7410), "U92bDCCgpP1zefKeYodFfEwtFPMayY0iudvzYrovHd8=", "9ew1gKcDl0kn9FlMX94TaMgF+2E=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecieverId",
                table: "generalRequestDB");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "generalRequestDB",
                newName: "CurrentUserId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 20, 17, 4, 24, 531, DateTimeKind.Local).AddTicks(5676), "eXiB5Vht7XivPkvZtoAfxPeWiBDlUGE5ho+i+9Zaqp8=", "3Akpg9UvLt8lUJkVB1rwC5/kH+c=" });
        }
    }
}
