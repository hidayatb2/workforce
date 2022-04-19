using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CurrentUserId",
                table: "generalRequestDB",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 19, 16, 2, 35, 110, DateTimeKind.Local).AddTicks(7720), "qel4T82eqTMN0PNA6KMeWvv6zOjPZBAVJMShSJjEt+k=", "QhcAq20p9eHWVJ/GKjmXImoPkwE=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentUserId",
                table: "generalRequestDB");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 19, 14, 46, 58, 81, DateTimeKind.Local).AddTicks(9702), "EVc7zZq4k9c9B3sNE5xUCFAYt/rDCARX8dQ/PyFV2rg=", "HK48+//UEyHMDnpZZvT/kaFLxQ4=" });
        }
    }
}
