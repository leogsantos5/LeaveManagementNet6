using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddingPeriodToAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77eae6e4-0be1-4571-880d-3dc46a5d7b68",
                column: "ConcurrencyStamp",
                value: "8b5d2d4d-595e-49a1-a22d-a29c4f8d4e5c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a50dfae-598c-4aaa-95a1-51afdfeecfe2",
                column: "ConcurrencyStamp",
                value: "6df2d7f5-1266-480d-9fb8-94c9331d5d48");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09fe4c69-49dc-47a9-9c50-5708b4a0fc83",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd23210c-43d3-46b3-8dc2-7814f378c1d6", "AQAAAAEAACcQAAAAEFntl6ukBm0HqnEfRTjrpdfTqyX6KOZ/oEa8eXx51mTsPSxpqMM1HKfIIUUbyxgSYQ==", "f9a24986-08a9-44a0-8258-78c68ef8b20d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ea6b6e6-afb5-4c39-a617-05831df08c9e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65c6e997-5fee-49db-8923-d8c6c12906d0", "AQAAAAEAACcQAAAAEGBZ0wH8fd69MGDszIEQaqBoOgSdrS9ngugpYdoqRBmmVCmr55Dt0QtTPIakyFx0tw==", "b79e8de6-0047-4f6f-b6bc-7fe4734e9309" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77eae6e4-0be1-4571-880d-3dc46a5d7b68",
                column: "ConcurrencyStamp",
                value: "57544d9d-d54b-4e49-8a6f-cc55c13008ea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a50dfae-598c-4aaa-95a1-51afdfeecfe2",
                column: "ConcurrencyStamp",
                value: "2ed0fa38-413f-4a7d-ad8a-b0e973088fb8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09fe4c69-49dc-47a9-9c50-5708b4a0fc83",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00e6fdfb-bb77-4cc1-bece-5fc39b683434", "AQAAAAEAACcQAAAAEJrZhGtg9rtbW2Ez2SdT9GIBx+UwPglafML7NQODXe8OJ1mHyg0toKCUZJHIFbaq7Q==", "cb96aa6b-cc93-4ae0-acf9-74584ffb164f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ea6b6e6-afb5-4c39-a617-05831df08c9e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90aee70d-3a01-4925-9293-6bdd5d567366", "AQAAAAEAACcQAAAAECwO/Q4+7oJVx6LRP2q6nTGSJR4JMXiQa/N9zzGDGmFuvY9yxAeIr0UA1+PBbazGSg==", "2ca16c7c-c9d9-46ab-acdf-0eb218701a08" });
        }
    }
}
