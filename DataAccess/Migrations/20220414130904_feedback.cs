using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class feedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbacks", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 14, 18, 39, 3, 999, DateTimeKind.Local).AddTicks(3342), "Z9FM4iYWOxiEFhrdwGEGQ4eUMs/tvPrN7AIbEgXOaWE=", "bSWJXq4KcxZCZbIJDxvdSfwP1lE=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 14, 18, 29, 38, 245, DateTimeKind.Local).AddTicks(5877), "0VLhADTIMc8P4aBNFL6DNt7dP4+lt/Wm7h6a+hjM9IY=", "pD08/OuPCbM4Gew7M/9dUndPO4k=" });
        }
    }
}
