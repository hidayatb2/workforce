using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class reqtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "generalRequestDB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "UserStatus",
                table: "generalRequestDB",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 20, 15, 28, 29, 567, DateTimeKind.Local).AddTicks(2378), "Dtr6bObat6iexKKx5PkMVCmY0jSLYa5T9H+ZLydAQv0=", "n5WZhK+odr966rkgUAsxh5INMHk=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "generalRequestDB");

            migrationBuilder.DropColumn(
                name: "UserStatus",
                table: "generalRequestDB");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 20, 12, 11, 43, 499, DateTimeKind.Local).AddTicks(7168), "lQ4KXGk1DRfU1zfNOBUQwVX4eHyDvT0OVI/M8ALrS0g=", "hsluu5ZvANYFMvxJ60z8P4jn1HM=" });
        }
    }
}
