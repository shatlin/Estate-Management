﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace MDM.Web.Migrations
{
    public partial class m9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrustAccountInvoiceFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
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
                    table.PrimaryKey("PK_TrustAccountInvoiceFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrustAccountInvoiceFiles_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrustAccountInvoiceFiles_TrustAccount_TrustAccountId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrustAccountInvoiceFiles");
        }
    }
}
