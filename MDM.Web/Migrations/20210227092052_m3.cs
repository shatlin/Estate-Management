using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MDM.Web.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityDate",
                table: "UserActivity");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "UserActivity");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TaskItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "SystemUser",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_UnitId",
                table: "SystemUser",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Unit",
                table: "SystemUser",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Unit",
                table: "SystemUser");

            migrationBuilder.DropIndex(
                name: "IX_SystemUser_UnitId",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "SystemUser");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivityDate",
                table: "UserActivity",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "UserActivity",
                type: "text",
                nullable: true);
        }
    }
}
