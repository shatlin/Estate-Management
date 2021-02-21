using Microsoft.EntityFrameworkCore.Migrations;

namespace WISA.Web.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "AmountWrittenOff",
                table: "Organization",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AccountBalanceBase",
                table: "Organization",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AccountBalance",
                table: "Organization",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ExchangeRate",
                table: "MemberUser",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Accountbalanceofthecompany_base",
                table: "MemberUser",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AccountBalanceOftheCompany",
                table: "MemberUser",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentAmount",
                table: "Billing",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaidAmount",
                table: "Billing",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 3)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "AmountWrittenOff",
                table: "Organization",
                type: "decimal(18, 3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AccountBalanceBase",
                table: "Organization",
                type: "decimal(18, 3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AccountBalance",
                table: "Organization",
                type: "decimal(18, 3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ExchangeRate",
                table: "MemberUser",
                type: "decimal(18, 3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Accountbalanceofthecompany_base",
                table: "MemberUser",
                type: "decimal(18, 3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AccountBalanceOftheCompany",
                table: "MemberUser",
                type: "decimal(18, 3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentAmount",
                table: "Billing",
                type: "decimal(18, 3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaidAmount",
                table: "Billing",
                type: "decimal(18, 3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);
        }
    }
}
