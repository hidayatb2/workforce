using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "UserRole",
                table: "Testimonials",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 17, 20, 28, 47, 112, DateTimeKind.Local).AddTicks(8653), "2JS6lKUR/YmM4s5AJHQgRWHoNzxDnsPRmeOPtboOcoo=", "rcJZ2H9M/ie6iOwoD87X5mUaxg8=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Testimonials");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 17, 19, 56, 7, 185, DateTimeKind.Local).AddTicks(4094), "uChBu+tj5ns6Z+3yEnrWUYs7JAQJPP4O7z8wYZ9w9bQ=", "Ov8gKuvhaeZJIza5ZUpIWIF0i3k=" });
        }
    }
}
