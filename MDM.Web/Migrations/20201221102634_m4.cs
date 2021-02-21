using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WISA.Web.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "CountryId", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 10, 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
