using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedDefaultUsersUsernames5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77eae6e4-0be1-4571-880d-3dc46a5d7b68",
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "57544d9d-d54b-4e49-8a6f-cc55c13008ea", "Administrator" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77eae6e4-0be1-4571-880d-3dc46a5d7b68",
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "2285e747-7dc3-4e10-a957-4ab2930a601f", "Admnistrator" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a50dfae-598c-4aaa-95a1-51afdfeecfe2",
                column: "ConcurrencyStamp",
                value: "342b103b-ec02-490a-8572-32329e113a4c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09fe4c69-49dc-47a9-9c50-5708b4a0fc83",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea1623b9-791d-4a77-9a73-a9200cd33488", "AQAAAAEAACcQAAAAEPD1A79sSRgj3//irqZ7Y6kBDHK9Ip2q8CUpJBukNseie5ypc7moE8IfvxZ74Ibz/A==", "9c59a278-b1bd-4cd6-958c-97283fc718cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ea6b6e6-afb5-4c39-a617-05831df08c9e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d691d1a3-be64-427e-8c11-0ad5fde1a57b", "AQAAAAEAACcQAAAAELffM4I9Qa+obnM7YBh5ElJs15Oa5JCdqW7Deh6AbLJm71lXQx/S3avS2S2wPXZPVw==", "2171be51-e228-44e4-8e38-13ab0d4bcc17" });
        }
    }
}
