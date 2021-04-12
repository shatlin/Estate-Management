using Microsoft.EntityFrameworkCore.Migrations;

namespace MDM.Web.Migrations
{
    public partial class m14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseGroup",
                table: "TrustAccount");

            migrationBuilder.DropColumn(
                name: "Vendor",
                table: "TrustAccount");

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "TrustAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "TrustAccount",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "TrustAccount");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "TrustAccount");

            migrationBuilder.AddColumn<string>(
                name: "ExpenseGroup",
                table: "TrustAccount",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vendor",
                table: "TrustAccount",
                type: "text",
                nullable: true);
        }
    }
}
