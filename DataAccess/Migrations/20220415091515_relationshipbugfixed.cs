using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class relationshipbugfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Labour_labourId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Manager_ManagerId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_labourId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ManagerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "labourId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 15, 14, 45, 15, 417, DateTimeKind.Local).AddTicks(1286), "b3iH2u28KVEVU1/4QJGEes+e0lvyKJM+vzBgeWgj1rI=", "6rEHyWkXNpS3h4pejU8Wkijy2OQ=" });

            migrationBuilder.AddForeignKey(
                name: "FK_Labour_Users_Id",
                table: "Labour",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Users_Id",
                table: "Manager",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labour_Users_Id",
                table: "Labour");

            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Users_Id",
                table: "Manager");

            migrationBuilder.AddColumn<Guid>(
                name: "ManagerId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "labourId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 14, 13, 1, 26, 913, DateTimeKind.Local).AddTicks(9833), "SK7hGSJMFTUwdtAKHVTL+4tgfYjIw3+ZcRSIehtkg3o=", "yq0HC5gYvyK5RDyo3ojva3AHBMI=" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_labourId",
                table: "Users",
                column: "labourId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ManagerId",
                table: "Users",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Labour_labourId",
                table: "Users",
                column: "labourId",
                principalTable: "Labour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Manager_ManagerId",
                table: "Users",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
