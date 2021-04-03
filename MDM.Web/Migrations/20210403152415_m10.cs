using Microsoft.EntityFrameworkCore.Migrations;

namespace MDM.Web.Migrations
{
    public partial class m10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_TrustAccountInvoiceFiles_FileType_FileTypeId",
            //    table: "TrustAccountInvoiceFiles");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_TrustAccountInvoiceFiles_TrustAccount_TrustAccountId",
            //    table: "TrustAccountInvoiceFiles");

            migrationBuilder.AddForeignKey(
                name: "FK_TrustAccountInvoiceFiles_FileType",
                table: "TrustAccountInvoiceFiles",
                column: "FileTypeId",
                principalTable: "FileType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrustAccountInvoiceFiles_TrustAccount",
                table: "TrustAccountInvoiceFiles",
                column: "TrustAccountId",
                principalTable: "TrustAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrustAccountInvoiceFiles_FileType",
                table: "TrustAccountInvoiceFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TrustAccountInvoiceFiles_TrustAccount",
                table: "TrustAccountInvoiceFiles");

            migrationBuilder.AddForeignKey(
                name: "FK_TrustAccountInvoiceFiles_FileType_FileTypeId",
                table: "TrustAccountInvoiceFiles",
                column: "FileTypeId",
                principalTable: "FileType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrustAccountInvoiceFiles_TrustAccount_TrustAccountId",
                table: "TrustAccountInvoiceFiles",
                column: "TrustAccountId",
                principalTable: "TrustAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
