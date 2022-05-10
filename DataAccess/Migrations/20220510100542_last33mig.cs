using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class last33mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Participants_PartcipantId",
                table: "Participants");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 10, 15, 35, 41, 896, DateTimeKind.Local).AddTicks(3476), "zN7ucLe6ee32C5qL8kXi5rG09bjNYGEs6/yuLL+Q+AM=", "DVdt672pzP024ZWOx4Ld4ftYRjY=" });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PartcipantId",
                table: "Participants",
                column: "PartcipantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Participants_PartcipantId",
                table: "Participants");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 10, 15, 26, 55, 430, DateTimeKind.Local).AddTicks(7257), "Teq8e4GmOYAmNIrR0a/3/X6NjUSVHSbq4EaX3mSGZQ8=", "CcFgiqGLSyHIihvUo0PVa0cUBRM=" });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PartcipantId",
                table: "Participants",
                column: "PartcipantId",
                unique: true,
                filter: "[PartcipantId] IS NOT NULL");
        }
    }
}
