using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 22, 13, 57, 41, 879, DateTimeKind.Local).AddTicks(668), "wT2WHgsQJp7Fbi2tvT0f3JBi5hGkmoCWM6OzBvbENsk=", "gi9eI0meUtmMv5aAx96lHSTAZpc=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 22, 13, 48, 42, 974, DateTimeKind.Local).AddTicks(7486), "qDQ3cg4AfiTAOu3bEvAEvERtfLDublRUtpYx+wZZwsY=", "V5IA1GS0gxSiahOnzPB90oBNxVQ=" });
        }
    }
}
