using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migAttendancesdel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Attendances",
                table: "Attendances");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOut",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("03abd488-6472-4e9a-baee-54e654a34b6b"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 14, 18, 9, 53, 672, DateTimeKind.Local).AddTicks(3535), "mPztg8lNzQ/PHuyUBhUoihmsTKIFFt9kx3GGH+4t3fQ=", "qZ/ya6FgY7YNEYKpSNHQ681Cld4=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87843532-0b93-492d-824b-68be17a82037"),
                columns: new[] { "CreatedOn", "Password", "Salt" },
                values: new object[] { new DateTime(2022, 5, 14, 18, 9, 53, 672, DateTimeKind.Local).AddTicks(3296), "ywBZ/szBhHnQb203lsGkBDC/E/4z/FgLjO+jVrMYkrU=", "JzEk31rMWyAFwseWNUjibTx72fk=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DOB", "Email", "ImagePath", "Name", "Password", "PhoneNo", "ResetCode", "Salt", "UpdatedBy", "UpdatedOn", "UserName", "UserRole", "UserStatus" },
                values: new object[,]
                {
                    { new Guid("23c86796-d328-4b24-807f-4ccab3d8a900"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 14, 18, 9, 53, 672, DateTimeKind.Local).AddTicks(3647), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contractor@yopmail.com", "xyz", null, "ERpev9arXuTg9Aqq5aH407RtPr13W9U6WuGBHlGKLos=", "8825084050", null, "tjFs+yzN9PJH7OXqg7qSmi5wGCU=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contractor", (byte)3, (byte)1 },
                    { new Guid("8fbcb963-f4a6-410d-ac28-0f8d279bbaec"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 14, 18, 9, 53, 672, DateTimeKind.Local).AddTicks(3684), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager@yopmail.com", "xyz", null, "fgV2jprxv491O+YAAtkoG6ifHkOghrb1C9mWH6tX8PE=", "8825084050", null, "Ptg5XPgO0kT4BJZjIm3Fb3VdcEQ=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager", (byte)4, (byte)1 },
                    { new Guid("cccb69d6-ef28-41dd-8e90-2f21c0fe97c3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 14, 18, 9, 53, 672, DateTimeKind.Local).AddTicks(3604), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "labour@yopmail.com", "abc", null, "E+j/nGicSuGX88P8REM5z+SSDRycB9EiSVsRgxe3Y6E=", "8825084050", null, "CIH6zijVH2rNpRQ02/rpcbG+EnI=", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "labour", (byte)5, (byte)1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("23c86796-d328-4b24-807f-4ccab3d8a900"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8fbcb963-f4a6-410d-ac28-0f8d279bbaec"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cccb69d6-ef28-41dd-8e90-2f21c0fe97c3"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOut",
                table: "Attendances",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<byte>(
                name: "Attendances",
                table: "Attendances",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

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
        }
    }
}
