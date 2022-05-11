using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class initialMig007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 10, 7, 49, 38, 978, DateTimeKind.Local).AddTicks(1506), "ZH2WB2tkfeyvJBgsFVMX3H5UGJssdaRIgkifNlwxSVI=", "1W5AcMHrd276MK47iRR/uXrWxdE=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Testimonials");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 10, 1, 10, 16, 381, DateTimeKind.Local).AddTicks(7921), "TBdozEQhNWCcQ5jR8KTem+P8QyXrBhufZWpLZ8moG1A=", "aY5a3m4xZlr4SqZAiZ5inhJ1evo=" });
        }
    }
}
