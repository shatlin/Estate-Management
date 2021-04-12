using Microsoft.EntityFrameworkCore.Migrations;

namespace MDM.Web.Migrations
{
    public partial class m12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExpenseGroup",
                table: "TrustAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vendor",
                table: "TrustAccount",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseGroup",
                table: "TrustAccount");

            migrationBuilder.DropColumn(
                name: "Vendor",
                table: "TrustAccount");
        }
    }
}
