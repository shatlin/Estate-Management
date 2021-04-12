using Microsoft.EntityFrameworkCore.Migrations;

namespace MDM.Web.Migrations
{
    public partial class m13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "isInvoiceNeeded",
                table: "TrustAccount",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isInvoiceNeeded",
                table: "TrustAccount");
        }
    }
}
