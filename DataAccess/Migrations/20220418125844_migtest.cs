using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 18, 18, 28, 44, 447, DateTimeKind.Local).AddTicks(588), "oZeTZIsMnxLuwYQ7nlOoEW66sGQPhc0Cavbg6MPXasw=", "tnOiTg90Qv+534V4Yq5B7JaYoUQ=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 17, 15, 8, 58, 38, DateTimeKind.Local).AddTicks(468), "XfUyBvJHy58kwNrClBtSA90e6bV47PWYWrXnLPxgN3c=", "+MlQdaAWfOL2tqmZKMT7hfT34oI=" });
        }
    }
}
