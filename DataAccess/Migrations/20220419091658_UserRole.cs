using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_generalRequestDB_Users_UserId",
                table: "generalRequestDB");

            migrationBuilder.DropIndex(
                name: "IX_generalRequestDB_UserId",
                table: "generalRequestDB");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "generalRequestDB");

            migrationBuilder.AddColumn<byte>(
                name: "UserRole",
                table: "generalRequestDB",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 19, 14, 46, 58, 81, DateTimeKind.Local).AddTicks(9702), "EVc7zZq4k9c9B3sNE5xUCFAYt/rDCARX8dQ/PyFV2rg=", "HK48+//UEyHMDnpZZvT/kaFLxQ4=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "generalRequestDB");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "generalRequestDB",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 19, 13, 31, 49, 844, DateTimeKind.Local).AddTicks(1147), "jAIoi4l24DNd55popNoFev4d8tjaI72VrNNN6yD1gFY=", "JdA6O1wZ4sEdd9t2jsHjLf63/Gs=" });

            migrationBuilder.CreateIndex(
                name: "IX_generalRequestDB_UserId",
                table: "generalRequestDB",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_generalRequestDB_Users_UserId",
                table: "generalRequestDB",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
