using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class updaterequestmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 19, 12, 18, 29, 187, DateTimeKind.Local).AddTicks(4425), "TJ2Sj5455gAy5kxB3SJqgq4p2OgZlNI3dtiGLZ72RDo=", "rxeAaAosOEvOIx0eB9eUkqLxFyM=" });
        }
    }
}
