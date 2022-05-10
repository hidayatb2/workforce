using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Participants_PartcipantId",
                table: "Participants");

            migrationBuilder.AlterColumn<Guid>(
                name: "PartcipantId",
                table: "Participants",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "ImagePath", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 10, 1, 0, 31, 56, DateTimeKind.Local).AddTicks(4561), "xyz", "ZpHxb77piB0WAr9liM1qEJLxIOKrJd4ENgSJHNgxVhI=", "u2d9rStG0STtoxheWpPYr79U5zk=" });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PartcipantId",
                table: "Participants",
                column: "PartcipantId",
                unique: true,
                filter: "[PartcipantId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Participants_PartcipantId",
                table: "Participants");

            migrationBuilder.AlterColumn<Guid>(
                name: "PartcipantId",
                table: "Participants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "ImagePath", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 23, 17, 10, 23, 519, DateTimeKind.Local).AddTicks(6886), null, "hkusCKwzgZ5D7IJZ56Iw8npWmcP1hWCAV1KLsHU1U4c=", "QQpkbR+2O5Ko36bzvbIe7JL907k=" });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PartcipantId",
                table: "Participants",
                column: "PartcipantId",
                unique: true);
        }
    }
}
