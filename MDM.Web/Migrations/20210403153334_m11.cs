using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace MDM.Web.Migrations
{
    public partial class m11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrustAccountInvoiceFiles");

            migrationBuilder.CreateTable(
                name: "InvoiceFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    TrustAccountId = table.Column<int>(nullable: false),
                    FileTypeId = table.Column<int>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrustAccountInvoiceFiles_FileType",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrustAccountInvoiceFiles_TrustAccount",
                        column: x => x.TrustAccountId,
                        principalTable: "TrustAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceFiles_FileTypeId",
                table: "InvoiceFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceFiles_TrustAccountId",
                table: "InvoiceFiles",
                column: "TrustAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceFiles");

            migrationBuilder.CreateTable(
                name: "TrustAccountInvoiceFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    FileTypeId = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    TrustAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrustAccountInvoiceFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrustAccountInvoiceFiles_FileType",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrustAccountInvoiceFiles_TrustAccount",
                        column: x => x.TrustAccountId,
                        principalTable: "TrustAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrustAccountInvoiceFiles_FileTypeId",
                table: "TrustAccountInvoiceFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrustAccountInvoiceFiles_TrustAccountId",
                table: "TrustAccountInvoiceFiles",
                column: "TrustAccountId");
        }
    }
}
