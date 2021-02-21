using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WISA.Web.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MemberStatus",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "MemberStatus",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Suspended");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MemberStatus",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Suspended – account in arrears");

            migrationBuilder.InsertData(
                table: "MemberStatus",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspended" });
        }
    }
}
