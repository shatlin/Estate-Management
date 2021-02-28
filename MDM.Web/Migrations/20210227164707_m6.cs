using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MDM.Web.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Maintenance");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Finance");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Legal");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Special Pr");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Others");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Vetting & Vendors");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Gardening");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Trustees & Portfolios");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Finance");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Legal & Compliance");

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 8, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maintenance" },
                    { 9, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Special Projects" },
                    { 10, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laundry" },
                    { 11, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Club House" }
                });
        }
    }
}
