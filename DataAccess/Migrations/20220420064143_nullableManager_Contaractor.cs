using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class nullableManager_Contaractor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ContractorId",
                table: "Manager",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
                values: new object[] { new DateTime(2022, 4, 20, 12, 11, 43, 499, DateTimeKind.Local).AddTicks(7168), "lQ4KXGk1DRfU1zfNOBUQwVX4eHyDvT0OVI/M8ALrS0g=", "hsluu5ZvANYFMvxJ60z8P4jn1HM=" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "ContractorId",
                table: "Manager",
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
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 19, 18, 28, 5, 166, DateTimeKind.Local).AddTicks(887), "6jJJ2jeoHyxlayXXWEJaOrXAJi3OBZXUyT0J6TNtJec=", "sLVdZtgA5BmssEtVrB3P/qxjgDY=" });
        }
    }
}
