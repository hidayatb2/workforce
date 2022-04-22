using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class attendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 22, 13, 48, 42, 974, DateTimeKind.Local).AddTicks(7486), "qDQ3cg4AfiTAOu3bEvAEvERtfLDublRUtpYx+wZZwsY=", "V5IA1GS0gxSiahOnzPB90oBNxVQ=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 21, 16, 22, 54, 370, DateTimeKind.Local).AddTicks(3412), "NXPPNocCTekowNLRRQdLkyT6kjmLtdLteBQ58H/sFiY=", "hGIy9dac+Yd0ek1sZjSx59HtwdE=" });
        }
    }
}
