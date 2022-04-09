using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class seedmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contractor_Users_Id",
                table: "Contractor");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Users_Id",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Labour_labourId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Manager_ManagerId",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Email", "ManagerId", "Password", "PhoneNo", "ResetCode", "Salt", "UpdatedBy", "UpdatedOn", "UserName", "UserRole", "UserStatus", "labourId" },
                values: new object[] { new Guid("87843532-0b93-492d-824b-68be17a82037"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 4, 9, 12, 10, 26, 79, DateTimeKind.Local).AddTicks(7544), "admin@yopmail.com", null, "hbjEBJE+TfKqD+uu6I7kW469rhsSgEiUX94rSDKdMO0=", "8825084050", null, "GVLOjVIkzXsz1Gr0wJ5Y/G5KABE=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", (byte)1, (byte)1, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Contractor_Users_Id",
                table: "Contractor",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Users_Id",
                table: "Customer",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contractor_Users_Id",
                table: "Contractor");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Users_Id",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Labour_labourId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Manager_ManagerId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"));

            migrationBuilder.AddForeignKey(
                name: "FK_Contractor_Users_Id",
                table: "Contractor",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Users_Id",
                table: "Customer",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Labour_labourId",
                table: "Users",
                column: "labourId",
                principalTable: "Labour",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Manager_ManagerId",
                table: "Users",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id");
        }
    }
}
