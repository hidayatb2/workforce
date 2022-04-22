using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class attendanceadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AttendaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendanceTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckAttendance = table.Column<bool>(type: "bit", nullable: false),
                    LabourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendaceId);
                    table.ForeignKey(
                        name: "FK_Attendances_Labour_LabourId",
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
                values: new object[] { new DateTime(2022, 4, 22, 14, 11, 1, 111, DateTimeKind.Local).AddTicks(3218), "kVQM7c3Vbi1H9wMHqT7UBcm+ITac666edBgNkaqToto=", "FpRvIvie4pQvnZaCuUH7/kyiJS4=" });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_LabourId",
                table: "Attendances",
                column: "LabourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 4, 22, 13, 57, 41, 879, DateTimeKind.Local).AddTicks(668), "wT2WHgsQJp7Fbi2tvT0f3JBi5hGkmoCWM6OzBvbENsk=", "gi9eI0meUtmMv5aAx96lHSTAZpc=" });
        }
    }
}
