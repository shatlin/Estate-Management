using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MDM.Web.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Vetting & Vendors");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Legal & Compliance");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Maintenance");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Laundry");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Club House");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Vetting &Vendors");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Legal");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Mainteance");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Invoices & Approvals");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Monthly Reports");

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 7, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compliance" },
                    { 12, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laundry" },
                    { 13, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Club House" },
                    { 14, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Owner Requests" }
                });
        }
    }
}
