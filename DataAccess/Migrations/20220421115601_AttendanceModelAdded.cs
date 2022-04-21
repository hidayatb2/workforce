using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AttendanceModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 21, 17, 26, 1, 350, DateTimeKind.Local).AddTicks(8338), "mmFi8n632WKsBFO0pMgSk207swTv4ucqvSnUmKuf3oQ=", "UcUVcuOC/rI/NEd9GYIOQ+kIbLE=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 20, 12, 11, 43, 499, DateTimeKind.Local).AddTicks(7168), "lQ4KXGk1DRfU1zfNOBUQwVX4eHyDvT0OVI/M8ALrS0g=", "hsluu5ZvANYFMvxJ60z8P4jn1HM=" });
        }
    }
}
