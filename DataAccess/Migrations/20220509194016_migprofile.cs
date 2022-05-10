using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migprofile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 10, 1, 10, 16, 381, DateTimeKind.Local).AddTicks(7921), "TBdozEQhNWCcQ5jR8KTem+P8QyXrBhufZWpLZ8moG1A=", "aY5a3m4xZlr4SqZAiZ5inhJ1evo=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 10, 1, 0, 31, 56, DateTimeKind.Local).AddTicks(4561), "ZpHxb77piB0WAr9liM1qEJLxIOKrJd4ENgSJHNgxVhI=", "u2d9rStG0STtoxheWpPYr79U5zk=" });
        }
    }
}
