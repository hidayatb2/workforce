using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Attendances_LabourId",
                table: "Attendances");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("91cc3369-23e9-48c2-bee4-4848fea0491c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a079329f-1d73-4795-af93-2c4fb0cd1e2c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ec1e2a25-8540-483e-8a87-bdaf8e1dc817"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new DateTime(2022, 5, 13, 15, 42, 18, 328, DateTimeKind.Local).AddTicks(1694), "z/JRGUj28dfVSd2PeC2dSjIQhPhWCtzrGiI42+XQi+s=", "Hxjdm2TFTWoq6QdMDpI/u/bE91M=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 42, 18, 328, DateTimeKind.Local).AddTicks(1471), "+fkLJZGFiPO5BI50FCThMNxSXlREEUu/JJT78hZArQs=", "ZpK1FkxSr4/jb0CW03PNcxiMtkc=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DOB", "Email", "ImagePath", "Name", "Password", "PhoneNo", "ResetCode", "Salt", "UpdatedBy", "UpdatedOn", "UserName", "UserRole", "UserStatus" },
                values: new object[,]
                {
                    { new Guid("91cc3369-23e9-48c2-bee4-4848fea0491c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 13, 15, 42, 18, 328, DateTimeKind.Local).AddTicks(1756), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "labour@yopmail.com", "abc", null, "yM12r/Sk97EUhW3ryQ632f6345xX/uHP6qMz2WNgcBA=", "8825084050", null, "6Nf1t0ir1BU6n1IK7Wjh+5oLWGw=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "labour", (byte)5, (byte)1 },
                    { new Guid("a079329f-1d73-4795-af93-2c4fb0cd1e2c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 13, 15, 42, 18, 328, DateTimeKind.Local).AddTicks(1837), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager@yopmail.com", "xyz", null, "jPHytWjjNjv0QdkK59/dgEC1gx4Yufw+MUAbI6z3hVg=", "8825084050", null, "S2pKJzb6g5b3hbWCxuZPx7xpgKc=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager", (byte)4, (byte)1 },
                    { new Guid("ec1e2a25-8540-483e-8a87-bdaf8e1dc817"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 13, 15, 42, 18, 328, DateTimeKind.Local).AddTicks(1800), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contractor@yopmail.com", "xyz", null, "ZNSwcBJpcUFlYDIRLZDajbbCEhzzWSldYEYmQFfd1KE=", "8825084050", null, "oY41x2/ZDLXSrOArBk8bWIS2c7U=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contractor", (byte)3, (byte)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_LabourId",
                table: "Attendances",
                column: "LabourId");
        }
    }
}
