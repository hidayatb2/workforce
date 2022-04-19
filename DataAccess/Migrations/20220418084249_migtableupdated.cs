using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migtableupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 18, 14, 12, 48, 757, DateTimeKind.Local).AddTicks(2016), "ADcDIIbMHYzntu+ibIvtN4MiMbgi1kUfZDTFotcS22I=", "AcRnUa2e+PlPNEy/MpV8c93cFyY=" });
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
