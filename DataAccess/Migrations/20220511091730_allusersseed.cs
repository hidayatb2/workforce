using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class allusersseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AttendancesAttendaceId",
                table: "Attendances",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "ImagePath", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 11, 14, 47, 29, 933, DateTimeKind.Local).AddTicks(5595), "xyz", "b263/ziwT4Odk65zdKG8r/TVvF9ToW1pGbIZRFzqOyQ=", "7YEC01QTcCQ2q/h8bPzqnyDDobk=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DOB", "Email", "ImagePath", "Name", "Password", "PhoneNo", "ResetCode", "Salt", "UpdatedBy", "UpdatedOn", "UserName", "UserRole", "UserStatus" },
                values: new object[,]
                {
                    { new Guid("03abd488-6472-4e9a-baee-54e654a34b6b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 11, 14, 47, 29, 933, DateTimeKind.Local).AddTicks(5991), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer@yopmail.com", "xyz", null, "/qWA15T0RbIfalkL6LMJOsJA8mVtI6rsUJPtJXsbI1I=", "8825084050", null, "affkO1vBuUembFaycaTgh5LRPFE=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer", (byte)2, (byte)1 },
                    { new Guid("3f75624c-98e5-49e8-82bb-86078d4bdfc9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 11, 14, 47, 29, 933, DateTimeKind.Local).AddTicks(6049), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "labour@yopmail.com", "abc", null, "emIUbK3KAfgSxN62CXrwXNSM4yceUXPYRs/Hk03DDBo=", "8825084050", null, "2FHGZRG8yT3MSpeQ7rkiHRLXhLQ=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "labour", (byte)5, (byte)1 },
                    { new Guid("7e14d027-3f9b-425c-9ae3-ea108e3a051f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 11, 14, 47, 29, 933, DateTimeKind.Local).AddTicks(6102), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contractor@yopmail.com", "xyz", null, "SBzgi+cSA4Alx7wx5kl4NtjL+8ioCEwq1XcB5SqmPWI=", "8825084050", null, "SoDHqQiMD/r2e3drPJ+aiiVZyaM=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contractor", (byte)3, (byte)1 },
                    { new Guid("a282596c-8eb1-4aa3-975e-0958e592a56a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 11, 14, 47, 29, 933, DateTimeKind.Local).AddTicks(6146), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager@yopmail.com", "xyz", null, "qrO5oQa7IgtmfRZgmm20RdBSSHVqx9hSfsD75DE61Hw=", "8825084050", null, "QJIhivlMbIMpq++cqF7BHXuj2h0=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager", (byte)4, (byte)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_AttendancesAttendaceId",
                table: "Attendances",
                column: "AttendancesAttendaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Attendances_AttendancesAttendaceId",
                table: "Attendances",
                column: "AttendancesAttendaceId",
                principalTable: "Attendances",
                principalColumn: "AttendaceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Attendances_AttendancesAttendaceId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_AttendancesAttendaceId",
                table: "Attendances");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("03abd488-6472-4e9a-baee-54e654a34b6b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3f75624c-98e5-49e8-82bb-86078d4bdfc9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7e14d027-3f9b-425c-9ae3-ea108e3a051f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a282596c-8eb1-4aa3-975e-0958e592a56a"));

            migrationBuilder.DropColumn(
                name: "AttendancesAttendaceId",
                table: "Attendances");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "ImagePath", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 10, 15, 35, 41, 896, DateTimeKind.Local).AddTicks(3476), null, "zN7ucLe6ee32C5qL8kXi5rG09bjNYGEs6/yuLL+Q+AM=", "DVdt672pzP024ZWOx4Ld4ftYRjY=" });
        }
    }
}
