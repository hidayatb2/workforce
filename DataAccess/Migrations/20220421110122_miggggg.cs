using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class miggggg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "generalRequestDB",
                newName: "SenderRole");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "generalRequestDB",
                newName: "SenderUsername");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "generalRequestDB",
                newName: "SenderName");

            migrationBuilder.AddColumn<string>(
                name: "RecieverName",
                table: "generalRequestDB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "RecieverRole",
                table: "generalRequestDB",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "RecieverUsername",
                table: "generalRequestDB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 21, 16, 31, 21, 841, DateTimeKind.Local).AddTicks(2008), "finxsyGtmcBCn71Hh6cs/6giezK2c7gaDsmi66jfhv4=", "lzD7EGZ0MmSHpQcvdzG6A6Icvmg=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecieverName",
                table: "generalRequestDB");

            migrationBuilder.DropColumn(
                name: "RecieverRole",
                table: "generalRequestDB");

            migrationBuilder.DropColumn(
                name: "RecieverUsername",
                table: "generalRequestDB");

            migrationBuilder.RenameColumn(
                name: "SenderUsername",
                table: "generalRequestDB",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "SenderRole",
                table: "generalRequestDB",
                newName: "UserRole");

            migrationBuilder.RenameColumn(
                name: "SenderName",
                table: "generalRequestDB",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 20, 22, 28, 16, 529, DateTimeKind.Local).AddTicks(3990), "5fiN3dImycNSENOLYylyxA0WhjvurmSPD7+M5iobLDM=", "kXY+t7yWWpkOOMQDJbG5qf9zZek=" });
        }
    }
}
