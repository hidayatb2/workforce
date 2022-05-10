using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class lastmig : Migration
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

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteWorkers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteWorkers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteWorkers_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteWorkers_Users_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 9, 17, 15, 18, 238, DateTimeKind.Local).AddTicks(7685), "KJE09VzkHNcp4MhIrghxrCMvtUDyG0WaEoFC9HolpMw=", "FuQ1py61RfLQAyg8AC5OPUHd7bg=" });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PartcipantId",
                table: "Participants",
                column: "PartcipantId",
                unique: true,
                filter: "[PartcipantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SiteWorkers_SiteId",
                table: "SiteWorkers",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteWorkers_WorkerId",
                table: "SiteWorkers",
                column: "WorkerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteWorkers");

            migrationBuilder.DropTable(
                name: "Sites");

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
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 23, 17, 10, 23, 519, DateTimeKind.Local).AddTicks(6886), "hkusCKwzgZ5D7IJZ56Iw8npWmcP1hWCAV1KLsHU1U4c=", "QQpkbR+2O5Ko36bzvbIe7JL907k=" });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PartcipantId",
                table: "Participants",
                column: "PartcipantId",
                unique: true);
        }
    }
}
