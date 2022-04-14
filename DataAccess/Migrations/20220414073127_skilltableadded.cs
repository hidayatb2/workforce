using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class skilltableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Skill",
                table: "Labour",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Labour",
                newName: "PhoneNo2");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNo",
                table: "Labour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "Labour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Labour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdhaarNo",
                table: "Labour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank",
                table: "Labour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Labour",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IFSC",
                table: "Labour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSkilled",
                table: "Labour",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WagesType = table.Column<byte>(type: "tinyint", nullable: false),
                    Wages = table.Column<float>(type: "real", nullable: false),
                    LabourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Labour_LabourId",
                        column: x => x.LabourId,
                        principalTable: "Labour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 14, 13, 1, 26, 913, DateTimeKind.Local).AddTicks(9833), "SK7hGSJMFTUwdtAKHVTL+4tgfYjIw3+ZcRSIehtkg3o=", "yq0HC5gYvyK5RDyo3ojva3AHBMI=" });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_LabourId",
                table: "Skills",
                column: "LabourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AccountNo",
                table: "Labour");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "Labour");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Labour");

            migrationBuilder.DropColumn(
                name: "AdhaarNo",
                table: "Labour");

            migrationBuilder.DropColumn(
                name: "Bank",
                table: "Labour");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Labour");

            migrationBuilder.DropColumn(
                name: "IFSC",
                table: "Labour");

            migrationBuilder.DropColumn(
                name: "IsSkilled",
                table: "Labour");

            migrationBuilder.RenameColumn(
                name: "PhoneNo2",
                table: "Labour",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Labour",
                newName: "Skill");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 9, 12, 10, 26, 79, DateTimeKind.Local).AddTicks(7544), "hbjEBJE+TfKqD+uu6I7kW469rhsSgEiUX94rSDKdMO0=", "GVLOjVIkzXsz1Gr0wJ5Y/G5KABE=" });
        }
    }
}
