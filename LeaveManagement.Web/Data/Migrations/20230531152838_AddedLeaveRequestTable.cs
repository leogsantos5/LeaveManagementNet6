using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
    }
}
