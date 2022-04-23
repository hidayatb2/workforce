using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class bidcoladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Contractor");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedDate",
                table: "Bids",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDate",
                table: "Bids",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 22, 14, 50, 56, 579, DateTimeKind.Local).AddTicks(8940), "T1QGBokwyxTFNbONlSeRrWCflfJqWDjNDGlfhuKDIMo=", "yAeHq1L89f817C25vKOzWmjggBA=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExpectedDate",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "LastDate",
                table: "Bids");

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
                values: new object[] { new DateTime(2022, 4, 21, 16, 22, 54, 370, DateTimeKind.Local).AddTicks(3412), "NXPPNocCTekowNLRRQdLkyT6kjmLtdLteBQ58H/sFiY=", "hGIy9dac+Yd0ek1sZjSx59HtwdE=" });
        }
    }
}
