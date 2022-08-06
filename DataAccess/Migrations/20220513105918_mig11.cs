using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Attendances_LabourId",
                table: "Attendances");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("194f8b80-a778-4046-96f2-e0f0f9ad7ad5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1e214ecc-9094-4c53-ae7e-de79943f6655"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("91c1b9d2-80c2-4b10-8262-21088e6804fb"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("03abd488-6472-4e9a-baee-54e654a34b6b"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 13, 16, 29, 18, 114, DateTimeKind.Local).AddTicks(6873), "rTuVoop/6GCSy1LnZmTFOWyr3dVJw7QEI4oj1s9flQA=", "d6ijRYNMY5Gis04hxHjFbB4YeWk=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 13, 16, 29, 18, 114, DateTimeKind.Local).AddTicks(6656), "lrmpsn5eRa+UrJN4xkKSCp0qom8MvyLAQRN8d8pilKY=", "MIohBDLSX3/7GZm/GeiO8SwvQMY=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DOB", "Email", "ImagePath", "Name", "Password", "PhoneNo", "ResetCode", "Salt", "UpdatedBy", "UpdatedOn", "UserName", "UserRole", "UserStatus" },
                values: new object[,]
                {
                    { new Guid("1c2c8017-0605-4c91-ade6-b60b5f5f9cb9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 13, 16, 29, 18, 114, DateTimeKind.Local).AddTicks(7009), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager@yopmail.com", "xyz", null, "2GnnI+FIvruFQZuMuuCrOpp0tznZD3eoEFTCwJ5wmjw=", "8825084050", null, "tGs8ekmcq8QssmPNjMiirOavE24=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager", (byte)4, (byte)1 },
                    { new Guid("911aae2e-5445-47d2-a882-a5fc31fffafe"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 13, 16, 29, 18, 114, DateTimeKind.Local).AddTicks(6906), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "labour@yopmail.com", "abc", null, "UYCFg4yxAr8jFMlx+tgWslWXKz09nJVujFq5wml5aVM=", "8825084050", null, "tlsK47PLyZ9vnw4qy699uQfnNQU=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "labour", (byte)5, (byte)1 },
                    { new Guid("a6106ea2-7627-45f2-a719-9dd157bc5b1d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 13, 16, 29, 18, 114, DateTimeKind.Local).AddTicks(6959), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contractor@yopmail.com", "xyz", null, "Z6ckFPI/x8hH+ZNE9Ebxz32tTa67Ikx/Yk/rkeLv9Sg=", "8825084050", null, "JHFD2F6v7gZYnZ9X2G5/sNV+sqg=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contractor", (byte)3, (byte)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_LabourId",
                table: "Attendances",
                column: "LabourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Attendances_LabourId",
                table: "Attendances");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1c2c8017-0605-4c91-ade6-b60b5f5f9cb9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("911aae2e-5445-47d2-a882-a5fc31fffafe"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a6106ea2-7627-45f2-a719-9dd157bc5b1d"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("03abd488-6472-4e9a-baee-54e654a34b6b"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 52, 12, 195, DateTimeKind.Local).AddTicks(7293), "mGSGxwv7gq0PnYAq1A2AvXaRcwJbJgQkVUodHT/hI78=", "tEJiH7xAcDp7cUhfFAbyvD55NhM=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 52, 12, 195, DateTimeKind.Local).AddTicks(7077), "2xIekr0vZ7w0aoK5cvloof+FHrxyL/IevtdeuXfXBKE=", "mEK4GT/BdjO/D1XqCrvGY6Qe4x4=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DOB", "Email", "ImagePath", "Name", "Password", "PhoneNo", "ResetCode", "Salt", "UpdatedBy", "UpdatedOn", "UserName", "UserRole", "UserStatus" },
                values: new object[,]
                {
                    { new Guid("194f8b80-a778-4046-96f2-e0f0f9ad7ad5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 13, 15, 52, 12, 195, DateTimeKind.Local).AddTicks(7362), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contractor@yopmail.com", "xyz", null, "AcTP5/DnYP9sQYlSEoqjN/U4VpsB5YJwHlZwqoIM3gM=", "8825084050", null, "h2LBylMbLOwInh+2+uoqn4tQN3c=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contractor", (byte)3, (byte)1 },
                    { new Guid("1e214ecc-9094-4c53-ae7e-de79943f6655"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 13, 15, 52, 12, 195, DateTimeKind.Local).AddTicks(7325), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "labour@yopmail.com", "abc", null, "+fYyMkzfaHm2r+r0H//beB71h6GMvA1CfEcdbY89QuE=", "8825084050", null, "4CRcqm5iAyOUGafsR4dbvI9xAL4=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "labour", (byte)5, (byte)1 },
                    { new Guid("91c1b9d2-80c2-4b10-8262-21088e6804fb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 13, 15, 52, 12, 195, DateTimeKind.Local).AddTicks(7385), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager@yopmail.com", "xyz", null, "33wQ/3lheo2VTFf8e6cYm9JFukiw/3gW4SXodCneY9M=", "8825084050", null, "gqPNqGPP5tQ7OP6LQ6aXuVwZtBk=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager", (byte)4, (byte)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_LabourId",
                table: "Attendances",
                column: "LabourId",
                unique: true);
        }
    }
}
