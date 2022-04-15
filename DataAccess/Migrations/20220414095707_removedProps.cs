using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class removedProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Skills");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 14, 15, 27, 6, 993, DateTimeKind.Local).AddTicks(2413), "gK11+cy+94jKYv95X0NajFKIK2liYZJuxJmsblxCLmI=", "YsaNLUmv1Z6b6PZ+vkYgLVg/GEA=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Skills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Skills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 14, 13, 1, 26, 913, DateTimeKind.Local).AddTicks(9833), "SK7hGSJMFTUwdtAKHVTL+4tgfYjIw3+ZcRSIehtkg3o=", "yq0HC5gYvyK5RDyo3ojva3AHBMI=" });
        }
    }
}
