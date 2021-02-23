using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MDM.Web.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TaskItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskItemTypeId",
                table: "TaskItem",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskItemType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItemType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "DSTV" },
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Water" },
                    { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Damp" },
                    { 4, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pets" },
                    { 5, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garden" },
                    { 6, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Security" },
                    { 7, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leakage" }
                });

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Owner Requests");

            migrationBuilder.InsertData(
                table: "TaskItemType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Issue" },
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Request" },
                    { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complaint" },
                    { 4, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Query" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_CategoryId",
                table: "TaskItem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_TaskItemTypeId",
                table: "TaskItem",
                column: "TaskItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_Category",
                table: "TaskItem",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_TaskItemType",
                table: "TaskItem",
                column: "TaskItemTypeId",
                principalTable: "TaskItemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_Category",
                table: "TaskItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_TaskItemType",
                table: "TaskItem");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "TaskItemType");

            migrationBuilder.DropIndex(
                name: "IX_TaskItem_CategoryId",
                table: "TaskItem");

            migrationBuilder.DropIndex(
                name: "IX_TaskItem_TaskItemTypeId",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "TaskItemTypeId",
                table: "TaskItem");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Oaner Requests");

            migrationBuilder.InsertData(
                table: "TaskItem",
                columns: new[] { "Id", "ClosedOn", "CreatedBy", "CreatedOn", "Description", "DueOn", "GroupId", "ModifiedBy", "ModifiedOn", "Name", "PriorityId", "ProgressPercentage", "StatusId", "UnitId" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Open", null, null, null, null },
                    { 2, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", null, null, null, null },
                    { 3, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Progress", null, null, null, null },
                    { 4, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", null, null, null, null },
                    { 5, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Review", null, null, null, null },
                    { 6, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accepted", null, null, null, null },
                    { 7, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rejected", null, null, null, null },
                    { 8, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blocked", null, null, null, null },
                    { 9, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Closed", null, null, null, null }
                });
        }
    }
}
