using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class feedbackupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "status",
                table: "feedbacks",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 14, 19, 51, 31, 894, DateTimeKind.Local).AddTicks(8770), "3iFBuxjXEGwZqnE3oZfIXD/CqdtJ5gshnJm7rbsqH7g=", "oNoyei33ysn3hPBeVPW02uTugBM=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "feedbacks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 14, 18, 39, 3, 999, DateTimeKind.Local).AddTicks(3342), "Z9FM4iYWOxiEFhrdwGEGQ4eUMs/tvPrN7AIbEgXOaWE=", "bSWJXq4KcxZCZbIJDxvdSfwP1lE=" });
        }
    }
}
