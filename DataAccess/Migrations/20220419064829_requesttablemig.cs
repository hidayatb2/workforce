using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class requesttablemig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "generalRequestDB",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generalRequestDB", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 19, 12, 18, 29, 187, DateTimeKind.Local).AddTicks(4425), "TJ2Sj5455gAy5kxB3SJqgq4p2OgZlNI3dtiGLZ72RDo=", "rxeAaAosOEvOIx0eB9eUkqLxFyM=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "generalRequestDB");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 18, 18, 28, 44, 447, DateTimeKind.Local).AddTicks(588), "oZeTZIsMnxLuwYQ7nlOoEW66sGQPhc0Cavbg6MPXasw=", "tnOiTg90Qv+534V4Yq5B7JaYoUQ=" });
        }
    }
}
