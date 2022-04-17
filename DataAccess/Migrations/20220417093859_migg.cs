using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labour_Manager_ManagerId",
                table: "Labour");

            migrationBuilder.DropIndex(
                name: "IX_Labour_ManagerId",
                table: "Labour");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Labour");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 17, 15, 8, 58, 38, DateTimeKind.Local).AddTicks(468), "XfUyBvJHy58kwNrClBtSA90e6bV47PWYWrXnLPxgN3c=", "+MlQdaAWfOL2tqmZKMT7hfT34oI=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ManagerId",
                table: "Labour",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 17, 15, 3, 53, 839, DateTimeKind.Local).AddTicks(4718), "ylTPBD4EC58q3zbyqLNLcLulwJ6ixXpkAv2kweMjONw=", "sIbhA3XH20l3wmspAyqE8vfLs0Y=" });

            migrationBuilder.CreateIndex(
                name: "IX_Labour_ManagerId",
                table: "Labour",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Labour_Manager_ManagerId",
                table: "Labour",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
