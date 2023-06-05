using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class UpdatedLeaveRequestComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77eae6e4-0be1-4571-880d-3dc46a5d7b68",
                column: "ConcurrencyStamp",
                value: "e6aa89fb-18fe-4b3d-9ab9-36d6d3640323");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a50dfae-598c-4aaa-95a1-51afdfeecfe2",
                column: "ConcurrencyStamp",
                value: "ac501ccf-8c0b-4da1-8e6e-a585477b1396");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09fe4c69-49dc-47a9-9c50-5708b4a0fc83",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97bed992-aba8-4a24-af69-01dfb813c5bc", "AQAAAAEAACcQAAAAELJJAjnDT9rH2tXjyhEulQefAMNACTVoDrvXuKlSeZdN61FzbK7hufMlpjQY8B6sbA==", "85096e7e-93f0-441d-bf03-8e7a6a7c8272" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ea6b6e6-afb5-4c39-a617-05831df08c9e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fa3f557-e716-4fe8-93fb-99ac3ca82fcf", "AQAAAAEAACcQAAAAEG3Tx4GLj6Qq6ryh3G49GuUUPUmxw2/sPbeK/O93zC+wVj5AP8JZE92WZFBydqfJVQ==", "d49c2bf5-5259-46e5-a2a8-4d46506f546c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77eae6e4-0be1-4571-880d-3dc46a5d7b68",
                column: "ConcurrencyStamp",
                value: "db715e83-1d5b-4761-bc9e-d366f3d6325d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a50dfae-598c-4aaa-95a1-51afdfeecfe2",
                column: "ConcurrencyStamp",
                value: "d1a25cec-f327-4a06-83e2-95df225ad95b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09fe4c69-49dc-47a9-9c50-5708b4a0fc83",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79e6cc0c-b75e-478f-b7c7-020543ab06a6", "AQAAAAEAACcQAAAAEEiaYYpobf6g6CBpWRP7snx73XZmfsoudGJhjf9onBtW9EJYqivntYddFuNudUZdpA==", "ac197cea-373e-4f09-87c1-48ec2d56af6b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ea6b6e6-afb5-4c39-a617-05831df08c9e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83f30815-ad36-47c8-b7e7-18f50f711a50", "AQAAAAEAACcQAAAAEHeY092PMYh2Bsmy+C5owNS8gbwbDpzGJ1XGgSdNKg4zN4ZbsBkY8z8uQQubWgZ6jA==", "3558ca4a-5c0a-416d-8695-365d61190f98" });
        }
    }
}
