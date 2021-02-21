using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WISA.Web.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Affliation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affliation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 50, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientBranch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientBranch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientOrganizationGrade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOrganizationGrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientTimeZone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTimeZone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUsRelatedTo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUsRelatedTo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorrespondenceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrespondenceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    Symbol = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomField",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TableName = table.Column<string>(nullable: true),
                    TablePrimaryKeyValue = table.Column<int>(nullable: false),
                    Int1 = table.Column<int>(nullable: true),
                    Int2 = table.Column<int>(nullable: true),
                    Int3 = table.Column<int>(nullable: true),
                    Int4 = table.Column<int>(nullable: true),
                    Int5 = table.Column<int>(nullable: true),
                    Int6 = table.Column<int>(nullable: true),
                    Int7 = table.Column<int>(nullable: true),
                    Int8 = table.Column<int>(nullable: true),
                    Int9 = table.Column<int>(nullable: true),
                    Int10 = table.Column<int>(nullable: true),
                    Int11 = table.Column<int>(nullable: true),
                    Int12 = table.Column<int>(nullable: true),
                    Int13 = table.Column<int>(nullable: true),
                    Int14 = table.Column<int>(nullable: true),
                    Int15 = table.Column<int>(nullable: true),
                    Int16 = table.Column<int>(nullable: true),
                    Int17 = table.Column<int>(nullable: true),
                    Int18 = table.Column<int>(nullable: true),
                    Int19 = table.Column<int>(nullable: true),
                    Int20 = table.Column<int>(nullable: true),
                    Lookup1 = table.Column<int>(nullable: true),
                    Lookup2 = table.Column<int>(nullable: true),
                    Lookup3 = table.Column<int>(nullable: true),
                    Lookup4 = table.Column<int>(nullable: true),
                    Lookup5 = table.Column<int>(nullable: true),
                    Lookup6 = table.Column<int>(nullable: true),
                    Lookup7 = table.Column<int>(nullable: true),
                    Lookup8 = table.Column<int>(nullable: true),
                    Lookup9 = table.Column<int>(nullable: true),
                    Lookup10 = table.Column<int>(nullable: true),
                    Lookup11 = table.Column<int>(nullable: true),
                    Lookup12 = table.Column<int>(nullable: true),
                    Lookup13 = table.Column<int>(nullable: true),
                    Lookup14 = table.Column<int>(nullable: true),
                    Lookup15 = table.Column<int>(nullable: true),
                    Lookup16 = table.Column<int>(nullable: true),
                    Lookup17 = table.Column<int>(nullable: true),
                    Lookup18 = table.Column<int>(nullable: true),
                    Lookup19 = table.Column<int>(nullable: true),
                    Lookup20 = table.Column<int>(nullable: true),
                    Text1 = table.Column<string>(nullable: true),
                    Text2 = table.Column<string>(nullable: true),
                    Text3 = table.Column<string>(nullable: true),
                    Text4 = table.Column<string>(nullable: true),
                    Text5 = table.Column<string>(nullable: true),
                    Text6 = table.Column<string>(nullable: true),
                    Text7 = table.Column<string>(nullable: true),
                    Text8 = table.Column<string>(nullable: true),
                    Text9 = table.Column<string>(nullable: true),
                    Text10 = table.Column<string>(nullable: true),
                    Text11 = table.Column<string>(nullable: true),
                    Text12 = table.Column<string>(nullable: true),
                    Text13 = table.Column<string>(nullable: true),
                    Text14 = table.Column<string>(nullable: true),
                    Text15 = table.Column<string>(nullable: true),
                    Text16 = table.Column<string>(nullable: true),
                    Text17 = table.Column<string>(nullable: true),
                    Text18 = table.Column<string>(nullable: true),
                    Text19 = table.Column<string>(nullable: true),
                    Text20 = table.Column<string>(nullable: true),
                    Datetime1 = table.Column<DateTime>(nullable: true),
                    Datetime2 = table.Column<DateTime>(nullable: true),
                    Datetime3 = table.Column<DateTime>(nullable: true),
                    Datetime4 = table.Column<DateTime>(nullable: true),
                    Datetime5 = table.Column<DateTime>(nullable: true),
                    Datetime6 = table.Column<DateTime>(nullable: true),
                    Datetime7 = table.Column<DateTime>(nullable: true),
                    Datetime8 = table.Column<DateTime>(nullable: true),
                    Datetime9 = table.Column<DateTime>(nullable: true),
                    Datetime10 = table.Column<DateTime>(nullable: true),
                    Datetime11 = table.Column<DateTime>(nullable: true),
                    Datetime12 = table.Column<DateTime>(nullable: true),
                    Datetime13 = table.Column<DateTime>(nullable: true),
                    Datetime14 = table.Column<DateTime>(nullable: true),
                    Datetime15 = table.Column<DateTime>(nullable: true),
                    Datetime16 = table.Column<DateTime>(nullable: true),
                    Datetime17 = table.Column<DateTime>(nullable: true),
                    Datetime18 = table.Column<DateTime>(nullable: true),
                    Datetime19 = table.Column<DateTime>(nullable: true),
                    Datetime20 = table.Column<DateTime>(nullable: true),
                    Decimal1 = table.Column<decimal>(nullable: true),
                    Decimal2 = table.Column<decimal>(nullable: true),
                    Decimal3 = table.Column<decimal>(nullable: true),
                    Decimal4 = table.Column<decimal>(nullable: true),
                    Decimal5 = table.Column<decimal>(nullable: true),
                    Decimal6 = table.Column<decimal>(nullable: true),
                    Decimal7 = table.Column<decimal>(nullable: true),
                    Decimal8 = table.Column<decimal>(nullable: true),
                    Decimal9 = table.Column<decimal>(nullable: true),
                    Decimal10 = table.Column<decimal>(nullable: true),
                    Decimal11 = table.Column<decimal>(nullable: true),
                    Decimal12 = table.Column<decimal>(nullable: true),
                    Decimal13 = table.Column<decimal>(nullable: true),
                    Decimal14 = table.Column<decimal>(nullable: true),
                    Decimal15 = table.Column<decimal>(nullable: true),
                    Decimal16 = table.Column<decimal>(nullable: true),
                    Decimal17 = table.Column<decimal>(nullable: true),
                    Decimal18 = table.Column<decimal>(nullable: true),
                    Decimal19 = table.Column<decimal>(nullable: true),
                    Decimal20 = table.Column<decimal>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomField", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldLookUp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TableName = table.Column<string>(maxLength: 50, nullable: false),
                    FieldIndex = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldLookUp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldName",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TableName = table.Column<string>(maxLength: 50, nullable: false),
                    FieldIndex = table.Column<int>(nullable: true),
                    DataType = table.Column<string>(maxLength: 50, nullable: true),
                    Label = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disability",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disability", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisabilityLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabilityLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DWSClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 15, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DWSClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplateName",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplateName", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmailType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ethnicity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ethnicity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventMinuteStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventMinuteStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventResponseType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventResponseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NextInvoiceNumber = table.Column<int>(nullable: false),
                    SendInvForPendingPayments = table.Column<bool>(nullable: false),
                    CopyInvToOrgContact = table.Column<bool>(nullable: false),
                    SendRecToPayer = table.Column<bool>(nullable: false),
                    CopyRecToOrgContact = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Involvement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 400, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Involvement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketingGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketingProfile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberActivity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    ActivityDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ActivityDetail = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberActivity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberBranch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberBranch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberCodeGenerator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Prefix = table.Column<string>(maxLength: 50, nullable: true),
                    LastNumber = table.Column<int>(nullable: true),
                    Suffix = table.Column<string>(maxLength: 50, nullable: true),
                    CodeGenerationRule = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberCodeGenerator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberLoginAudit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    LoginTime = table.Column<int>(nullable: false),
                    LogoutTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberLoginAudit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberShipChangeReason",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberShipChangeReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipGrade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IndividualOrNonIndividualId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipGrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberTeam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTeam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occupation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationGrade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationGrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationStructure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    LevelOfMember = table.Column<int>(nullable: false),
                    MaximumNumber = table.Column<int>(nullable: false),
                    MaximumTimeInYears = table.Column<int>(nullable: true),
                    ShowMaximumTimeInYears = table.Column<bool>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationStructure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentGateway",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    ClientIdForMerchant = table.Column<string>(maxLength: 100, nullable: true),
                    ClientPasswordForMerchant = table.Column<string>(maxLength: 100, nullable: true),
                    ClientAPICodeForMerchant = table.Column<string>(maxLength: 100, nullable: true),
                    MerchantNumber = table.Column<string>(maxLength: 100, nullable: true),
                    MerchantName = table.Column<string>(maxLength: 100, nullable: true),
                    MerchantLocation = table.Column<string>(maxLength: 100, nullable: true),
                    CommisionPercentage = table.Column<decimal>(type: "decimal(6, 3)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentGateway", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayPalConnectionMode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayPalConnectionMode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayPalPreferredPaymentGateway",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayPalPreferredPaymentGateway", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanFrequency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanFrequency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreferredContactTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferredContactTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionResponseType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionResponseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualificationCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualificationEnrolmentCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationEnrolmentCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualificationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReferralType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelatedTo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedTo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelatedToId = table.Column<int>(nullable: false),
                    RelatedRecordId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tax",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TaxCode = table.Column<string>(maxLength: 50, nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tax", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxPolicy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPolicy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxScope",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TaxScopeCode = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxScope", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ThemeNumber = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeFormat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeFormat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserActivity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    ActivityDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ActivityDetail = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerHours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankingDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountTypeId = table.Column<int>(nullable: false),
                    AccountName = table.Column<string>(maxLength: 50, nullable: false),
                    BankName = table.Column<string>(maxLength: 50, nullable: false),
                    BranchName = table.Column<string>(maxLength: 100, nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: false),
                    RoutingCode = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankingDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankingDetail_AccountType",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 50, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(maxLength: 50, nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationPreference",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CommunicationTypeId = table.Column<int>(nullable: false),
                    PreferredTimeFrom = table.Column<TimeSpan>(nullable: true),
                    PreferredTimeTo = table.Column<TimeSpan>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationPreference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunicationPreference_CommunicationType",
                        column: x => x.CommunicationTypeId,
                        principalTable: "CommunicationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CurrencyId = table.Column<int>(nullable: true),
                    GeneralInstructions = table.Column<string>(maxLength: 2000, nullable: true),
                    EventsInstructions = table.Column<string>(maxLength: 2000, nullable: true),
                    ApplicationInstructions = table.Column<string>(maxLength: 2000, nullable: true),
                    ClientPayPalConnectionModeId = table.Column<int>(nullable: true),
                    PayPalAccountId = table.Column<string>(maxLength: 200, nullable: true),
                    PayPalPDTIdentityToken = table.Column<string>(maxLength: 200, nullable: true),
                    DefaultCountryId = table.Column<int>(nullable: true),
                    PayPalAPIUserName = table.Column<string>(maxLength: 50, nullable: true),
                    PayPalAPIPassword = table.Column<string>(maxLength: 50, nullable: true),
                    PayPalAPISignature = table.Column<string>(maxLength: 200, nullable: true),
                    PayPalPreferredPaymentGatewayId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentSetting_Currency",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplateContent",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    EmailTemplateNameId = table.Column<int>(nullable: false),
                    EmailContent = table.Column<string>(maxLength: 4000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplateContent", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmailTemplateContent_EmailTemplateName",
                        column: x => x.EmailTemplateNameId,
                        principalTable: "EmailTemplateName",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentCount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EquipmentId = table.Column<int>(nullable: false),
                    AvailableCount = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentCount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentCount_Equipment",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LandingPage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberShipGradeId = table.Column<int>(nullable: false),
                    PageId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandingPage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandingPage_MembershipGrade",
                        column: x => x.MemberShipGradeId,
                        principalTable: "MembershipGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LandingPage_Page",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CPDMemberLevelSetUp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelatedToId = table.Column<int>(nullable: false),
                    RelatedRecordId = table.Column<int>(nullable: false),
                    MemberLevelId = table.Column<int>(nullable: true),
                    CPDCount = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPDMemberLevelSetUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPDMemberLevelSetUp_MemberLevel",
                        column: x => x.MemberLevelId,
                        principalTable: "MemberLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPDMemberLevelSetUp_RelatedTo",
                        column: x => x.RelatedToId,
                        principalTable: "RelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CPDMembershipGradeSetUp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelatedToId = table.Column<int>(nullable: false),
                    RelatedRecordId = table.Column<int>(nullable: false),
                    MembershipGradeId = table.Column<int>(nullable: true),
                    CPDCount = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPDMembershipGradeSetUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPDMembershipGradeSetUp_MembershipGrade",
                        column: x => x.MembershipGradeId,
                        principalTable: "MembershipGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPDMembershipGradeSetUp_RelatedTo",
                        column: x => x.RelatedToId,
                        principalTable: "RelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CPDMembershipTypeSetUp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelatedToId = table.Column<int>(nullable: false),
                    RelatedRecordId = table.Column<int>(nullable: false),
                    MembershipTypeId = table.Column<int>(nullable: true),
                    CPDCount = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPDMembershipTypeSetUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPDMembershipTypeSetUp_MembershipType",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPDMembershipTypeSetUp_RelatedTo",
                        column: x => x.RelatedToId,
                        principalTable: "RelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CPDMemberTeamSetUp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelatedToId = table.Column<int>(nullable: false),
                    RelatedRecordId = table.Column<int>(nullable: false),
                    MemberTeamId = table.Column<int>(nullable: true),
                    CPDCount = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPDMemberTeamSetUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPDMemberTeamSetUp_MemberTeam",
                        column: x => x.MemberTeamId,
                        principalTable: "MemberTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPDMemberTeamSetUp_RelatedTo",
                        column: x => x.RelatedToId,
                        principalTable: "RelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberEmailXref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelatedEntityId = table.Column<int>(nullable: true),
                    RelatedToId = table.Column<int>(nullable: true),
                    Body = table.Column<string>(type: "TEXT", nullable: true),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    CC = table.Column<string>(nullable: true),
                    BCC = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberEmailXref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberEmailXref_RelatedTo",
                        column: x => x.RelatedToId,
                        principalTable: "RelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberNotesXref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelatedEntityId = table.Column<int>(nullable: true),
                    RelatedToId = table.Column<int>(nullable: true),
                    Subject = table.Column<string>(maxLength: 1000, nullable: true),
                    Notes = table.Column<string>(type: "Text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberNotesXref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberNotesXref_RelatedTo",
                        column: x => x.RelatedToId,
                        principalTable: "RelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberRefereeXref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelatedEntityId = table.Column<int>(nullable: true),
                    RelatedToId = table.Column<int>(nullable: true),
                    CellPhone = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Initials = table.Column<string>(maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    NameOfEmployer = table.Column<string>(maxLength: 100, nullable: true),
                    PositionOfReferree = table.Column<string>(maxLength: 100, nullable: true),
                    ProfessionalRegistrationNumber = table.Column<string>(maxLength: 50, nullable: true),
                    TelephoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 10, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRefereeXref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberRefereeXref_RelatedTo",
                        column: x => x.RelatedToId,
                        principalTable: "RelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PromotionMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelatedToId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BenefitStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BenefitEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionMaster_RelatedTo_RelatedToId",
                        column: x => x.RelatedToId,
                        principalTable: "RelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailCCRule",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmailTypeId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailCCRule", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmailCCRule_EmailType",
                        column: x => x.EmailTypeId,
                        principalTable: "EmailType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmailCCRule_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissionXRef",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    Permissionid = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionXRef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissionXRef_Permission",
                        column: x => x.Permissionid,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermissionXRef_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientOrganization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    AgreedToTerms = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DateSettingId = table.Column<int>(nullable: true),
                    TimeFormatId = table.Column<int>(nullable: true),
                    ClientTimeZoneId = table.Column<int>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: true),
                    ClientOrganizationTypeId = table.Column<int>(nullable: true),
                    CurrencyDecimalPlaces = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOrganization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientOrganization_ClientOrganizationType",
                        column: x => x.ClientOrganizationTypeId,
                        principalTable: "ClientOrganizationGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_TimeZone",
                        column: x => x.ClientTimeZoneId,
                        principalTable: "ClientTimeZone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_Currency",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_DateSetting",
                        column: x => x.DateSettingId,
                        principalTable: "DateSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_TimeFormat",
                        column: x => x.TimeFormatId,
                        principalTable: "TimeFormat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime", nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 100, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 100, nullable: true),
                    TitleId = table.Column<int>(nullable: true),
                    UserTypeId = table.Column<int>(nullable: false),
                    IsAdminCreated = table.Column<bool>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Gender",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Title",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_UserType",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StateId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_State",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentSettingAllowedCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PaymentSettingId = table.Column<int>(nullable: false),
                    PaymentCardId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSettingAllowedCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentSettingAllowedCard_PaymentCard",
                        column: x => x.PaymentCardId,
                        principalTable: "PaymentCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentSettingAllowedCard_PaymentSetting",
                        column: x => x.PaymentSettingId,
                        principalTable: "PaymentSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    MembershipTypeId = table.Column<int>(nullable: false),
                    IsLimited = table.Column<bool>(nullable: true),
                    LimitToMemberCount = table.Column<int>(nullable: true),
                    ApplyTaxSettings = table.Column<bool>(nullable: false),
                    PaymentMethodId = table.Column<int>(nullable: false),
                    CanPublicApply = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanMaster_MembershipType",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanMaster_PaymentSetting",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PromotionDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PromotionMasterId = table.Column<int>(nullable: false),
                    MembershipGradeId = table.Column<int>(nullable: true),
                    MemberLevelId = table.Column<int>(nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(9, 3)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionDetail_MemberLevel",
                        column: x => x.MemberLevelId,
                        principalTable: "MemberLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PromotionDetail_MembershipGrade",
                        column: x => x.MembershipGradeId,
                        principalTable: "MembershipGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PromotionDetail_PromotionMaster",
                        column: x => x.PromotionMasterId,
                        principalTable: "PromotionMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 50, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(maxLength: 50, nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 50, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 50, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 50, nullable: false),
                    RoleId = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 50, nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicaitonUserId = table.Column<string>(maxLength: 50, nullable: false),
                    PrimaryContact = table.Column<bool>(nullable: false),
                    BillingContact = table.Column<bool>(nullable: false),
                    DesignationId = table.Column<int>(nullable: true),
                    ReferralTypeId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(maxLength: 1000, nullable: true),
                    IsInternalUser = table.Column<bool>(nullable: false),
                    TermsAccepted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_ClientUser",
                        column: x => x.ApplicaitonUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Designation",
                        column: x => x.DesignationId,
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_ReferralType",
                        column: x => x.ReferralTypeId,
                        principalTable: "ReferralType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientUser_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelatedEntityId = table.Column<int>(nullable: true),
                    RelatedToId = table.Column<int>(nullable: true),
                    AddressTypeId = table.Column<int>(nullable: true),
                    AddressLine1 = table.Column<string>(maxLength: 200, nullable: true),
                    AddressLine2 = table.Column<string>(maxLength: 200, nullable: true),
                    AddressLine3 = table.Column<string>(maxLength: 200, nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    StateId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    PostalCode = table.Column<string>(maxLength: 50, nullable: true),
                    PrimaryContactNo = table.Column<string>(maxLength: 50, nullable: true),
                    SecondaryContactNo = table.Column<string>(maxLength: 50, nullable: true),
                    PrimaryEmail = table.Column<string>(maxLength: 50, nullable: true),
                    SecondaryEmail = table.Column<string>(maxLength: 50, nullable: true),
                    FaxNumber = table.Column<string>(maxLength: 50, nullable: true),
                    GPSCoordinates = table.Column<string>(maxLength: 50, nullable: true),
                    CityName = table.Column<string>(nullable: true),
                    StateName = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_AddressType",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_RelatedTo",
                        column: x => x.RelatedToId,
                        principalTable: "RelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_State",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanCanChangeToXref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FromPlanMasterId = table.Column<int>(nullable: false),
                    ToPlanMasterId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanCanChangeToXref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberPlanCanChangeTo_PlanMaster",
                        column: x => x.FromPlanMasterId,
                        principalTable: "PlanMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberPlanCanChangeTo_PlanMaster2",
                        column: x => x.ToPlanMasterId,
                        principalTable: "PlanMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlanMasterId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    PlanFrequencyId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanDetail_Currency",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanDetail_PlanFrequency",
                        column: x => x.PlanFrequencyId,
                        principalTable: "PlanFrequency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanDetail_PlanMaster",
                        column: x => x.PlanMasterId,
                        principalTable: "PlanMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientPlanHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BillingUserId = table.Column<int>(nullable: false),
                    PlanDetailId = table.Column<int>(nullable: false),
                    IsCurrentPlan = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Notes = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPlanHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientPlanHistory_User",
                        column: x => x.BillingUserId,
                        principalTable: "ClientUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContactUsRelatedToId = table.Column<int>(nullable: true),
                    ActionedByUserId = table.Column<int>(nullable: true),
                    ClientEmail = table.Column<string>(maxLength: 50, nullable: false),
                    ClientName = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    ClientQuery = table.Column<string>(maxLength: 1500, nullable: false),
                    Response = table.Column<string>(maxLength: 1500, nullable: true),
                    isResolved = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactUs_ClientUser",
                        column: x => x.ActionedByUserId,
                        principalTable: "ClientUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactUs_ContactUsRelatedTo",
                        column: x => x.ContactUsRelatedToId,
                        principalTable: "ContactUsRelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleXRef",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleXRef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_User",
                        column: x => x.UserId,
                        principalTable: "ClientUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventUniqueName = table.Column<string>(maxLength: 20, nullable: false),
                    InternalOrExternal = table.Column<bool>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    OrganizerId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    TimeZoneId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time(2)", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time(2)", nullable: false),
                    RegStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RegEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RegStartTime = table.Column<TimeSpan>(type: "time(2)", nullable: false),
                    RegEndTime = table.Column<TimeSpan>(type: "time(2)", nullable: false),
                    MaxRegistrationsAllowed = table.Column<int>(nullable: false),
                    IsCPDEvent = table.Column<bool>(nullable: false),
                    IsChargableEvent = table.Column<bool>(nullable: false),
                    ShowMaxRegistrationsAllowed = table.Column<bool>(nullable: false),
                    AllowGuestRegistrations = table.Column<bool>(nullable: true),
                    GuestLimitPerRegistrant = table.Column<int>(nullable: true),
                    AllowCancellations = table.Column<bool>(nullable: false),
                    CancellationbeforeDays = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    AllowRegistration = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Event_User",
                        column: x => x.OrganizerId,
                        principalTable: "ClientUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Event_TimeZone",
                        column: x => x.TimeZoneId,
                        principalTable: "ClientTimeZone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventAccess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    AdminOnly = table.Column<bool>(nullable: true),
                    Anyone = table.Column<bool>(nullable: true),
                    RestrictedList = table.Column<bool>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventAccess_Event",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventCommunication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    Announcement1Sent = table.Column<bool>(nullable: true),
                    Announcement1SentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Announcement1ScheduledDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Announcement2Sent = table.Column<bool>(nullable: true),
                    Announcement2SentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Announcement2ScheduledDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Announcement3Sent = table.Column<bool>(nullable: true),
                    Announcement3SentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Announcement3ScheduledDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Reminder1Sent = table.Column<bool>(nullable: true),
                    Reminder1SentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Reminder1ScheduledDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Reminder2Sent = table.Column<bool>(nullable: true),
                    Reminder2SentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Reminder2ScheduledDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Reminder3Sent = table.Column<bool>(nullable: true),
                    Reminder3SentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Reminder3ScheduledDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCommunication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventCommunication_Event",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventCostItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCostItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventCostItem_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false),
                    RequiredCount = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventEquipmentRequirement_Equipment",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventEquipmentRequirement_Event",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventMinute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    Heading = table.Column<string>(maxLength: 50, nullable: true),
                    SubHeading = table.Column<string>(maxLength: 50, nullable: true),
                    Minute = table.Column<string>(maxLength: 100, nullable: false),
                    RaisedBy = table.Column<int>(nullable: false),
                    AssignedTo = table.Column<int>(nullable: false),
                    MinuteStatusId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventMinute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventMinute_Event",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventMinute_EventMinuteStatus",
                        column: x => x.MinuteStatusId,
                        principalTable: "EventMinuteStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventPreRequisiteEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    PreRequisiteEventId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPreRequisiteEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventPreRequisiteEvent_Event",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventPreRequisiteEvent_PreRequisiteEventId_Event",
                        column: x => x.PreRequisiteEventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventRestrictionList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    MemberLevelId = table.Column<int>(nullable: true),
                    MemberTeamId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRestrictionList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventRestrictionList_Event",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventRestrictionList_MemberLevel",
                        column: x => x.MemberLevelId,
                        principalTable: "MemberLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventRestrictionList_MemberTeam",
                        column: x => x.MemberTeamId,
                        principalTable: "MemberTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventRole_Event",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventCost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    EventCostItemId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10, 3)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventCost_EventCostItem_EventCostItemId",
                        column: x => x.EventCostItemId,
                        principalTable: "EventCostItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventCost_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRoleUserXRef",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    EventRoleId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRoleUserXRef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventRoleUserXRef_EventRole",
                        column: x => x.EventRoleId,
                        principalTable: "EventRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventRoleUserXRef_User",
                        column: x => x.UserId,
                        principalTable: "ClientUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberBankingDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    AccountTypeId = table.Column<int>(nullable: false),
                    BankName = table.Column<string>(maxLength: 50, nullable: true),
                    BranchName = table.Column<string>(maxLength: 100, nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: false),
                    RoutingCode = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberBankingDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberBankingDetail_AccountType",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: true),
                    BranchId = table.Column<int>(nullable: true),
                    AddressTypeId = table.Column<int>(nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(maxLength: 100, nullable: true),
                    BuidlingName = table.Column<string>(maxLength: 100, nullable: true),
                    ComplexName = table.Column<string>(maxLength: 100, nullable: true),
                    StreetName = table.Column<string>(maxLength: 100, nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(maxLength: 50, nullable: true),
                    PrimaryContactNo = table.Column<string>(maxLength: 50, nullable: true),
                    SecondaryContactNo = table.Column<string>(maxLength: 50, nullable: true),
                    PrimaryEmail = table.Column<string>(maxLength: 50, nullable: true),
                    SecondaryEmail = table.Column<string>(maxLength: 50, nullable: true),
                    FaxNumber = table.Column<string>(maxLength: 50, nullable: true),
                    GPSCoordinates = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberAddress_AddressType",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberAddress_MemberBranch",
                        column: x => x.BranchId,
                        principalTable: "MemberBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberAffliationXRef",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: true),
                    AffliationId = table.Column<int>(nullable: true),
                    MemberSpecificAffliationName = table.Column<string>(maxLength: 100, nullable: true),
                    MemberNumber = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    AffliatedFrom = table.Column<DateTime>(type: "datetime", nullable: true),
                    AffliatedTill = table.Column<DateTime>(type: "datetime", nullable: true),
                    isActiveAffliatedNow = table.Column<bool>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberAffliationXRef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberAffliationXRef_Affliation",
                        column: x => x.AffliationId,
                        principalTable: "Affliation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MembershipGradeId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    TransactionCurrencyid = table.Column<int>(nullable: true),
                    MemberStatusId = table.Column<int>(nullable: true),
                    MembershipTypeId = table.Column<int>(nullable: true),
                    MemberBranchId = table.Column<int>(nullable: true),
                    MemberLevelId = table.Column<int>(nullable: true),
                    ReferralTypeId = table.Column<int>(nullable: true),
                    ReferralOther = table.Column<string>(nullable: true),
                    MemberTeamId = table.Column<int>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: true),
                    OrganizationStructureId = table.Column<int>(nullable: true),
                    ApplicaitonUserId = table.Column<string>(maxLength: 50, nullable: true),
                    OwnerClientUserId = table.Column<int>(nullable: true),
                    ClientBranchId = table.Column<int>(nullable: true),
                    PreferredAppointmentTimeId = table.Column<int>(nullable: true),
                    HighestQualitificationId = table.Column<int>(nullable: true),
                    HomeLanguageId = table.Column<int>(nullable: true),
                    VolunteerWorkHoursId = table.Column<int>(nullable: true),
                    EthnicityId = table.Column<int>(nullable: true),
                    OccupationId = table.Column<int>(nullable: true),
                    ParentMemberid = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    TotalCDPPoints = table.Column<int>(nullable: true),
                    AccountBalanceOftheCompany = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
                    Accountbalanceofthecompany_base = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
                    AmountWrittenOff = table.Column<decimal>(nullable: true),
                    DateWrittenOff = table.Column<DateTime>(nullable: true),
                    Request1Debt = table.Column<DateTime>(nullable: true),
                    Request2Debt = table.Column<DateTime>(nullable: true),
                    Request3Debt = table.Column<DateTime>(nullable: true),
                    DebtPaymentReceived = table.Column<DateTime>(nullable: true),
                    MemberCode = table.Column<string>(maxLength: 100, nullable: true),
                    IDNumber = table.Column<string>(maxLength: 100, nullable: true),
                    PostCertificateTracking = table.Column<string>(maxLength: 100, nullable: true),
                    Initials = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: true),
                    FaxToEmail = table.Column<string>(maxLength: 100, nullable: true),
                    MobilePhone = table.Column<string>(maxLength: 100, nullable: true),
                    HomePhoneNumber = table.Column<string>(maxLength: 100, nullable: true),
                    BusinessPhoneNumber = table.Column<string>(maxLength: 100, nullable: true),
                    FAXNumber = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    SecondaryEmail = table.Column<string>(maxLength: 100, nullable: true),
                    Notes = table.Column<string>(type: "Text", nullable: true),
                    JobTitle = table.Column<string>(maxLength: 120, nullable: true),
                    ParentMemberName = table.Column<string>(maxLength: 100, nullable: true),
                    SpecialMember = table.Column<bool>(nullable: true),
                    AdminFee = table.Column<bool>(nullable: true),
                    IDAttached = table.Column<bool>(nullable: true),
                    ProofOfRegistrationAttached = table.Column<bool>(nullable: true),
                    QualificationAttached = table.Column<bool>(nullable: true),
                    DwscertificAteattached = table.Column<bool>(nullable: true),
                    ProofofPaymentReceived = table.Column<bool>(nullable: true),
                    InterestedInVolunteerWork = table.Column<bool>(nullable: true),
                    PublishCompanyInAnnualMemberDirectory = table.Column<bool>(nullable: true),
                    MembershipFeeInvoicedToCompany = table.Column<bool>(nullable: true),
                    ApplicationFormComplete = table.Column<bool>(nullable: true),
                    AdminfeeProofofpaymentSent = table.Column<bool>(nullable: true),
                    RefereeReport = table.Column<bool>(nullable: true),
                    TaxInvoiceSent = table.Column<bool>(nullable: true),
                    ProofOfPaymentUploaded = table.Column<bool>(nullable: true),
                    CertificateUploaded = table.Column<bool>(nullable: true),
                    FirstReminderSent = table.Column<bool>(nullable: true),
                    SecondReminderSent = table.Column<bool>(nullable: true),
                    ThirdReminderSent = table.Column<bool>(nullable: true),
                    New_Check = table.Column<bool>(nullable: true),
                    IsPrivate = table.Column<bool>(nullable: true),
                    InvoiceSent = table.Column<bool>(nullable: true),
                    isApplicationCompleted = table.Column<bool>(nullable: false),
                    TermAccepted = table.Column<bool>(nullable: false),
                    TotalCdppoints_State = table.Column<bool>(nullable: true),
                    DonotFax = table.Column<bool>(nullable: true),
                    DoNotSMS = table.Column<bool>(nullable: true),
                    DoNotEmail = table.Column<bool>(nullable: true),
                    DonotBulkPostalMail = table.Column<bool>(nullable: true),
                    DonotBulkEmail = table.Column<bool>(nullable: true),
                    DonotSendMassMarketing = table.Column<bool>(nullable: true),
                    DonotpostalMail = table.Column<bool>(nullable: true),
                    DonotPhone = table.Column<bool>(nullable: true),
                    FollowEmail = table.Column<bool>(nullable: true),
                    IsBillingContact = table.Column<bool>(nullable: true),
                    IsBranchContact = table.Column<bool>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    DwsProcessControllerRegistrationName = table.Column<string>(nullable: true),
                    ExistingMembershipId = table.Column<int>(nullable: true),
                    CompanyAddress = table.Column<string>(nullable: true),
                    VATNumber = table.Column<string>(nullable: true),
                    CompanyPhoneNumber2 = table.Column<string>(nullable: true),
                    EmployerAddress = table.Column<string>(nullable: true),
                    CompanyPostalCode = table.Column<string>(nullable: true),
                    IsDisabled = table.Column<bool>(nullable: true),
                    LastUsedInCampaignDate = table.Column<DateTime>(nullable: true),
                    TotalCdpPointsCalculatedDate = table.Column<DateTime>(nullable: true),
                    AdminFeeProofofpaymentReceivedDate = table.Column<DateTime>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    GradingCompletedDate = table.Column<DateTime>(nullable: true),
                    ProformaInvoiceEmailedDate = table.Column<DateTime>(nullable: true),
                    ProofofPaymentReceivedDate = table.Column<DateTime>(nullable: true),
                    TaxInvoicEemailedDate = table.Column<DateTime>(nullable: true),
                    PostingofCertificateDate = table.Column<DateTime>(nullable: true),
                    CertificateAndwelcomeLetterEmailedDate = table.Column<DateTime>(nullable: true),
                    SentforGradingDate = table.Column<DateTime>(nullable: true),
                    ProformaInvoiceSentDate = table.Column<DateTime>(nullable: true),
                    PaymentReminder1Date = table.Column<DateTime>(nullable: true),
                    PaymentReminder2Date = table.Column<DateTime>(nullable: true),
                    PaymentReminder3Date = table.Column<DateTime>(nullable: true),
                    CancelapplicationNopayDate = table.Column<DateTime>(nullable: true),
                    ApplicationreceivedDate = table.Column<DateTime>(nullable: true),
                    Request2MemberFee = table.Column<DateTime>(nullable: true),
                    Request3MemberFee = table.Column<DateTime>(nullable: true),
                    AdminfeePaymentReceivedDate = table.Column<DateTime>(nullable: true),
                    ApplicationCancelledMemberfeeNotpaidDate = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Photo = table.Column<byte[]>(type: "blob", nullable: true),
                    OrganizationName = table.Column<string>(nullable: true),
                    OriginalSystemRecordId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_ApplicationUser",
                        column: x => x.ApplicaitonUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_ClientBranch",
                        column: x => x.ClientBranchId,
                        principalTable: "ClientBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberUser_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_Ethnicity",
                        column: x => x.EthnicityId,
                        principalTable: "Ethnicity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_Qualification",
                        column: x => x.HighestQualitificationId,
                        principalTable: "Qualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_Language",
                        column: x => x.HomeLanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_MemberBranch",
                        column: x => x.MemberBranchId,
                        principalTable: "MemberBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_MemberLevel",
                        column: x => x.MemberLevelId,
                        principalTable: "MemberLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_MemberStatus",
                        column: x => x.MemberStatusId,
                        principalTable: "MemberStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_MemberTeam",
                        column: x => x.MemberTeamId,
                        principalTable: "MemberTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_MembershipGrade",
                        column: x => x.MembershipGradeId,
                        principalTable: "MembershipGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_MembershipType",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_Occupation",
                        column: x => x.OccupationId,
                        principalTable: "Occupation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_OrganizationStructure",
                        column: x => x.OrganizationStructureId,
                        principalTable: "OrganizationStructure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_OwnerClientUser",
                        column: x => x.OwnerClientUserId,
                        principalTable: "ClientUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_PreferredContactTime",
                        column: x => x.PreferredAppointmentTimeId,
                        principalTable: "PreferredContactTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_ReferralType",
                        column: x => x.ReferralTypeId,
                        principalTable: "ReferralType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_Currency",
                        column: x => x.TransactionCurrencyid,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_VolunteerHours",
                        column: x => x.VolunteerWorkHoursId,
                        principalTable: "VolunteerHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CPD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelatedToId = table.Column<int>(nullable: false),
                    RelatedRecordId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    CPDEarned = table.Column<int>(nullable: false),
                    CPDAwardedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPD_User",
                        column: x => x.CPDAwardedById,
                        principalTable: "ClientUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPD_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPD_RelatedTo",
                        column: x => x.RelatedToId,
                        principalTable: "RelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DisabilityMemberXref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: true),
                    DisabilityLevelId = table.Column<int>(nullable: true),
                    DisabilityId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabilityMemberXref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisabilityMemberXref_Disability",
                        column: x => x.DisabilityId,
                        principalTable: "Disability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisabilityMemberXref_DisabilityLevel",
                        column: x => x.DisabilityLevelId,
                        principalTable: "DisabilityLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisabilityMemberXref_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DivisionMemberXref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: true),
                    DivisonId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionMemberXref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DivisionMemberXref_Division",
                        column: x => x.DivisonId,
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DivisionMemberXref_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Donation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    PromotionDetailId = table.Column<int>(nullable: true),
                    DonatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    DonorNotes = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donation_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donation_PromotionDetail",
                        column: x => x.PromotionDetailId,
                        principalTable: "PromotionDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DWSClassMemberXref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: true),
                    DWSClassId = table.Column<int>(nullable: true),
                    ClassDate = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DWSClassMemberXref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DWSClassMemberXref_DWSClass",
                        column: x => x.DWSClassId,
                        principalTable: "DWSClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DWSClassMemberXref_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentMemberXref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Designation = table.Column<string>(maxLength: 120, nullable: true),
                    EmployerName = table.Column<string>(maxLength: 100, nullable: true),
                    CompanyTelephoneNumber = table.Column<string>(nullable: true),
                    CompanyEmail = table.Column<string>(nullable: true),
                    YourDuties = table.Column<string>(maxLength: 2500, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    MemberUserId = table.Column<int>(nullable: false),
                    EmploymentCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentMemberXref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmploymentMemberXref_EmploymentCategory",
                        column: x => x.EmploymentCategoryId,
                        principalTable: "EmploymentCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmploymentMemberXref_MemberUser",
                        column: x => x.MemberUserId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventAttendance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SignInTime = table.Column<TimeSpan>(nullable: false),
                    SingOutTime = table.Column<TimeSpan>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAttendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventAttendance_Event",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventAttendance_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventRegistration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    EventResponseTypeId = table.Column<int>(nullable: false),
                    Cancelled = table.Column<bool>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    NumberOfGuests = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRegistration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventRegistration_Event",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventRegistration_EventResponseType",
                        column: x => x.EventResponseTypeId,
                        principalTable: "EventResponseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventRegistration_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndividualMemberShipHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    MemberId = table.Column<int>(nullable: true),
                    MemberShipChangeReasonId = table.Column<int>(nullable: true),
                    MembershipTypeId = table.Column<int>(nullable: true),
                    MemberShipGradeId = table.Column<int>(nullable: true),
                    IsCurrentPlan = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Notes = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    MemberStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualMemberShipHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualMemberShipHistory_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualMemberShipHistory_MemberShipChangeReason",
                        column: x => x.MemberShipChangeReasonId,
                        principalTable: "MemberShipChangeReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualMemberShipHistory_MembershipGrade",
                        column: x => x.MemberShipGradeId,
                        principalTable: "MembershipGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualMemberShipHistory_MemberStatus_MemberStatusId",
                        column: x => x.MemberStatusId,
                        principalTable: "MemberStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualMemberShipHistory_MembershipType",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InvoiceCode = table.Column<string>(maxLength: 50, nullable: false),
                    RelatedToId = table.Column<int>(nullable: true),
                    RelatedRecordId = table.Column<int>(nullable: true),
                    MemberId = table.Column<int>(nullable: false),
                    InvoiceStatusId = table.Column<int>(nullable: false),
                    PaymentGatewayId = table.Column<int>(nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    InvoiceItem = table.Column<string>(maxLength: 200, nullable: false),
                    InvoiceAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CommentsForPayer = table.Column<string>(maxLength: 1000, nullable: true),
                    InternalNotes = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceStatus",
                        column: x => x.InvoiceStatusId,
                        principalTable: "InvoiceStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_PaymentGateway",
                        column: x => x.PaymentGatewayId,
                        principalTable: "PaymentGateway",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_RelatedTo",
                        column: x => x.RelatedToId,
                        principalTable: "RelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvolvementMemberXref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: true),
                    InvolvementId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvolvementMemberXref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvolvementMemberXref_Involvement",
                        column: x => x.InvolvementId,
                        principalTable: "Involvement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvolvementMemberXref_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarketingGroupXRef",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    MarketingGroupId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingGroupXRef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketingGroupXRef_MarketingGroup",
                        column: x => x.MarketingGroupId,
                        principalTable: "MarketingGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketingGroupXRef_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarketingProfileXRef",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    MarketingProfileId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingProfileXRef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketingProfileXRef_MarketingProfile",
                        column: x => x.MarketingProfileId,
                        principalTable: "MarketingProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketingProfileXRef_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberCommunicationPreference",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    CommunicationTypeId = table.Column<int>(nullable: false),
                    PreferredTimeFrom = table.Column<TimeSpan>(nullable: true),
                    PreferredTimeTo = table.Column<TimeSpan>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberCommunicationPreference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberCommunicationPreference_CommunicationType",
                        column: x => x.CommunicationTypeId,
                        principalTable: "CommunicationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberCommunicationPreference_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberFileXref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelatedEntityId = table.Column<int>(nullable: true),
                    RelatedToId = table.Column<int>(nullable: true),
                    FileTypeId = table.Column<int>(nullable: true),
                    FileName = table.Column<string>(maxLength: 1000, nullable: true),
                    Notes = table.Column<string>(type: "Text", nullable: true),
                    Subject = table.Column<string>(maxLength: 1000, nullable: true),
                    FileExtension = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    MemberUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberFileXref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberFileXref_FileType",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberFileXref_MemberUser_MemberUserId",
                        column: x => x.MemberUserId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberFileXref_RelatedTo",
                        column: x => x.RelatedToId,
                        principalTable: "RelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberQualificationXRef",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberSpecificQualificationName = table.Column<string>(maxLength: 100, nullable: true),
                    StudentNumber = table.Column<string>(maxLength: 200, nullable: true),
                    InstituteName = table.Column<string>(nullable: true),
                    QualificationFrom = table.Column<DateTime>(type: "datetime", nullable: true),
                    QualificationTill = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    MemberId = table.Column<int>(nullable: false),
                    QualificationCategoryId = table.Column<int>(nullable: true),
                    QualificationTypeId = table.Column<int>(nullable: true),
                    QualificationEnrolmentCategoryId = table.Column<int>(nullable: true),
                    QualificationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberQualificationXRef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberQualificationXRef_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberQualificationXRef_QualificationCategory",
                        column: x => x.QualificationCategoryId,
                        principalTable: "QualificationCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberQualificationXRef_QualificationEnrolmentCategory",
                        column: x => x.QualificationEnrolmentCategoryId,
                        principalTable: "QualificationEnrolmentCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberQualificationXRef_Qualification_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberQualificationXRef_QualificationType",
                        column: x => x.QualificationTypeId,
                        principalTable: "QualificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    SecondaryPhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    ShortName = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    WebSite = table.Column<string>(maxLength: 100, nullable: true),
                    TaxNumber = table.Column<string>(maxLength: 50, nullable: true),
                    RegistrationNumber = table.Column<string>(maxLength: 100, nullable: true),
                    OrgMemberCode = table.Column<string>(maxLength: 20, nullable: true),
                    MemberStatusId = table.Column<int>(nullable: true),
                    MemberLevelId = table.Column<int>(nullable: true),
                    OrganizationGradeId = table.Column<int>(nullable: true),
                    OrganizationTypeId = table.Column<int>(nullable: true),
                    TransactionCurrencyid = table.Column<int>(nullable: true),
                    PrimaryContactId = table.Column<int>(nullable: true),
                    ContactPersonId = table.Column<int>(nullable: true),
                    BillingContactId = table.Column<int>(nullable: true),
                    ClientBranchId = table.Column<int>(nullable: true),
                    AccountBalance = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
                    IsTermAccepted = table.Column<bool>(nullable: false),
                    IsInvoiceSent = table.Column<bool>(nullable: true),
                    IsMembershipFeeInvoicedToCompany = table.Column<bool>(nullable: true),
                    PublishCompanyInAnnualMemberDirectory = table.Column<bool>(nullable: true),
                    AmountWrittenOff = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
                    DatetWrittenOff = table.Column<DateTime>(nullable: true),
                    ApplicationReceivedDate = table.Column<DateTime>(nullable: true),
                    IsApplicationFormComplete = table.Column<bool>(nullable: true),
                    ProformaInvoiceEmailedDate = table.Column<DateTime>(nullable: true),
                    ProofOfpaymentReceivedandUploaded = table.Column<bool>(nullable: true),
                    PaymentReminder1Date = table.Column<DateTime>(nullable: true),
                    PaymentReminder2Date = table.Column<DateTime>(nullable: true),
                    PaymentReminder3Date = table.Column<DateTime>(nullable: true),
                    CancelapplicationNopayDate = table.Column<DateTime>(nullable: true),
                    SentforGradingDate = table.Column<DateTime>(nullable: true),
                    GradingCompletedDate = table.Column<DateTime>(nullable: true),
                    TaxInvoicEmailedDate = table.Column<DateTime>(nullable: true),
                    ProofofPaymentReceivedDate = table.Column<DateTime>(nullable: true),
                    Request2MemberFee = table.Column<DateTime>(nullable: true),
                    Request3MemberFee = table.Column<DateTime>(nullable: true),
                    ApplicationCancelledMemberfeeNotpaidDate = table.Column<DateTime>(nullable: true),
                    CertificateAndwelcomeLetterEmailedDate = table.Column<DateTime>(nullable: true),
                    IsCertificateUploaded = table.Column<bool>(nullable: true),
                    OwnerClientUserId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsCreditOnHold = table.Column<bool>(nullable: true),
                    AccountBalanceBase = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
                    IsmemberFeePaid = table.Column<bool>(nullable: true),
                    IsCertificatePosted = table.Column<bool>(nullable: true),
                    IsMemberfeeProofofpaymentSent = table.Column<bool>(nullable: true),
                    MemberfeePaymentReceivedDate = table.Column<DateTime>(nullable: true),
                    PostingofCertificateDate = table.Column<DateTime>(nullable: true),
                    AmountDueAsAtDate = table.Column<DateTime>(nullable: true),
                    PostCertificateTracking = table.Column<string>(maxLength: 100, nullable: true),
                    IsAdminFeePaid = table.Column<bool>(nullable: true),
                    IsAdminfeeProofofpaymentSent = table.Column<bool>(nullable: true),
                    AdminfeePaymentReceivedDate = table.Column<DateTime>(nullable: true),
                    OriginalSystemRecordId = table.Column<string>(maxLength: 50, nullable: true),
                    PrimaryContactName = table.Column<string>(nullable: true),
                    ContactPersonName = table.Column<string>(nullable: true),
                    BusinessId = table.Column<int>(nullable: true),
                    MemberShipGradeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_BillingContact",
                        column: x => x.BillingContactId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organization_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organization_ClientBranch",
                        column: x => x.ClientBranchId,
                        principalTable: "ClientBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organization_ContactPerson",
                        column: x => x.ContactPersonId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organization_MemberLevel",
                        column: x => x.MemberLevelId,
                        principalTable: "MemberLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organization_MembershipGrade_MemberShipGradeId",
                        column: x => x.MemberShipGradeId,
                        principalTable: "MembershipGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organization_MemberStatus",
                        column: x => x.MemberStatusId,
                        principalTable: "MemberStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organization_OrganizationGrade",
                        column: x => x.OrganizationGradeId,
                        principalTable: "OrganizationGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organization_OrganizationType",
                        column: x => x.OrganizationTypeId,
                        principalTable: "OrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organization_PrimaryContact",
                        column: x => x.PrimaryContactId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organization_Currency",
                        column: x => x.TransactionCurrencyid,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PromotionResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PromotionMasterId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    PromotionResponseType = table.Column<int>(nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionResponse_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PromotionResponse_PromotionMaster",
                        column: x => x.PromotionMasterId,
                        principalTable: "PromotionMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PromotionResponse_PromotionResponseType",
                        column: x => x.PromotionResponseType,
                        principalTable: "PromotionResponseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Refund",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InvoiceId = table.Column<int>(nullable: true),
                    MemberId = table.Column<int>(nullable: false),
                    PaymentGatewayId = table.Column<int>(nullable: false),
                    RelatedToId = table.Column<int>(nullable: true),
                    RelatedRecordId = table.Column<int>(nullable: true),
                    RefundDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RefundItem = table.Column<string>(maxLength: 200, nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CommentsForPayer = table.Column<string>(maxLength: 1000, nullable: true),
                    InternalNotes = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refund", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refund_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Refund_PaymentGateway",
                        column: x => x.PaymentGatewayId,
                        principalTable: "PaymentGateway",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Refund_RelatedTo",
                        column: x => x.RelatedToId,
                        principalTable: "RelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Billing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InvoiceId = table.Column<int>(nullable: true),
                    MemberId = table.Column<int>(nullable: false),
                    RelatedToId = table.Column<int>(nullable: false),
                    RelatedRecordId = table.Column<int>(nullable: false),
                    PaymentGatewayId = table.Column<int>(nullable: false),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaidDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaymentItem = table.Column<string>(maxLength: 200, nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
                    CommentsForPayer = table.Column<string>(maxLength: 1000, nullable: true),
                    InternalNotes = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Invoice",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_PaymentGateway",
                        column: x => x.PaymentGatewayId,
                        principalTable: "PaymentGateway",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Billing_RelatedTo",
                        column: x => x.RelatedToId,
                        principalTable: "RelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberPlanHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: true),
                    MemberPlanDetailId = table.Column<int>(nullable: false),
                    IsCurrentPlan = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Notes = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberPlanHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembershipHistory_Member",
                        column: x => x.MemberId,
                        principalTable: "MemberUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberPlanHistory_PlanDetail",
                        column: x => x.MemberPlanDetailId,
                        principalTable: "PlanDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembershipHistory_PlanMaster",
                        column: x => x.MemberPlanDetailId,
                        principalTable: "PlanMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembershipHistory_Organization",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationBusinessXref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: true),
                    BusinessId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationBusinessXref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationBusinessXref_Business",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationBusinessXref_Organization",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationMemberShipHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    MemberShipChangeReasonId = table.Column<int>(nullable: true),
                    OrganizationTypeId = table.Column<int>(nullable: true),
                    OrganizationGradeId = table.Column<int>(nullable: true),
                    IsCurrentPlan = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Notes = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    MemberStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationMemberShipHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationMemberShipHistory_MemberShipChangeReason",
                        column: x => x.MemberShipChangeReasonId,
                        principalTable: "MemberShipChangeReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationMemberShipHistory_MemberStatus_MemberStatusId",
                        column: x => x.MemberStatusId,
                        principalTable: "MemberStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationMemberShipHistory_OrganizationGrade",
                        column: x => x.OrganizationGradeId,
                        principalTable: "OrganizationGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationMemberShipHistory_Organization",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationMemberShipHistory_OrganizationType",
                        column: x => x.OrganizationTypeId,
                        principalTable: "OrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillingCommunication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BillingId = table.Column<int>(nullable: false),
                    Reminder1Sent = table.Column<bool>(nullable: true),
                    Reminder1SentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Reminder1ScheduledDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Reminder2Sent = table.Column<bool>(nullable: true),
                    Reminder2SentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Reminder2ScheduledDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Reminder3Sent = table.Column<bool>(nullable: true),
                    Reminder3SentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Reminder3ScheduledDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingCommunication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentCommunication_Payment",
                        column: x => x.Id,
                        principalTable: "Billing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AccountType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Savings Account" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cheque Account" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate Account" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Business Account" }
                });

            migrationBuilder.InsertData(
                table: "AddressType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Venue" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipping Address" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Business Address" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contact Address" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Physical Address" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Postal Address" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Billing Address" }
                });

            migrationBuilder.InsertData(
                table: "Affliation",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ECSA" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "IMESA" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "IWA" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SACNASP" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAICE" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other" }
                });

            migrationBuilder.InsertData(
                table: "Business",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Water /Waste Water Management", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Water /Waste Water Management" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Industrial Mine Waer Management", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Industrial Mine Waer Management" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Water Infrastructure", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Water Infrastructure" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Research and Development", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Research and Development" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laboratory Services", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laboratory Services" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Groundwater Management", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Groundwater Management" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consultants", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consultants" }
                });

            migrationBuilder.InsertData(
                table: "ClientBranch",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 9, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Namibia" },
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "International" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eastern Cape" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Regions" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mpumalanga" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "KwaZulu Natal" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limpopo" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gauteng" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western Cape" }
                });

            migrationBuilder.InsertData(
                table: "ClientOrganizationGrade",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 11, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Club - Special Interest or Social", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Club - Special Interest or Social" },
                    { 18, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Support / Assistance Services", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Support / Assistance Services" },
                    { 17, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Subscription Site", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Subscription Site" },
                    { 15, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other(blank template)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other(blank template)" },
                    { 14, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Foundation or Charity", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Foundation or Charity" },
                    { 13, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event / Conference", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event / Conference" },
                    { 12, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), " COVID - 19", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), " COVID - 19" },
                    { 10, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Club - Service", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Club - Service" },
                    { 16, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Political / Advocacy", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Political / Advocacy" },
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Teachers", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Teachers" },
                    { 9, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Church or Religious Community", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Church or Religious Community" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Chamber of commerce", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Chamber of commerce" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Community / HOA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Community / HOA" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Business / Trade", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Business / Trade" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Health", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Health" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Business / Trade", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Business / Trade" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Student/Alumni/PTA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Student/Alumni/PTA" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Professional", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Professional" }
                });

            migrationBuilder.InsertData(
                table: "ClientTimeZone",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 69, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+10:00) Hobart", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tasmania Standard Time" },
                    { 62, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+09:00) Seoul", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Korea Standard Time" },
                    { 68, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+10:00) Brisbane", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "E. Australia Standard Time" },
                    { 67, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+10:00) Canberra, Melbourne, Sydney", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.U.S. Eastern Standard Time" },
                    { 66, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+09:30) AdelaIde", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cen. Australia Standard Time" },
                    { 65, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+09:30) Darwin", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.U.S. Central Standard Time" },
                    { 64, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+09:00) Yakutsk", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yakutsk Standard Time" },
                    { 63, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+09:00) Osaka, Sapporo, Tokyo", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tokyo Standard Time" },
                    { 61, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+08:00) Irkutsk, Ulaanbaatar", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Asia East Standard Time" },
                    { 57, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+08:00) Beijing, Chongqing, Hong Kong, Urumqi", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "China Standard Time" },
                    { 59, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+08:00) Taipei", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taipei Standard Time" },
                    { 58, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+08:00) Kuala Lumpur, Singapore", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore Standard Time" },
                    { 70, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+10:00) Vladivostok", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vladivostok Standard Time" },
                    { 56, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+07:00) Krasnoyarsk", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Asia Standard Time" },
                    { 55, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+07:00) Bangkok, Hanoi, Jakarta", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.E. Asia Standard Time" },
                    { 54, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+06:30) Yangon (Rangoon)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Myanmar Standard Time" },
                    { 53, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+06:00) Almaty, Novosibirsk", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "N. Central Asia Standard Time" },
                    { 52, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+06:00) Sri Jayawardenepura", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sri Lanka Standard Time" },
                    { 51, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+06:00) Astana, Dhaka", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Asia Standard Time" },
                    { 50, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+05:45) Kathmandu", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nepal Standard Time" },
                    { 60, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+08:00) Perth", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "W. Australia Standard Time" },
                    { 71, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+10:00) Guam, Port Moresby", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Pacific Standard Time" },
                    { 75, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+13:00) Nuku'alofa", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tonga Standard Time" },
                    { 73, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+12:00) Fiji, Kamchatka, Marshall Is.", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fiji Islands Standard Time" },
                    { 49, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+05:30) Chennai, Kolkata, Mumbai, New Delhi", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "India Standard Time" },
                    { 94, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+12:00) Petropavlovsk-Kamchatsky", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kamchatka Standard Time" },
                    { 92, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT) Coordinated Universal Time", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "UTC" },
                    { 91, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+04:00) Port Louis", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritius Standard Time" },
                    { 90, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+05:00) Islamabad, Karachi", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pakistan Standard Time" },
                    { 89, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT) Casablanca", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morocco Standard Time" },
                    { 88, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-03:00) Buenos Aires", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Argentina Standard Time" },
                    { 87, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-04:30) Caracas", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Venezuela Standard Time" },
                    { 86, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+04:00) Yerevan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Armenian Standard Time" },
                    { 72, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+11:00) Magadan, Solomon Islands, New Caledonia", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Pacific Standard Time" },
                    { 85, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-03:00) MontevIdeo", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MontevIdeo Standard Time" },
                    { 83, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+03:00) Tbilisi", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgian Standard Time" },
                    { 82, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+02:00) Windhoek", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Namibia Standard Time" },
                    { 81, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-08:00) Tijuana, Baja California", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pacific Standard Time (Mexico)" },
                    { 80, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-07:00) Chihuahua, La Paz, Mazatlan - New", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain Standard Time (Mexico)" },
                    { 79, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-06:00) Guadalajara, Mexico City, Monterrey - New", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Standard Time (Mexico)" },
                    { 78, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+02:00) Amman", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordan Standard Time" },
                    { 77, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+02:00) Beirut", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MIddle East Standard Time" },
                    { 76, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-03:00) Buenos Aires", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azerbaijan Standard Time " },
                    { 74, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+12:00) Auckland, Wellington", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealand Standard Time" },
                    { 84, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-04:00) Manaus", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Brazilian Standard Time" },
                    { 48, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+05:00) Tashkent", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Asia Standard Time" },
                    { 93, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-04:00) Asuncion", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paraguay Standard Time" },
                    { 46, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+04:30) Kabul", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transitional Islamic State of Afghanistan Standard Time" },
                    { 20, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-03:00) Brasilia", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "E. South America Standard Time" },
                    { 19, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-03:30) Newfoundland", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Newfoundland and Labrador Standard Time" },
                    { 18, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-04:00) Santiago", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pacific S.A. Standard Time" },
                    { 17, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-04:00) Georgetown, La Paz, San Juan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.A. Western Standard Time" },
                    { 16, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-04:00) Atlantic Time (Canada)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Atlantic Standard Time" },
                    { 15, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-05:00) Bogota, Lima, Quito", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.A. Pacific Standard Time" },
                    { 14, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-05:00) Indiana (East)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "U.S. Eastern Standard Time" },
                    { 13, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-05:00) Eastern Time (US and Canada)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eastern Standard Time" },
                    { 12, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-06:00) Central America", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central America Standard Time" },
                    { 21, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-03:00) Georgetown", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.A. Eastern Standard Time" },
                    { 11, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-06:00) Guadalajara, Mexico City, Monterrey", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico Standard Time" },
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-07:00) Arizona", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "U.S. Mountain Standard Time" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-07:00) Chihuahua, La Paz, Mazatlan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico Standard Time 2" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-07:00) Mountain Time (US and Canada)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain Standard Time" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-08:00) Pacific Time (US and Canada); Tijuana", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pacific Standard Time" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-09:00) Alaska", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alaskan Standard Time" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-10:00) Hawaii", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hawaiian Standard Time" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-11:00) MIdway Island, Samoa", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samoa Standard Time" },
                    { 47, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+05:00) Ekaterinburg", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ekaterinburg Standard Time" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-12:00) International Date Line West", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dateline Standard Time" },
                    { 10, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-06:00) Saskatchewan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canada Central Standard Time" },
                    { 22, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-03:00) Greenland", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greenland Standard Time" },
                    { 9, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-06:00) Central Time (US and Canada)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Standard Time" },
                    { 24, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-01:00) Azores", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azores Standard Time" },
                    { 45, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+04:00) Baku, Tbilisi, Yerevan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caucasus Standard Time" },
                    { 44, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+04:00) Abu Dhabi, Muscat", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arabian Standard Time" },
                    { 43, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+03:30) Tehran", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iran Standard Time" },
                    { 42, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+03:00) Baghdad", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arabic Standard Time" },
                    { 41, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+03:00) Nairobi", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "E. Africa Standard Time" },
                    { 40, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+03:00) Kuwait, Riyadh", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arab Standard Time" },
                    { 39, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+03:00) Moscow, St. Petersburg, Volgograd", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Russian Standard Time" },
                    { 38, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+02:00) Harare, Pretoria", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Africa Standard Time" },
                    { 37, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+02:00) Jerusalem", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Israel Standard Time" },
                    { 35, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+02:00) Helsinki, Kiev, Riga, Sofia, Tallinn, Vilnius", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FLE Standard Time" },
                    { 36, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+02:00) Athens, Bucharest, Istanbul", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GTB Standard Time" },
                    { 33, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+02:00) Minsk", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "E. Europe Standard Time" },
                    { 32, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+01:00) West Central Africa", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "W. Central Africa Standard Time" },
                    { 31, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "W. Europe Standard Time" },
                    { 30, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+01:00) Brussels, Copenhagen, MadrId, Paris", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romance Standard Time" },
                    { 29, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+01:00) Sarajevo, Skopje, Warsaw, Zagreb", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central European Standard Time" },
                    { 28, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Europe Standard Time" },
                    { 27, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT) Monrovia, Reykjavik", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greenwich Standard Time" },
                    { 26, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT) Greenwich Mean Time: Dublin, Edinburgh, Lisbon, London", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GMT Standard Time" },
                    { 25, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-01:00) Cape Verde Islands", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cape Verde Standard Time" },
                    { 34, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT+02:00) Cairo", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egypt Standard Time" },
                    { 23, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "(GMT-02:00) MId-Atlantic", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MId-Atlantic Standard Time" }
                });

            migrationBuilder.InsertData(
                table: "CommunicationType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Postal Letter", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Preferences", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Any" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Text Message", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SMS" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile / Phone Call", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phone" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Email Message", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Email" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fax Message", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fax" }
                });

            migrationBuilder.InsertData(
                table: "ContactUsRelatedTo",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membership" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Events" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Registration" }
                });

            migrationBuilder.InsertData(
                table: "CorrespondenceType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internal Correspondance", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internal" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "External Correspondance", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "External" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sales Correspondance", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sales" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reminders, Statements Invoices to Members", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Common messages", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Circular" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Private Messages", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confidential" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 176, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paraguayan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paraguay" },
                    { 175, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Papua New Guinean", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Papua New Guinea" },
                    { 174, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panamanian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panama" },
                    { 173, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palestine", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palestine" },
                    { 172, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palau", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palau" },
                    { 166, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norfolk Island", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norfolk Island" },
                    { 170, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omani", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oman" },
                    { 169, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norwegian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway" },
                    { 168, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Northern Mariana Islands", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Northern Mariana Islands" },
                    { 167, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Korean", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Korea" },
                    { 177, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peruvian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peru" },
                    { 171, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pakistani", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pakistan" },
                    { 178, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pitcairn", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pitcairn" },
                    { 193, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Vincent and the Grenadines", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Vincent and the Grenadines" },
                    { 180, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portuguese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portugal" },
                    { 181, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Puerto Rico", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Puerto Rico" },
                    { 182, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qatari", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qatar" },
                    { 183, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Réunion", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Réunion" },
                    { 184, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romanian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romania" },
                    { 185, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Russian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Russia" },
                    { 186, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rwandan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rwanda" },
                    { 187, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Barthélemy", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Barthélemy" },
                    { 188, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Helena", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Helena" },
                    { 189, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Kitts and Nevis", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Kitts and Nevis" },
                    { 190, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Lucia", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Lucia" },
                    { 191, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Martin (French part)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Martin (French part)" },
                    { 192, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Pierre and Miquelon", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Pierre and Miquelon" },
                    { 165, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niue", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niue" },
                    { 179, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Polish", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poland" },
                    { 164, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nigerian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nigeria" },
                    { 134, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macao", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macao" },
                    { 162, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicaraguan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicaragua" },
                    { 133, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luxembourger", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luxembourg" },
                    { 194, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samoa", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samoa" },
                    { 135, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macedonian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macedonia" },
                    { 136, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madagascan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madagascar" },
                    { 137, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malawian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malawi" },
                    { 138, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malaysian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malaysia" },
                    { 139, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maldivian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maldives" },
                    { 140, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mali" },
                    { 141, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maltese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta" },
                    { 142, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marshall Islands", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marshall Islands" },
                    { 143, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martinique", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martinique" },
                    { 144, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritanian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritania" },
                    { 145, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritius" },
                    { 146, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mayotte", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mayotte" },
                    { 147, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexican", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico" },
                    { 148, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Micronesia", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Micronesia" },
                    { 149, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moldovan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moldova" },
                    { 150, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monacan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monaco" },
                    { 151, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mongolian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mongolia" },
                    { 152, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montenegrin", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montenegro" },
                    { 153, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montserrat", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montserrat" },
                    { 154, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moroccan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morocco" },
                    { 155, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mozambican", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mozambique" },
                    { 156, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burmese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Myanmar" },
                    { 157, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nauru", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nauru" },
                    { 158, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nepalese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nepal" },
                    { 159, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dutch", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Netherlands" },
                    { 160, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Caledonia", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Caledonia" },
                    { 161, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealander", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealand" },
                    { 163, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nigerien", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niger" },
                    { 195, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Marino", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Marino" },
                    { 226, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Timor-Leste", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Timor-Leste" },
                    { 197, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saudi Arabian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saudi Arabia" },
                    { 232, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkish", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkey" },
                    { 233, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkmen or Turkoman", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkmenistan" },
                    { 234, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turks and Caicos Islands", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turks and Caicos Islands" },
                    { 235, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuvaluan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuvalu" },
                    { 236, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ugandan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uganda" },
                    { 237, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ukrainian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ukraine" },
                    { 238, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emirati", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Arab Emirates" },
                    { 239, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Briton", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" },
                    { 240, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States Minor Outlying Islands", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States Minor Outlying Islands" },
                    { 241, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US citizen", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States of America" },
                    { 242, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uruguayan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uruguay" },
                    { 243, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzbek", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzbekistan" },
                    { 244, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vanuatuan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vanuatu" },
                    { 231, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tunisian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tunisia" },
                    { 245, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vatican", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vatican City" },
                    { 247, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vietnamese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "VietNam" },
                    { 248, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virgin Islands -U.S.", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virgin Islands -U.S." },
                    { 249, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virgin Islands-British", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virgin Islands-British" },
                    { 250, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welsh", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wales" },
                    { 251, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wallis and Futuna", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wallis and Futuna" },
                    { 252, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western Sahara", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western Sahara" },
                    { 253, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western Samoan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western Samoa" },
                    { 254, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yemeni", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yemen" },
                    { 255, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yugoslav", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yugoslavia" },
                    { 256, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zaïrean", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zaire" },
                    { 257, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zambian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zambia" },
                    { 258, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zimbabwean", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zimbabwe" },
                    { 132, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lithuanian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lithuania" },
                    { 246, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Venezuelan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Venezuela" },
                    { 230, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trinidadian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trinidad and Tobago" },
                    { 229, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tonga", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tonga" },
                    { 228, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tokelau", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tokelau" },
                    { 198, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scottish", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scotland" },
                    { 199, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senegalese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senegal" },
                    { 200, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serb or Serbian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serbia" },
                    { 201, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seychellois", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seychelles" },
                    { 202, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sierra Leonian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sierra Leone" },
                    { 203, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singaporean", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore" },
                    { 204, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sint Maarten (Dutch part)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sint Maarten (Dutch part)" },
                    { 205, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovak", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovakia" },
                    { 206, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovenian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovenia" },
                    { 207, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solomon Islander", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solomon Islands" },
                    { 208, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Somali", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Somalia" },
                    { 209, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Georgia and the South Sandwich Islands", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Georgia and the South Sandwich Islands" },
                    { 210, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Korean", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Korea" },
                    { 211, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Sudan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Sudan" },
                    { 212, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spanish", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain" },
                    { 213, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sri Lankan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sri Lanka" },
                    { 214, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sudanese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sudan" },
                    { 215, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surinamese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suriname" },
                    { 216, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Svalbard and Jan Mayen", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Svalbard and Jan Mayen" },
                    { 217, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swazi", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SWAZILAND" },
                    { 218, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swedish", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweden" },
                    { 219, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swiss", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Switzerland" },
                    { 220, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Syrian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Syria" },
                    { 221, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taiwanese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taiwan" },
                    { 222, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tajik or Tadjik", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tajikistan" },
                    { 223, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tanzanian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tanzania" },
                    { 224, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thai", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thailand" },
                    { 225, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Philippine", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Philippines" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 227, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Togolese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Togo" },
                    { 196, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sao Tome and Principe", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sao Tome and Principe" },
                    { 131, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liechtensteiner", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liechtenstein" },
                    { 115, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamaican", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamaica" },
                    { 129, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liberian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liberia" },
                    { 34, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brazilian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brazil" },
                    { 35, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "British Indian Ocean Territory", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "British Indian Ocean Territory" },
                    { 36, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bruneian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brunei" },
                    { 37, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bulgarian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bulgaria" },
                    { 38, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burkinese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burkina Faso" },
                    { 39, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burundian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burundi" },
                    { 40, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cambodian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cambodia" },
                    { 41, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cameroonian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cameroon" },
                    { 42, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canadian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canada" },
                    { 43, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cape Verdean", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cape Verde Islands" },
                    { 44, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cayman Islands", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cayman Islands" },
                    { 45, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central African Republic", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central African Republic" },
                    { 46, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chadian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chad" },
                    { 32, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botswanan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botswana" },
                    { 47, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chilean", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chile" },
                    { 49, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas Island", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas Island" },
                    { 50, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cocos (Keeling) Islands", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cocos (Keeling) Islands" },
                    { 51, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colombian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colombia" },
                    { 52, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comoros", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comoros" },
                    { 53, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Congolese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Congo" },
                    { 55, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cook Islands", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cook Islands" },
                    { 56, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Costa Rican", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Costa Rica" },
                    { 57, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Côte d'Ivoire", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Côte d'Ivoire" },
                    { 58, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Croatian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Croatia" },
                    { 59, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cuban", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cuba" },
                    { 60, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Curaçao", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Curaçao" },
                    { 61, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cypriot", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyprus" },
                    { 62, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Czech", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Czech Republic" },
                    { 48, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chinese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "China" },
                    { 31, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bosnian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bosnia-Herzegovina" },
                    { 30, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bonaire", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bonaire" },
                    { 29, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bolivian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bolivia" },
                    { 130, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Libyan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Libya" },
                    { 1, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "South African", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Africa" },
                    { 2, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Namibian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Namibia" },
                    { 3, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afghan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afghanistan" },
                    { 4, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Åland Islands", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Åland Islands" },
                    { 5, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Albanian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Albania" },
                    { 6, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Algerian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Algeria" },
                    { 7, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "American Samoa", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "American Samoa" },
                    { 8, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andorran", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andorra" },
                    { 9, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angolan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angola" },
                    { 10, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anguilla", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anguilla" },
                    { 11, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antarctica", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antarctica" },
                    { 12, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antigua and Barbuda", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antigua and Barbuda" },
                    { 13, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Argentinian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Argentina" },
                    { 14, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Armenian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Armenia" },
                    { 15, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aruba", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aruba" },
                    { 16, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia" },
                    { 17, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Austrian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Austria" },
                    { 18, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azerbaijani", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azerbaijan" },
                    { 19, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahamian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahamas" },
                    { 20, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahraini", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahrain" },
                    { 21, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bangladeshi", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bangladesh" },
                    { 22, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barbadian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barbados" },
                    { 23, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belarusan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belarus" },
                    { 24, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belgian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belgium" },
                    { 25, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belizean", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belize" },
                    { 26, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beninese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benin" },
                    { 27, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bermuda", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bermuda" },
                    { 28, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bhutanese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bhutan" },
                    { 63, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danish", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denmark" },
                    { 64, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Djiboutian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Djibouti" },
                    { 33, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bouvet Island", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bouvet Island" },
                    { 66, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominican", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominican Republic" },
                    { 99, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guyanese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guyana" },
                    { 100, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haitian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haiti" },
                    { 101, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heard Island and McDonald Islands", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heard Island and McDonald Islands" },
                    { 102, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Holy See", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Holy See" },
                    { 103, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honduran", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honduras" },
                    { 104, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong" },
                    { 105, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hungarian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hungary" },
                    { 106, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Icelandic", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iceland" },
                    { 107, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "India" },
                    { 108, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indonesian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indonesia" },
                    { 109, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iranian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iran" },
                    { 110, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iraqi", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iraq" },
                    { 112, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isle of Man", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isle of Man" },
                    { 113, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Israel", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Israel" },
                    { 114, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy" },
                    { 116, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japanese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japan" },
                    { 117, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jersey", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jersey" },
                    { 118, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordanian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordan" },
                    { 119, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kazakh", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kazakhstan" },
                    { 120, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kenyan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kenya" },
                    { 121, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiribati", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiribati" },
                    { 122, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuwaiti", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuwait" },
                    { 123, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyrgyzstan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyrgyzstan" },
                    { 124, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lao People's Democratic Republic", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lao People's Democratic Republic" },
                    { 125, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laotian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laos" },
                    { 126, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Latvian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Latvia" },
                    { 127, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lebanese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lebanon" },
                    { 65, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominican", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominica" },
                    { 128, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lesotho", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lesotho" },
                    { 98, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guinea-Bissau", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guinea-Bissau" },
                    { 97, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guinean", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guinea" },
                    { 111, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Irish", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ireland" },
                    { 68, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egyptian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egypt" },
                    { 67, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ecuadorean", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ecuador" },
                    { 96, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guernsey", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guernsey" },
                    { 69, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egyptian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egypt" },
                    { 70, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salvadorean", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "El Salvador" },
                    { 71, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Equatorial Guinea", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Equatorial Guinea" },
                    { 72, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eritrean", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eritrea" },
                    { 73, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estonian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estonia" },
                    { 74, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eswatini", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eswatini" },
                    { 75, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethiopian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethiopia" },
                    { 76, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Falkland Islands", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Falkland Islands [Malvinas]" },
                    { 78, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fijian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fiji" },
                    { 79, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finnish", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finland" },
                    { 80, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "French", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "France" },
                    { 81, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Guiana", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Guiana" },
                    { 77, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faroe Islands", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faroe Islands" },
                    { 83, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Southern Territories", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Southern Territories" },
                    { 95, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guatemalan", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guatemala" },
                    { 94, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guam", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guam" },
                    { 82, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Polynesia", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Polynesia" },
                    { 92, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grenadian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grenada" },
                    { 91, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greenland", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greenland" },
                    { 90, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greek", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece" },
                    { 89, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gibraltar", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gibraltar" },
                    { 93, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guadeloupe", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guadeloupe" },
                    { 87, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "German", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Germany" },
                    { 86, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgia" },
                    { 85, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gambian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gambia" },
                    { 84, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabonese", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabon" },
                    { 88, null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghanaian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghana" }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name", "Symbol" },
                values: new object[,]
                {
                    { 179, "PAB", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "PANAMA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Balboa", " " },
                    { 178, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "PALAU", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 177, "PKR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "PAKISTAN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pakistan Rupee", " " },
                    { 176, "OMR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "OMAN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rial Omani", " " },
                    { 175, "NOK", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NORWAY", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norwegian Krone", " " },
                    { 174, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NORTHERN MARIANA ISLANDS (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 172, "NZD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NIUE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealand Dollar", " " },
                    { 171, "NGN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NIGERIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Naira", " " },
                    { 170, "XOF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NIGER (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 169, "NIO", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NICARAGUA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cordoba Oro", " " },
                    { 168, "NZD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW ZEALAND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealand Dollar", " " },
                    { 180, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "PANAMA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 173, "AUD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NORFOLK ISLAND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 181, "PGK", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "PAPUA NEW GUINEA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kina", " " },
                    { 196, "SHP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAINT HELENA, ASCENSION AND TRISTAN DA CUNHA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Helena Pound", " " },
                    { 183, "PEN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "PERU", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nuevo Sol", " " },
                    { 184, "PHP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "PHILIPPINES (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Philippine Peso", " " },
                    { 185, "NZD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "PITCAIRN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealand Dollar", " " },
                    { 186, "PLN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "POLAND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zloty", " " },
                    { 187, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "PORTUGAL", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 188, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "PUERTO RICO", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 189, "QAR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "QATAR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qatari Rial", " " },
                    { 190, "MKD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "REPUBLIC OF NORTH MACEDONIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denar", " " },
                    { 191, "RON", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ROMANIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romanian Leu", " " },
                    { 192, "RUB", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "RUSSIAN FEDERATION (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Russian Ruble", " " },
                    { 193, "RWF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "RWANDA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rwanda Franc", " " },
                    { 194, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "RÉUNION", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 195, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAINT BARTHÉLEMY", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 167, "XPF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW CALEDONIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFP Franc", " " },
                    { 182, "PYG", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "PARAGUAY", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guarani", " " },
                    { 166, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NETHERLANDS (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 136, "CHF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "LIECHTENSTEIN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swiss Franc", " " },
                    { 164, "AUD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NAURU", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 197, "XCD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAINT KITTS AND NEVIS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 135, "LYD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "LIBYA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Libyan Dinar", " " },
                    { 137, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "LITHUANIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 138, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "LUXEMBOURG", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 139, "MOP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MACAO", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pataca", " " },
                    { 140, "MGA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MADAGASCAR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malagasy Ariary", " " },
                    { 141, "MWK", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MALAWI", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kwacha", " " },
                    { 142, "MYR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MALAYSIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malaysian Ringgit", " " },
                    { 143, "MVR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MALDIVES", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rufiyaa", " " },
                    { 144, "XOF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MALI", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 145, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MALTA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 146, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MARSHALL ISLANDS (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 147, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MARTINIQUE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 148, "MRU", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAURITANIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ouguiya", " " },
                    { 149, "MUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAURITIUS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritius Rupee", " " },
                    { 150, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAYOTTE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 151, "MXN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MEXICO", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexican Peso", " " },
                    { 152, "MXV", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MEXICO", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexican Unidad de Inversion (UDI)", " " },
                    { 153, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MICRONESIA (FEDERATED STATES OF)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 154, "MDL", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MOLDOVA (THE REPUBLIC OF)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moldovan Leu", " " },
                    { 155, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MONACO", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 156, "MNT", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MONGOLIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tugrik", " " },
                    { 157, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MONTENEGRO", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 158, "XCD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MONTSERRAT", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 159, "MAD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MOROCCO", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moroccan Dirham", " " },
                    { 160, "MZN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MOZAMBIQUE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mozambique Metical", " " },
                    { 161, "MMK", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MYANMAR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyat", " " },
                    { 162, "NAD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NAMIBIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Namibia Dollar", " " },
                    { 163, "ZAR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NAMIBIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rand", " " },
                    { 165, "NPR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEPAL", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nepalese Rupee", " " },
                    { 198, "XCD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAINT LUCIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 262, "ZWL", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZIMBABWE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zimbabwe Dollar", " " },
                    { 200, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAINT PIERRE AND MIQUELON", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 235, "NZD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TOKELAU", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealand Dollar", " " },
                    { 236, "TOP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TONGA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pa’anga", " " },
                    { 237, "TTD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TRINIDAD AND TOBAGO", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trinidad and Tobago Dollar", " " },
                    { 238, "TND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TUNISIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tunisian Dinar", " " },
                    { 239, "TRY", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TURKEY", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkish Lira", " " },
                    { 240, "TMT", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TURKMENISTAN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkmenistan New Manat", " " },
                    { 241, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TURKS AND CAICOS ISLANDS (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 242, "AUD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TUVALU", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 243, "UGX", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "UGANDA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uganda Shilling", " " },
                    { 244, "UAH", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "UKRAINE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hryvnia", " " },
                    { 245, "AED", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNITED ARAB EMIRATES (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "UAE Dirham", " " },
                    { 246, "GBP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNITED KINGDOM OF GREAT BRITAIN AND NORTHERN IRELAND (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pound Sterling", " " },
                    { 247, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNITED STATES MINOR OUTLYING ISLANDS (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 248, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNITED STATES OF AMERICA (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 249, "USN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNITED STATES OF AMERICA (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar (Next day)", " " },
                    { 250, "UYI", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "URUGUAY", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uruguay Peso en Unidades Indexadas (URUIURUI)", " " },
                    { 251, "UYU", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "URUGUAY", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peso Uruguayo", " " },
                    { 252, "UZS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "UZBEKISTAN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzbekistan Sum", " " },
                    { 253, "VUV", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "VANUATU", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vatu", " " },
                    { 254, "VEF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "VENEZUELA (BOLIVARIAN REPUBLIC OF)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bolivar", " " },
                    { 255, "VND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "VIET NAM", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dong", " " },
                    { 256, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "VIRGIN ISLANDS (BRITISH)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 257, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "VIRGIN ISLANDS (U.S.)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 258, "XPF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "WALLIS AND FUTUNA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFP Franc", " " },
                    { 259, "MAD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "WESTERN SAHARA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moroccan Dirham", " " },
                    { 260, "YER", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "YEMEN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yemeni Rial", " " },
                    { 261, "ZMW", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZAMBIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zambian Kwacha", " " },
                    { 263, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ÅLAND ISLANDS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 134, "LRD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "LIBERIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liberian Dollar", " " },
                    { 234, "XOF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TOGO", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 233, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TIMOR-LESTE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 232, "THB", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "THAILAND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Baht", " " },
                    { 231, "TZS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TANZANIA, UNITED REPUBLIC OF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tanzanian Shilling", " " },
                    { 201, "XCD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAINT VINCENT AND THE GRENADINES", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 202, "WST", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAMOA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tala", " " },
                    { 203, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAN MARINO", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 204, "STN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAO TOME AND PRINCIPE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dobra", " " },
                    { 205, "SAR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAUDI ARABIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saudi Riyal", " " },
                    { 206, "XOF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SENEGAL", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 207, "RSD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SERBIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serbian Dinar", " " },
                    { 208, "SCR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEYCHELLES", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seychelles Rupee", " " },
                    { 209, "SLL", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SIERRA LEONE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leone", " " },
                    { 210, "SGD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SINGAPORE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore Dollar", " " },
                    { 211, "ANG", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SINT MAARTEN (DUTCH PART)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Netherlands Antillean Guilder", " " },
                    { 212, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLOVAKIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 213, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLOVENIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 214, "SBD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SOLOMON ISLANDS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solomon Islands Dollar", " " },
                    { 199, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAINT MARTIN (FRENCH PART)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 215, "SOS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SOMALIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Somali Shilling", " " }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name", "Symbol" },
                values: new object[,]
                {
                    { 217, "SSP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SOUTH SUDAN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Sudanese Pound", " " },
                    { 218, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SPAIN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 219, "LKR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SRI LANKA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sri Lanka Rupee", " " },
                    { 220, "SDG", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SUDAN (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sudanese Pound", " " },
                    { 221, "SRD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SURINAME", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surinam Dollar", " " },
                    { 222, "NOK", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SVALBARD AND JAN MAYEN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norwegian Krone", " " },
                    { 223, "SZL", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SWAZILAND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lilangeni", " " },
                    { 224, "SEK", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SWEDEN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swedish Krona", " " },
                    { 225, "CHE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SWITZERLAND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "WIR Euro", " " },
                    { 226, "CHF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SWITZERLAND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swiss Franc", " " },
                    { 227, "CHW", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SWITZERLAND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "WIR Franc", " " },
                    { 228, "SYP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SYRIAN ARAB REPUBLIC", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Syrian Pound", " " },
                    { 229, "TWD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TAIWAN (PROVINCE OF CHINA)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Taiwan Dollar", " " },
                    { 230, "TJS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TAJIKISTAN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Somoni", " " },
                    { 216, "ZAR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SOUTH AFRICA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rand", " " },
                    { 133, "ZAR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "LESOTHO", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rand", " " },
                    { 69, "EGP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "EGYPT", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egyptian Pound", " " },
                    { 131, "LBP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "LEBANON", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lebanese Pound", " " },
                    { 35, "BGN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BULGARIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bulgarian Lev", " " },
                    { 36, "XOF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BURKINA FASO", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 37, "BIF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BURUNDI", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burundi Franc", " " },
                    { 38, "CVE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CABO VERDE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cabo Verde Escudo", " " },
                    { 39, "KHR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAMBODIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riel", " " },
                    { 40, "XAF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAMEROON", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BEAC", " " },
                    { 41, "CAD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CANADA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canadian Dollar", " " },
                    { 42, "KYD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAYMAN ISLANDS (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cayman Islands Dollar", " " },
                    { 43, "XAF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CENTRAL AFRICAN REPUBLIC (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BEAC", " " },
                    { 44, "XAF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHAD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BEAC", " " },
                    { 45, "CLF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHILE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unidad de Fomento", " " },
                    { 46, "CLP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHILE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chilean Peso", " " },
                    { 47, "CNY", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHINA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yuan Renminbi", " " },
                    { 48, "AUD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHRISTMAS ISLAND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 49, "AUD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "COCOS (KEELING) ISLANDS (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 50, "COP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "COLOMBIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colombian Peso", " " },
                    { 51, "COU", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "COLOMBIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unidad de Valor Real", " " },
                    { 52, "KMF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMOROS (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comoro Franc", " " },
                    { 53, "CDF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CONGO (THE DEMOCRATIC REPUBLIC OF THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Congolese Franc", " " },
                    { 54, "XAF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CONGO (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BEAC", " " },
                    { 55, "NZD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "COOK ISLANDS (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealand Dollar", " " },
                    { 56, "CRC", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "COSTA RICA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Costa Rican Colon", " " },
                    { 57, "HRK", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CROATIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuna", " " },
                    { 58, "CUC", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUBA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peso Convertible", " " },
                    { 59, "CUP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUBA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cuban Peso", " " },
                    { 60, "ANG", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CURAÇAO", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Netherlands Antillean Guilder", " " },
                    { 61, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CYPRUS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 62, "CZK", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CZECH REPUBLIC (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Czech Koruna", " " },
                    { 63, "XOF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CÔTE D'IVOIRE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 34, "BND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BRUNEI DARUSSALAM", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brunei Dollar", " " },
                    { 33, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BRITISH INDIAN OCEAN TERRITORY (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 32, "BRL", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BRAZIL", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brazilian Real", " " },
                    { 31, "NOK", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOUVET ISLAND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norwegian Krone", " " },
                    { 1, "AFN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Currency for  AFGHANISTAN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afghani", " " },
                    { 2, "ALL", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALBANIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lek", " " },
                    { 3, "DZD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALGERIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Algerian Dinar", " " },
                    { 4, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "AMERICAN SAMOA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 5, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANDORRA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 6, "AOA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANGOLA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kwanza", " " },
                    { 7, "XCD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANGUILLA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 8, "XCD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANTIGUA AND BARBUDA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 9, "ARS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ARGENTINA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Argentine Peso", "" },
                    { 10, "AMD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ARMENIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Armenian Dram", " " },
                    { 11, "AWG", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ARUBA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aruban Florin", " " },
                    { 12, "AUD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUSTRALIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 13, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUSTRIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 14, "AZN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "AZERBAIJAN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azerbaijanian Manat", " " },
                    { 64, "DKK", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "DENMARK", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danish Krone", " " },
                    { 15, "BSD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BAHAMAS (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahamian Dollar", " " },
                    { 17, "BDT", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BANGLADESH", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taka", " " },
                    { 18, "BBD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BARBADOS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barbados Dollar", " " },
                    { 19, "BYN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BELARUS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belarussian Ruble", " " },
                    { 20, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BELGIUM", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 21, "BZD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BELIZE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belize Dollar", " " },
                    { 22, "XOF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BENIN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 23, "BMD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BERMUDA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bermudian Dollar", " " },
                    { 24, "BTN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BHUTAN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngultrum", " " },
                    { 132, "LSL", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "LESOTHO", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loti", " " },
                    { 26, "BOB", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOLIVIA (PLURINATIONAL STATE OF)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boliviano", " " },
                    { 27, "BOV", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOLIVIA (PLURINATIONAL STATE OF)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mvdol", " " },
                    { 28, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BONAIRE, SINT EUSTATIUS AND SABA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 29, "BAM", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOSNIA AND HERZEGOVINA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Convertible Mark", " " },
                    { 30, "BWP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOTSWANA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pula", " " },
                    { 16, "BHD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BAHRAIN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahraini Dinar", " " },
                    { 65, "DJF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "DJIBOUTI", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Djibouti Franc", " " },
                    { 25, "INR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BHUTAN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indian Rupee", " " },
                    { 67, "DOP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOMINICAN REPUBLIC (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominican Peso", " " },
                    { 102, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "HAITI", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 103, "AUD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "HEARD ISLAND AND McDONALD ISLANDS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 105, "HNL", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "HONDURAS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lempira", " " },
                    { 106, "HKD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "HONG KONG", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong Dollar", " " },
                    { 107, "HUF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "HUNGARY", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forint", " " },
                    { 108, "ISK", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ICELAND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iceland Krona", " " },
                    { 109, "INR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "INDIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indian Rupee", " " },
                    { 110, "IDR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "INDONESIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rupiah", " " },
                    { 111, "XDR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "INTERNATIONAL MONETARY FUND (IMF) ", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SDR (Special Drawing Right)", " " },
                    { 112, "IRR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "IRAN (ISLAMIC REPUBLIC OF)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iranian Rial", " " },
                    { 113, "IQD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "IRAQ", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iraqi Dinar", " " },
                    { 114, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "IRELAND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 115, "GBP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISLE OF MAN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pound Sterling", " " },
                    { 116, "ILS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISRAEL", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Israeli Sheqel", " " },
                    { 117, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ITALY", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 118, "JMD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "JAMAICA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamaican Dollar", " " },
                    { 119, "JPY", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "JAPAN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yen", " " },
                    { 120, "GBP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "JERSEY", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pound Sterling", " " },
                    { 121, "JOD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "JORDAN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordanian Dinar", " " },
                    { 122, "KZT", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "KAZAKHSTAN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tenge", " " },
                    { 123, "KES", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "KENYA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kenyan Shilling", " " },
                    { 124, "AUD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "KIRIBATI", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 125, "KPW", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "KOREA (THE DEMOCRATIC PEOPLE’S REPUBLIC OF)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Korean Won", " " },
                    { 126, "KRW", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "KOREA (THE REPUBLIC OF)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Won", " " },
                    { 127, "KWD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "KUWAIT", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuwaiti Dinar", " " },
                    { 128, "KGS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "KYRGYZSTAN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Som", " " },
                    { 129, "LAK", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "LAO PEOPLE’S DEMOCRATIC REPUBLIC (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kip", " " },
                    { 130, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "LATVIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 66, "XCD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOMINICA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 101, "HTG", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "HAITI", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gourde", " " },
                    { 100, "GYD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GUYANA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guyana Dollar", " " },
                    { 104, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "HOLY SEE (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 98, "GNF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GUINEA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guinea Franc", " " },
                    { 68, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ECUADOR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 70, "SVC", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "EL SALVADOR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "El Salvador Colon", " " },
                    { 71, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "EL SALVADOR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 72, "XAF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "EQUATORIAL GUINEA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BEAC", " " },
                    { 73, "ERN", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ERITREA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nakfa", " " },
                    { 74, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ESTONIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 75, "ETB", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ETHIOPIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethiopian Birr", " " },
                    { 76, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUROPEAN UNION", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 77, "FKP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FALKLAND ISLANDS (THE) [MALVINAS]", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Falkland Islands Pound", " " },
                    { 99, "XOF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GUINEA-BISSAU", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 79, "FJD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FIJI", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fiji Dollar", " " },
                    { 80, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FINLAND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 81, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FRANCE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 82, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FRENCH GUIANA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 83, "XPF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FRENCH POLYNESIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFP Franc", " " },
                    { 78, "DKK", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FAROE ISLANDS (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danish Krone", " " },
                    { 85, "XAF", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GABON", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BEAC", " " },
                    { 97, "GBP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GUERNSEY", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pound Sterling", " " },
                    { 84, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FRENCH SOUTHERN TERRITORIES (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 95, "USD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GUAM", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 94, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GUADELOUPE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 93, "XCD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GRENADA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 92, "DKK", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GREENLAND", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danish Krone", " " },
                    { 96, "GTQ", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GUATEMALA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quetzal", " " },
                    { 90, "GIP", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GIBRALTAR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gibraltar Pound", " " },
                    { 89, "GHS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GHANA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghana Cedi", " " },
                    { 86, "GMD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GAMBIA (THE)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dalasi", " " },
                    { 88, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GERMANY", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 87, "GEL", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GEORGIA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lari", " " },
                    { 91, "EUR", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GREECE", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " }
                });

            migrationBuilder.InsertData(
                table: "DWSClass",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Class VI" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClassV" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Class IV" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Class III" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Class I" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Class II" }
                });

            migrationBuilder.InsertData(
                table: "DateSetting",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 12, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "3 Dec 2020" },
                    { 11, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "03 December 2020" },
                    { 10, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "December 03, 2020" },
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Friday, December 03, 2020" },
                    { 9, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fri, December 03, 2020" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "2020-12-03" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "03.12.2020" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "03 Dec 2020" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "03-12-2020" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "03/12/2020" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "12/03/2020" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "03-Dec-2020" }
                });

            migrationBuilder.InsertData(
                table: "Designation",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 15, null, null, "Chief Executive Officer (CEO) or President", null, null, "Chief Executive Officer (CEO) or President" },
                    { 13, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vice President of Marketing or Marketing Manager", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vice President of Marketing or Marketing Manager" },
                    { 12, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief Financial Officer (CFO)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief Financial Officer (CFO)" },
                    { 11, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Production Manager", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Production Manager" },
                    { 10, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Professional staff", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Professional staff" },
                    { 9, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipping and receiving person or manager", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipping and receiving person or manager" },
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Purchasing manager", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Purchasing manager" },
                    { 14, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief Operating Officer (COO)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief Operating Officer (COO)" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Foreperson, supervisor, lead person", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Foreperson, supervisor, lead person" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Receptionist", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Receptionist" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Office manager", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Office manager" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accountant, bookkeeper, controller", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accountant, bookkeeper, controller" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quality control, safety, environmental manager", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quality control, safety, environmental manager" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marketing manager", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marketing manager" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operations manager", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operations manager" }
                });

            migrationBuilder.InsertData(
                table: "Disability",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Self-care" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Walking" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Remembering" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Communication" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hearing" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seeing" }
                });

            migrationBuilder.InsertData(
                table: "DisabilityLevel",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Difficulty" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some Difficulty" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "A lot of Difficulty" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cannot do at all" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cannot yet be determined" }
                });

            migrationBuilder.InsertData(
                table: "Division",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 10, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Small Wastewater Treatment Works" },
                    { 14, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Community Water Supply and Sanitation" },
                    { 13, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Water Science" },
                    { 12, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Water Reuse" },
                    { 15, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Young Water Professionals" },
                    { 11, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Water Distribution" },
                    { 9, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Process Controllers" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Innovations in Water & Sanitation" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membrane Technology" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Management & Institutional Affairs" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "IWA-SA" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Industrial Water" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Community Water Supply and Sanitation" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anaerobic Sludge Processes" },
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mine Water" }
                });

            migrationBuilder.InsertData(
                table: "EmailType",
                columns: new[] { "id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal E-mail", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Work E-mail", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Work" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Business E-mail", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Business" }
                });

            migrationBuilder.InsertData(
                table: "EmploymentCategory",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Current Employer" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Previous Employer" }
                });

            migrationBuilder.InsertData(
                table: "Ethnicity",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asian" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coloured", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coloured" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indian", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indian" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "White", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "White" }
                });

            migrationBuilder.InsertData(
                table: "EventMinuteStatus",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Under preperation", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "In-Progress" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepared & awaiting approval", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepared" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shared with concerned people", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shared" }
                });

            migrationBuilder.InsertData(
                table: "EventResponseType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Organizer" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sponsor" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Facilitator" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guest" }
                });

            migrationBuilder.InsertData(
                table: "FileType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "StudentLetter" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Note" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proof of Payment" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Certificates (Completed Qualifications)" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proof of DWS Registration (If Applicable)" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ID Document" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proof of Registration ( If fulltime Student)" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other" }
                });

            migrationBuilder.InsertData(
                table: "InvoiceStatus",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 10, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uncollectible Invoice", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Write Off" },
                    { 9, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canceled Invoice", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canceled" },
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incorrect / Dispute Invoice", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Void" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Partial payment", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Partial" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Payment made", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paid" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Outstanding payment", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overdue" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Due for payment", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Due" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viewed by member", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viewed" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Send to Member", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Send" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incomplete Invoice", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Draft" }
                });

            migrationBuilder.InsertData(
                table: "Involvement",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 11, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assist in obtaining sponsorship " },
                    { 10, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Media mentor - reporting to WISA HQ all the news that is relevant to the Water sector and that needs our attention " },
                    { 9, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Community outreach projects" },
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Man a \"membership desk or exhibition stand\" at WISA events hosted by other parties in the water sector to promote WISA membership and answer enquiries regarding WISA " },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visit businesses and government departments to promote WISA" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Branch/Division Committee member" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Being a mentor and/or specialist advisor" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Writing articles for publication in WISA and main stream media" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Promotions and Marketing" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Logistics" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visit schools and universities to promote WISA" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiTsonga", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiTsonga" },
                    { 12, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SiSwati", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SiSwati" },
                    { 11, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "sePedi", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "sePedi" },
                    { 10, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiXhosa", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiXhosa" },
                    { 9, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiNdebele", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiNdebele" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "seSotho", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "seSotho" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "tshiVenda", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "tshiVenda" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "seTswana", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "seTswana" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afrikaans", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afrikaans" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "English", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "English" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiZulu", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiZulu" }
                });

            migrationBuilder.InsertData(
                table: "MemberBranch",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 14, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johannesburg" },
                    { 13, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Northern Cape" },
                    { 12, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "North West" },
                    { 11, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Head Office" },
                    { 10, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Free State" },
                    { 9, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western Cape" },
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Namibia" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limpopo" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "KwaZulu Natal" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "International" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gauteng" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eastern Cape" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Regions" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mpumalanga" }
                });

            migrationBuilder.InsertData(
                table: "MemberShipChangeReason",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 9, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upgrade" },
                    { 13, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inactive-Deceased" },
                    { 12, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inactive-Suspended" },
                    { 11, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inactive-Resigned" },
                    { 10, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Change" },
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspended" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resigned" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deceased" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspended – account in arrears" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Applicant" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Application Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "MemberStatus",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Application Cancelled" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Applicant" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deceased" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resigned" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspended – account in arrears" },
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspended" }
                });

            migrationBuilder.InsertData(
                table: "MembershipGrade",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "IndividualOrNonIndividualId", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 22, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contact" },
                    { 21, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Municipality" },
                    { 19, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-Individual Member" },
                    { 18, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Professional Members Association" },
                    { 17, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patron Member" },
                    { 16, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Educational Institutions" },
                    { 20, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Local Authority" },
                    { 14, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Retired Sen. Fellow" },
                    { 15, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company Member" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Professional Process Controller" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Affiliate" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Associate Member" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Academic Member" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fellow" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member" },
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student Member" },
                    { 9, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Free Retired" },
                    { 10, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honorary Member" },
                    { 11, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Media Member" },
                    { 12, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Retired Fellow" },
                    { 13, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Retired Member" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Fellow" }
                });

            migrationBuilder.InsertData(
                table: "MembershipType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Additional Contacts", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Additional Contacts" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contact Person", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contact Person" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Billing Contact", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Billing Contact" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary Contact", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary Contact" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Professional Process Controller", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Professional Process Controller" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non Individual Member", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non Individual Member" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Individual Member", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Individual Member" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non Members", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non Members" }
                });

            migrationBuilder.InsertData(
                table: "Occupation",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 11, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Director / Manager (not in the water industry)" },
                    { 12, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Process Controller" },
                    { 10, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Director / Manager (in water industry)" },
                    { 14, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consultant" },
                    { 15, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other" },
                    { 13, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Self Employed" },
                    { 9, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Technician" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unemployed" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engineer" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Retired – not working" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full time student" },
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Practitioner" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Researcher" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scientist" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Academic" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationGrade",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Local Authority", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Local Authority" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Water Board", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Water Board" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Health", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patron Member" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Business / Trade", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Professional Members Association" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Community / HOA", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Educational Institutions" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Chamber of commerce", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company Member" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Business / Trade", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Municipality" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Association - Professional", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Media Member" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationStructure",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "LevelOfMember", "MaximumNumber", "MaximumTimeInYears", "ModifiedBy", "ModifiedOn", "Name", "ShowMaximumTimeInYears" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Executive", 3, 3, 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Executive", true },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager", 2, 10, 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager", true },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Associate", 1, 100, 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Associate", true }
                });

            migrationBuilder.InsertData(
                table: "OrganizationType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Professional Member Association" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Educational Institution" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Municipality" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Government Department" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-Individual Member" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Water Service Provider" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Private" }
                });

            migrationBuilder.InsertData(
                table: "PayPalPreferredPaymentGateway",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paypal Payments Pro", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paypal Payments Pro" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pay Flow Gateway", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pay Flow" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Can create new contacts, modify all existing ones  ", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membership manager" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Can create and manage all events", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event manager" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Can manage all donations", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Donations manager" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Can send manual emails (e.g. newsletters)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Newsletter manager" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Can modify your website pages. With this option selected, you can provide access to all pages on your site or to selected pages. When you grant access to a page, you automatically grant access to all of its child or sub pages.", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Website editor" }
                });

            migrationBuilder.InsertData(
                table: "PlanFrequency",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Life Time", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Life Time" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quarterly", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quarterly" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yearly", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yearly" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daily", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daily" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly" }
                });

            migrationBuilder.InsertData(
                table: "PreferredContactTime",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morning", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morning" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Day", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Day" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evenings", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evenings" }
                });

            migrationBuilder.InsertData(
                table: "PromotionResponseType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Call" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Email" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SMS" }
                });

            migrationBuilder.InsertData(
                table: "Qualification",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr/PHD degree" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Master’s degree" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honours degree" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Postgraduate diploma" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "3 year diploma/degree" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matric/Grade 12" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "4 year degree" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "1 year diploma/certificate" }
                });

            migrationBuilder.InsertData(
                table: "QualificationCategory",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Current Studies" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed Qualifications" }
                });

            migrationBuilder.InsertData(
                table: "QualificationEnrolmentCategory",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FullTime" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "PartTime" }
                });

            migrationBuilder.InsertData(
                table: "QualificationType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honours degree" },
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr/PHD degree" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Master’s degree" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Postgraduate diploma" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "4 year degree" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "3 year diploma/degree" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "1 year diploma/certificate" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matric/Grade 12" }
                });

            migrationBuilder.InsertData(
                table: "ReferralType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Word of Mouth", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Word of Mouth." },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "WISA NewsLetter", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "WISA NewsLetter" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "WISA WebSite", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "WISA Website" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "WISA Event (Conference, Branch or Division Event)", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "WISA Event (Conference, Branch or Division Event)" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other" }
                });

            migrationBuilder.InsertData(
                table: "RelatedTo",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contact", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contact" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Note", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Note" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CPD", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CPD" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Organization", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Organization" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Select this option to remove admin access for existing administrators  ", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "No administrative privileges" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grants full access to all administrative functions. Take care when granting this level of access since full admins can delete other admins and even the entire site.", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Account administrator" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allows viewing of everything in the admin backend without being able to make any changes.  ", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Account administrator (Read-only access)" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Provides administrative access to selected Wild Apricot modules. Use this option if you have dedicated personnel in charge of events, memberships, editing webpages, or managing donations. With this option selected, you can limit access to selected Functions", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limited administrator" }
                });

            migrationBuilder.InsertData(
                table: "TimeFormat",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "12:00 AM/PM" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "24 Hours" }
                });

            migrationBuilder.InsertData(
                table: "Title",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fr" },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sr" },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adv" },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prof" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ms" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mrs" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member" },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contact", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contact" }
                });

            migrationBuilder.InsertData(
                table: "VolunteerHours",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "11-15 hours per week" },
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-5  hours per week" },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "6-10  hours per week" },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "16-20 hours per week" }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "CountryId", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eastern Cape" },
                    { 2, 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Free State" },
                    { 3, 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gauteng" },
                    { 4, 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "KwaZulu-Natal" },
                    { 5, 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limpopo" },
                    { 6, 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mpumalanga" },
                    { 7, 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "North West" },
                    { 8, 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Northern Cape" },
                    { 9, 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western Cape" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name", "StateId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adelaide", 1 },
                    { 213, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brits", 7 },
                    { 212, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bojanala Platinum District Municipality", 7 },
                    { 211, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bloemhof", 7 },
                    { 210, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Witbank", 6 },
                    { 209, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "White River", 6 },
                    { 208, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Volksrust", 6 },
                    { 207, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Standerton", 6 },
                    { 206, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siyabuswa", 6 },
                    { 205, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Secunda", 6 },
                    { 204, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piet Retief", 6 },
                    { 203, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nkangala District Municipality", 6 },
                    { 202, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nelspruit", 6 },
                    { 201, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Middelburg", 6 },
                    { 200, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lydenburg", 6 },
                    { 199, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kriel", 6 },
                    { 214, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christiana", 7 },
                    { 215, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr Kenneth Kaunda District Municipality", 7 },
                    { 216, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr Ruth Segomotsi Mompati District Municipality", 7 },
                    { 217, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fochville", 7 },
                    { 233, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wolmaransstad", 7 },
                    { 232, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vryburg", 7 },
                    { 231, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stilfontein", 7 },
                    { 230, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schweizer-Reneke", 7 },
                    { 229, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rustenburg", 7 },
                    { 228, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Potchefstroom", 7 },
                    { 227, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orkney", 7 },
                    { 198, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Komatipoort", 6 },
                    { 226, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngaka Modiri Molema District Municipality", 7 },
                    { 224, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maile", 7 },
                    { 223, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahikeng", 7 },
                    { 222, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lichtenburg", 7 },
                    { 221, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Koster", 7 },
                    { 220, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Klerksdorp", 7 },
                    { 219, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan Kempdorp", 7 },
                    { 218, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ga-Rankuwa", 7 },
                    { 225, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mmabatho", 7 },
                    { 234, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zeerust", 7 },
                    { 197, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hendrina", 6 },
                    { 195, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ermelo", 6 },
                    { 174, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nkowakowa", 5 },
                    { 173, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Musina", 5 },
                    { 172, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mopani District Municipality", 5 },
                    { 171, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mokopane", 5 },
                    { 170, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Modimolle", 5 },
                    { 169, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mankoeng", 5 },
                    { 168, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Louis Trichardt", 5 },
                    { 167, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lebowakgomo", 5 },
                    { 166, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giyani", 5 },
                    { 165, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ga-Kgapane", 5 },
                    { 164, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duiwelskloof", 5 },
                    { 163, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Capricorn District Municipality", 5 },
                    { 162, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bochum", 5 },
                    { 161, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zululand District Municipality", 4 },
                    { 160, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vryheid", 4 },
                    { 175, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phalaborwa", 5 },
                    { 176, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Polokwane", 5 },
                    { 177, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sekhukhune District Municipality", 5 },
                    { 178, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thabazimbi", 5 },
                    { 194, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "eMbalenhle", 6 },
                    { 193, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ehlanzeni District", 6 },
                    { 192, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Driefontein", 6 },
                    { 191, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delmas", 6 },
                    { 190, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carolina", 6 },
                    { 189, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breyten", 6 },
                    { 188, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bethal", 6 },
                    { 196, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gert Sibande District Municipality", 6 },
                    { 187, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belfast", 6 },
                    { 185, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Balfour", 6 },
                    { 184, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waterberg District Municipality", 5 },
                    { 183, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warmbaths", 5 },
                    { 182, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vhembe District Municipality", 5 },
                    { 181, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tzaneen", 5 },
                    { 180, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thulamahashi", 5 },
                    { 179, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thohoyandou", 5 },
                    { 186, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barberton", 6 },
                    { 235, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barkly West", 8 },
                    { 236, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brandvlei", 8 },
                    { 237, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calvinia", 8 },
                    { 292, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mossel Bay", 9 },
                    { 291, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moorreesburg", 9 },
                    { 290, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montagu", 9 },
                    { 289, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malmesbury", 9 },
                    { 288, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lansdowne", 9 },
                    { 287, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ladismith", 9 },
                    { 286, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kraaifontein", 9 },
                    { 285, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Knysna", 9 },
                    { 284, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hermanus", 9 },
                    { 283, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hardys Memories of Africa", 9 },
                    { 282, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grabouw", 9 },
                    { 281, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "George", 9 },
                    { 280, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eden District Municipality", 9 },
                    { 279, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "De Rust", 9 },
                    { 278, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Constantia", 9 },
                    { 293, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Newlands", 9 },
                    { 294, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oudtshoorn", 9 },
                    { 295, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overberg District Municipality", 9 },
                    { 296, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paarl", 9 },
                    { 312, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Coast District Municipality", 9 },
                    { 311, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wellington", 9 },
                    { 310, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vredendal", 9 },
                    { 309, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vredenburg", 9 },
                    { 308, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swellendam", 9 },
                    { 307, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunset Beach", 9 },
                    { 306, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stellenbosch", 9 },
                    { 277, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Claremont", 9 },
                    { 305, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saldanha", 9 },
                    { 303, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rondebosch", 9 },
                    { 302, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robertson", 9 },
                    { 301, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riversdale", 9 },
                    { 300, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Retreat", 9 },
                    { 299, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prince Albert", 9 },
                    { 298, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plettenberg Bay", 9 },
                    { 297, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piketberg", 9 },
                    { 304, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rosebank", 9 },
                    { 276, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clanwilliam", 9 },
                    { 275, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "City of Cape Town", 9 },
                    { 274, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ceres", 9 },
                    { 253, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pixley ka Seme District Municipality", 8 },
                    { 252, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pampierstad", 8 },
                    { 251, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orania", 8 },
                    { 250, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noupoort", 8 },
                    { 249, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Namakwa District Municipality", 8 },
                    { 248, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuruman", 8 },
                    { 247, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kimberley", 8 },
                    { 254, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pofadder", 8 },
                    { 246, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kenhardt", 8 },
                    { 244, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Taolo Gaetsewe District Municipality", 8 },
                    { 243, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fraserburg", 8 },
                    { 242, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frances Baard District Municipality", 8 },
                    { 241, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "De Aar", 8 },
                    { 240, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "DaniÃ«lskuil", 8 },
                    { 239, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colesberg", 8 },
                    { 238, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carnarvon", 8 },
                    { 245, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kathu", 8 },
                    { 159, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Utrecht", 4 },
                    { 255, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Postmasburg", 8 },
                    { 257, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ritchie", 8 },
                    { 273, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Karoo District Municipality", 9 },
                    { 272, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cape Winelands District Municipality", 9 },
                    { 271, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cape Town", 9 },
                    { 270, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calitzdorp", 9 },
                    { 269, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caledon", 9 },
                    { 268, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bredasdorp", 9 },
                    { 267, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bergvliet", 9 },
                    { 256, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prieska", 8 },
                    { 266, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beaufort West", 9 },
                    { 264, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arniston", 9 },
                    { 263, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Albertina", 9 },
                    { 262, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warrenton", 8 },
                    { 261, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Van Wyksvlei", 8 },
                    { 260, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upington", 8 },
                    { 259, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Springbok", 8 },
                    { 258, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siyanda District Municipality", 8 },
                    { 265, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Atlantis", 9 },
                    { 158, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "uThungulu District Municipality", 4 },
                    { 157, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "uThukela District Municipality", 4 },
                    { 156, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "uMzinyathi District Municipality", 4 },
                    { 56, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ladybrand", 2 },
                    { 55, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kutloanong", 2 },
                    { 54, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kroonstad", 2 },
                    { 53, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Koppies", 2 },
                    { 52, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoopstad", 2 },
                    { 51, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hennenman", 2 },
                    { 50, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heilbron", 2 },
                    { 49, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harrismith", 2 },
                    { 48, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frankfort", 2 },
                    { 47, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fezile Dabi District Municipality", 2 },
                    { 46, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deneysville", 2 },
                    { 45, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clocolan", 2 },
                    { 44, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brandfort", 2 },
                    { 43, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botshabelo", 2 },
                    { 42, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bothaville", 2 },
                    { 57, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lejweleputswa District Municipality", 2 },
                    { 58, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lindley", 2 },
                    { 59, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mangaung Metropolitan Municipality", 2 },
                    { 60, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marquard", 2 },
                    { 76, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wesselsbron", 2 },
                    { 75, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welkom", 2 },
                    { 74, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vredefort", 2 },
                    { 73, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vrede", 2 },
                    { 72, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virginia", 2 },
                    { 71, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Villiers", 2 },
                    { 70, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viljoenskroon", 2 },
                    { 41, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bloemfontein", 2 },
                    { 69, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ventersburg", 2 },
                    { 67, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thabo Mofutsanyana District Municipality", 2 },
                    { 66, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thaba Nchu", 2 },
                    { 65, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senekal", 2 },
                    { 64, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sasolburg", 2 },
                    { 63, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reitz", 2 },
                    { 62, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phuthaditjhaba", 2 },
                    { 61, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parys", 2 },
                    { 68, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Theunissen", 2 },
                    { 40, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bethlehem", 2 },
                    { 39, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allanridge", 2 },
                    { 38, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Willowmore", 1 },
                    { 17, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Graaff-Reinet", 1 },
                    { 16, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fort Beaufort", 1 },
                    { 15, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elliot", 1 },
                    { 14, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "East London", 1 },
                    { 13, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dordrecht", 1 },
                    { 12, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cradock", 1 },
                    { 11, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris Hani District Municipality", 1 },
                    { 18, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grahamstown", 1 },
                    { 10, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cacadu District Municipality", 1 },
                    { 8, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burgersdorp", 1 },
                    { 7, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buffalo City Metropolitan Municipality", 1 },
                    { 6, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bhisho", 1 },
                    { 5, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amathole District Municipality", 1 },
                    { 4, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aliwal North", 1 },
                    { 3, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice", 1 },
                    { 2, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alfred Nzo District Municipality", 1 },
                    { 9, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Butterworth", 1 },
                    { 77, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Winburg", 2 },
                    { 19, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ilinge", 1 },
                    { 21, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kirkwood", 1 },
                    { 37, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Whittlesea", 1 },
                    { 36, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uitenhage", 1 },
                    { 35, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stutterheim", 1 },
                    { 34, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Somerset East", 1 },
                    { 33, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Queenstown", 1 },
                    { 32, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Queensdale", 1 },
                    { 31, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Saint Johnâ€™s", 1 },
                    { 20, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joe Gqabi District Municipality", 1 },
                    { 30, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Elizabeth", 1 },
                    { 28, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "OR Tambo District Municipality", 1 },
                    { 27, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nelson Mandela Bay Metropolitan Municipality", 1 },
                    { 26, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mthatha", 1 },
                    { 25, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Molteno", 1 },
                    { 24, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Middelburg", 1 },
                    { 23, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lady Frere", 1 },
                    { 22, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kruisfontein", 1 },
                    { 29, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Alfred", 1 },
                    { 313, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Worcester", 9 },
                    { 78, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xhariep District Municipality", 2 },
                    { 80, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alberton", 3 },
                    { 135, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kokstad", 4 },
                    { 134, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "iLembe District Municipality", 4 },
                    { 133, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Howick", 4 },
                    { 132, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hluhluwe", 4 },
                    { 131, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greytown", 4 },
                    { 130, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Glencoe", 4 },
                    { 129, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "eThekwini Metropolitan Municipality", 4 },
                    { 128, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "eSikhaleni", 4 },
                    { 127, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eshowe", 4 },
                    { 126, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Empangeni", 4 },
                    { 125, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "eMkhomazi", 4 },
                    { 124, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ekuvukeni", 4 },
                    { 123, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Durban", 4 },
                    { 122, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dundee", 4 },
                    { 121, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Berea", 4 },
                    { 136, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "KwaDukuza", 4 },
                    { 137, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Margate", 4 },
                    { 138, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mondlo", 4 },
                    { 139, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mooirivier", 4 },
                    { 155, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "uMkhanyakude District Municipality", 4 },
                    { 154, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "uMgungundlovu District Municipality", 4 },
                    { 153, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ulundi", 4 },
                    { 152, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ugu District Municipality", 4 },
                    { 151, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sundumbili", 4 },
                    { 150, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sisonke District Municipality", 4 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name", "StateId" },
                values: new object[,]
                {
                    { 149, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scottburgh", 4 },
                    { 120, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ballito", 4 },
                    { 148, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Richmond", 4 },
                    { 146, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Shepstone", 4 },
                    { 145, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pietermaritzburg", 4 },
                    { 144, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Newcastle", 4 },
                    { 143, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ndwedwe", 4 },
                    { 142, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mtubatuba", 4 },
                    { 141, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mpumalanga", 4 },
                    { 140, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mpophomeni", 4 },
                    { 147, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Richards Bay", 4 },
                    { 119, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amajuba District Municipality", 4 },
                    { 118, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Westonaria", 3 },
                    { 117, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Rand District Municipality", 3 },
                    { 96, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ekurhuleni Metropolitan Municipality", 3 },
                    { 95, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ekangala", 3 },
                    { 94, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edenvale", 3 },
                    { 93, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eden Glen Ext 60", 3 },
                    { 92, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eden Glen", 3 },
                    { 91, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eastleigh", 3 },
                    { 90, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diepsloot", 3 },
                    { 97, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heidelberg", 3 },
                    { 89, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cullinan", 3 },
                    { 87, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "City of Johannesburg Metropolitan Municipality", 3 },
                    { 86, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Centurion", 3 },
                    { 85, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carletonville", 3 },
                    { 84, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bronkhorstspruit", 3 },
                    { 83, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brakpan", 3 },
                    { 82, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boksburg", 3 },
                    { 81, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benoni", 3 },
                    { 88, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "City of Tshwane Metropolitan Municipality", 3 },
                    { 79, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zastron", 2 },
                    { 98, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johannesburg", 3 },
                    { 100, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mabopane", 3 },
                    { 116, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vereeniging", 3 },
                    { 115, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vanderbijlpark", 3 },
                    { 114, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tembisa", 3 },
                    { 113, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Springs", 3 },
                    { 112, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Soweto", 3 },
                    { 111, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sedibeng District Municipality", 3 },
                    { 110, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roodepoort", 3 },
                    { 99, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krugersdorp", 3 },
                    { 109, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Randfontein", 3 },
                    { 107, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pretoria", 3 },
                    { 106, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orange Farm", 3 },
                    { 105, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nigel", 3 },
                    { 104, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Muldersdriseloop", 3 },
                    { 103, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Modderfontein", 3 },
                    { 102, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Midstream", 3 },
                    { 101, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Midrand", 3 },
                    { 108, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Randburg", 3 },
                    { 314, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zoar", 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddressTypeId",
                table: "Address",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_RelatedToId",
                table: "Address",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateId",
                table: "Address",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TitleId",
                table: "AspNetUsers",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserTypeId",
                table: "AspNetUsers",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BankingDetail_AccountTypeId",
                table: "BankingDetail",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Billing_InvoiceId",
                table: "Billing",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Billing_MemberId",
                table: "Billing",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Billing_PaymentGatewayId",
                table: "Billing",
                column: "PaymentGatewayId");

            migrationBuilder.CreateIndex(
                name: "IX_Billing_RelatedToId",
                table: "Billing",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrganization_ClientOrganizationTypeId",
                table: "ClientOrganization",
                column: "ClientOrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrganization_ClientTimeZoneId",
                table: "ClientOrganization",
                column: "ClientTimeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrganization_CurrencyId",
                table: "ClientOrganization",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrganization_DateSettingId",
                table: "ClientOrganization",
                column: "DateSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrganization_TimeFormatId",
                table: "ClientOrganization",
                column: "TimeFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPlanHistory_BillingUserId",
                table: "ClientPlanHistory",
                column: "BillingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientUser_ApplicaitonUserId",
                table: "ClientUser",
                column: "ApplicaitonUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientUser_DesignationId",
                table: "ClientUser",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientUser_ReferralTypeId",
                table: "ClientUser",
                column: "ReferralTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientUser_RoleId",
                table: "ClientUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationPreference_CommunicationTypeId",
                table: "CommunicationPreference",
                column: "CommunicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_ActionedByUserId",
                table: "ContactUs",
                column: "ActionedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_ContactUsRelatedToId",
                table: "ContactUs",
                column: "ContactUsRelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_CPD_CPDAwardedById",
                table: "CPD",
                column: "CPDAwardedById");

            migrationBuilder.CreateIndex(
                name: "IX_CPD_MemberId",
                table: "CPD",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CPD_RelatedToId",
                table: "CPD",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_CPDMemberLevelSetUp_MemberLevelId",
                table: "CPDMemberLevelSetUp",
                column: "MemberLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_CPDMemberLevelSetUp_RelatedToId",
                table: "CPDMemberLevelSetUp",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_CPDMembershipGradeSetUp_MembershipGradeId",
                table: "CPDMembershipGradeSetUp",
                column: "MembershipGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_CPDMembershipGradeSetUp_RelatedToId",
                table: "CPDMembershipGradeSetUp",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_CPDMembershipTypeSetUp_MembershipTypeId",
                table: "CPDMembershipTypeSetUp",
                column: "MembershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CPDMembershipTypeSetUp_RelatedToId",
                table: "CPDMembershipTypeSetUp",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_CPDMemberTeamSetUp_MemberTeamId",
                table: "CPDMemberTeamSetUp",
                column: "MemberTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_CPDMemberTeamSetUp_RelatedToId",
                table: "CPDMemberTeamSetUp",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityMemberXref_DisabilityId",
                table: "DisabilityMemberXref",
                column: "DisabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityMemberXref_DisabilityLevelId",
                table: "DisabilityMemberXref",
                column: "DisabilityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityMemberXref_MemberId",
                table: "DisabilityMemberXref",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_DivisionMemberXref_DivisonId",
                table: "DivisionMemberXref",
                column: "DivisonId");

            migrationBuilder.CreateIndex(
                name: "IX_DivisionMemberXref_MemberId",
                table: "DivisionMemberXref",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_MemberId",
                table: "Donation",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_PromotionDetailId",
                table: "Donation",
                column: "PromotionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_DWSClassMemberXref_DWSClassId",
                table: "DWSClassMemberXref",
                column: "DWSClassId");

            migrationBuilder.CreateIndex(
                name: "IX_DWSClassMemberXref_MemberId",
                table: "DWSClassMemberXref",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailCCRule_EmailTypeId",
                table: "EmailCCRule",
                column: "EmailTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailCCRule_RoleId",
                table: "EmailCCRule",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplateContent_EmailTemplateNameId",
                table: "EmailTemplateContent",
                column: "EmailTemplateNameId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentMemberXref_EmploymentCategoryId",
                table: "EmploymentMemberXref",
                column: "EmploymentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentMemberXref_MemberUserId",
                table: "EmploymentMemberXref",
                column: "MemberUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCount_EquipmentId",
                table: "EquipmentCount",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_AddressId",
                table: "Event",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganizerId",
                table: "Event",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_TimeZoneId",
                table: "Event",
                column: "TimeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAccess_EventId",
                table: "EventAccess",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendance_EventId",
                table: "EventAttendance",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendance_MemberId",
                table: "EventAttendance",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCommunication_EventId",
                table: "EventCommunication",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCost_EventCostItemId",
                table: "EventCost",
                column: "EventCostItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCost_EventId",
                table: "EventCost",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCostItem_EventId",
                table: "EventCostItem",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventEquipment_EquipmentId",
                table: "EventEquipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EventEquipment_EventId",
                table: "EventEquipment",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventMinute_EventId",
                table: "EventMinute",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventMinute_MinuteStatusId",
                table: "EventMinute",
                column: "MinuteStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EventPreRequisiteEvent_EventId",
                table: "EventPreRequisiteEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventPreRequisiteEvent_PreRequisiteEventId",
                table: "EventPreRequisiteEvent",
                column: "PreRequisiteEventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistration_EventId",
                table: "EventRegistration",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistration_EventResponseTypeId",
                table: "EventRegistration",
                column: "EventResponseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistration_MemberId",
                table: "EventRegistration",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRestrictionList_EventId",
                table: "EventRestrictionList",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRestrictionList_MemberLevelId",
                table: "EventRestrictionList",
                column: "MemberLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRestrictionList_MemberTeamId",
                table: "EventRestrictionList",
                column: "MemberTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRole_EventId",
                table: "EventRole",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRoleUserXRef_EventRoleId",
                table: "EventRoleUserXRef",
                column: "EventRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRoleUserXRef_UserId",
                table: "EventRoleUserXRef",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualMemberShipHistory_MemberId",
                table: "IndividualMemberShipHistory",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualMemberShipHistory_MemberShipChangeReasonId",
                table: "IndividualMemberShipHistory",
                column: "MemberShipChangeReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualMemberShipHistory_MemberShipGradeId",
                table: "IndividualMemberShipHistory",
                column: "MemberShipGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualMemberShipHistory_MemberStatusId",
                table: "IndividualMemberShipHistory",
                column: "MemberStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualMemberShipHistory_MembershipTypeId",
                table: "IndividualMemberShipHistory",
                column: "MembershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceStatusId",
                table: "Invoice",
                column: "InvoiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_MemberId",
                table: "Invoice",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_PaymentGatewayId",
                table: "Invoice",
                column: "PaymentGatewayId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_RelatedToId",
                table: "Invoice",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvementMemberXref_InvolvementId",
                table: "InvolvementMemberXref",
                column: "InvolvementId");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvementMemberXref_MemberId",
                table: "InvolvementMemberXref",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_LandingPage_MemberShipGradeId",
                table: "LandingPage",
                column: "MemberShipGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_LandingPage_PageId",
                table: "LandingPage",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingGroupXRef_MarketingGroupId",
                table: "MarketingGroupXRef",
                column: "MarketingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingGroupXRef_MemberId",
                table: "MarketingGroupXRef",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingProfileXRef_MarketingProfileId",
                table: "MarketingProfileXRef",
                column: "MarketingProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingProfileXRef_MemberId",
                table: "MarketingProfileXRef",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAddress_AddressTypeId",
                table: "MemberAddress",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAddress_BranchId",
                table: "MemberAddress",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAddress_MemberId",
                table: "MemberAddress",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAddress_OrganizationId",
                table: "MemberAddress",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAffliationXRef_AffliationId",
                table: "MemberAffliationXRef",
                column: "AffliationId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAffliationXRef_MemberId",
                table: "MemberAffliationXRef",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberBankingDetail_AccountTypeId",
                table: "MemberBankingDetail",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberBankingDetail_MemberId",
                table: "MemberBankingDetail",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberCommunicationPreference_CommunicationTypeId",
                table: "MemberCommunicationPreference",
                column: "CommunicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberCommunicationPreference_MemberId",
                table: "MemberCommunicationPreference",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberEmailXref_RelatedToId",
                table: "MemberEmailXref",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberFileXref_FileTypeId",
                table: "MemberFileXref",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberFileXref_MemberUserId",
                table: "MemberFileXref",
                column: "MemberUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberFileXref_RelatedToId",
                table: "MemberFileXref",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberNotesXref_RelatedToId",
                table: "MemberNotesXref",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberPlanHistory_MemberId",
                table: "MemberPlanHistory",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberPlanHistory_MemberPlanDetailId",
                table: "MemberPlanHistory",
                column: "MemberPlanDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberPlanHistory_OrganizationId",
                table: "MemberPlanHistory",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberQualificationXRef_MemberId",
                table: "MemberQualificationXRef",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberQualificationXRef_QualificationCategoryId",
                table: "MemberQualificationXRef",
                column: "QualificationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberQualificationXRef_QualificationEnrolmentCategoryId",
                table: "MemberQualificationXRef",
                column: "QualificationEnrolmentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberQualificationXRef_QualificationId",
                table: "MemberQualificationXRef",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberQualificationXRef_QualificationTypeId",
                table: "MemberQualificationXRef",
                column: "QualificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRefereeXref_RelatedToId",
                table: "MemberRefereeXref",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_ApplicaitonUserId",
                table: "MemberUser",
                column: "ApplicaitonUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_ClientBranchId",
                table: "MemberUser",
                column: "ClientBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_CountryId",
                table: "MemberUser",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_EthnicityId",
                table: "MemberUser",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_HighestQualitificationId",
                table: "MemberUser",
                column: "HighestQualitificationId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_HomeLanguageId",
                table: "MemberUser",
                column: "HomeLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_MemberBranchId",
                table: "MemberUser",
                column: "MemberBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_MemberLevelId",
                table: "MemberUser",
                column: "MemberLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_MemberStatusId",
                table: "MemberUser",
                column: "MemberStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_MemberTeamId",
                table: "MemberUser",
                column: "MemberTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_MembershipGradeId",
                table: "MemberUser",
                column: "MembershipGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_MembershipTypeId",
                table: "MemberUser",
                column: "MembershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_OccupationId",
                table: "MemberUser",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_OrganizationId",
                table: "MemberUser",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_OrganizationStructureId",
                table: "MemberUser",
                column: "OrganizationStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_OwnerClientUserId",
                table: "MemberUser",
                column: "OwnerClientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_ParentMemberid",
                table: "MemberUser",
                column: "ParentMemberid");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_PreferredAppointmentTimeId",
                table: "MemberUser",
                column: "PreferredAppointmentTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_ReferralTypeId",
                table: "MemberUser",
                column: "ReferralTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_TransactionCurrencyid",
                table: "MemberUser",
                column: "TransactionCurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_MemberUser_VolunteerWorkHoursId",
                table: "MemberUser",
                column: "VolunteerWorkHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_BillingContactId",
                table: "Organization",
                column: "BillingContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_BusinessId",
                table: "Organization",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_ClientBranchId",
                table: "Organization",
                column: "ClientBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_ContactPersonId",
                table: "Organization",
                column: "ContactPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_MemberLevelId",
                table: "Organization",
                column: "MemberLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_MemberShipGradeId",
                table: "Organization",
                column: "MemberShipGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_MemberStatusId",
                table: "Organization",
                column: "MemberStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_OrganizationGradeId",
                table: "Organization",
                column: "OrganizationGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_OrganizationTypeId",
                table: "Organization",
                column: "OrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_PrimaryContactId",
                table: "Organization",
                column: "PrimaryContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_TransactionCurrencyid",
                table: "Organization",
                column: "TransactionCurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationBusinessXref_BusinessId",
                table: "OrganizationBusinessXref",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationBusinessXref_OrganizationId",
                table: "OrganizationBusinessXref",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMemberShipHistory_MemberShipChangeReasonId",
                table: "OrganizationMemberShipHistory",
                column: "MemberShipChangeReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMemberShipHistory_MemberStatusId",
                table: "OrganizationMemberShipHistory",
                column: "MemberStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMemberShipHistory_OrganizationGradeId",
                table: "OrganizationMemberShipHistory",
                column: "OrganizationGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMemberShipHistory_OrganizationId",
                table: "OrganizationMemberShipHistory",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMemberShipHistory_OrganizationTypeId",
                table: "OrganizationMemberShipHistory",
                column: "OrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSetting_CurrencyId",
                table: "PaymentSetting",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSettingAllowedCard_PaymentCardId",
                table: "PaymentSettingAllowedCard",
                column: "PaymentCardId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSettingAllowedCard_PaymentSettingId",
                table: "PaymentSettingAllowedCard",
                column: "PaymentSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanCanChangeToXref_FromPlanMasterId",
                table: "PlanCanChangeToXref",
                column: "FromPlanMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanCanChangeToXref_ToPlanMasterId",
                table: "PlanCanChangeToXref",
                column: "ToPlanMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_CurrencyId",
                table: "PlanDetail",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_PlanFrequencyId",
                table: "PlanDetail",
                column: "PlanFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_PlanMasterId",
                table: "PlanDetail",
                column: "PlanMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMaster_MembershipTypeId",
                table: "PlanMaster",
                column: "MembershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMaster_PaymentMethodId",
                table: "PlanMaster",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionDetail_MemberLevelId",
                table: "PromotionDetail",
                column: "MemberLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionDetail_MembershipGradeId",
                table: "PromotionDetail",
                column: "MembershipGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionDetail_PromotionMasterId",
                table: "PromotionDetail",
                column: "PromotionMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionMaster_RelatedToId",
                table: "PromotionMaster",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionResponse_MemberId",
                table: "PromotionResponse",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionResponse_PromotionMasterId",
                table: "PromotionResponse",
                column: "PromotionMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionResponse_PromotionResponseType",
                table: "PromotionResponse",
                column: "PromotionResponseType");

            migrationBuilder.CreateIndex(
                name: "IX_Refund_MemberId",
                table: "Refund",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Refund_PaymentGatewayId",
                table: "Refund",
                column: "PaymentGatewayId");

            migrationBuilder.CreateIndex(
                name: "IX_Refund_RelatedToId",
                table: "Refund",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionXRef_Permissionid",
                table: "RolePermissionXRef",
                column: "Permissionid");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionXRef_RoleId",
                table: "RolePermissionXRef",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleXRef_RoleId",
                table: "UserRoleXRef",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleXRef_UserId",
                table: "UserRoleXRef",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberBankingDetail_Member",
                table: "MemberBankingDetail",
                column: "MemberId",
                principalTable: "MemberUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberAddress_Member",
                table: "MemberAddress",
                column: "MemberId",
                principalTable: "MemberUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberAddress_Organization",
                table: "MemberAddress",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberAffliationXRef_Member",
                table: "MemberAffliationXRef",
                column: "MemberId",
                principalTable: "MemberUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Organization",
                table: "MemberUser",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberUser_Organization_ParentMemberid",
                table: "MemberUser",
                column: "ParentMemberid",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberUser_Country_CountryId",
                table: "MemberUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_ClientUser",
                table: "ClientUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_ApplicationUser",
                table: "MemberUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_BillingContact",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_ContactPerson",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_PrimaryContact",
                table: "Organization");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankingDetail");

            migrationBuilder.DropTable(
                name: "BillingCommunication");

            migrationBuilder.DropTable(
                name: "ClientOrganization");

            migrationBuilder.DropTable(
                name: "ClientPlanHistory");

            migrationBuilder.DropTable(
                name: "CommunicationPreference");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "CorrespondenceType");

            migrationBuilder.DropTable(
                name: "CPD");

            migrationBuilder.DropTable(
                name: "CPDMemberLevelSetUp");

            migrationBuilder.DropTable(
                name: "CPDMembershipGradeSetUp");

            migrationBuilder.DropTable(
                name: "CPDMembershipTypeSetUp");

            migrationBuilder.DropTable(
                name: "CPDMemberTeamSetUp");

            migrationBuilder.DropTable(
                name: "CustomField");

            migrationBuilder.DropTable(
                name: "CustomFieldLookUp");

            migrationBuilder.DropTable(
                name: "CustomFieldName");

            migrationBuilder.DropTable(
                name: "DisabilityMemberXref");

            migrationBuilder.DropTable(
                name: "DivisionMemberXref");

            migrationBuilder.DropTable(
                name: "Donation");

            migrationBuilder.DropTable(
                name: "DWSClassMemberXref");

            migrationBuilder.DropTable(
                name: "EmailCCRule");

            migrationBuilder.DropTable(
                name: "EmailTemplateContent");

            migrationBuilder.DropTable(
                name: "EmploymentMemberXref");

            migrationBuilder.DropTable(
                name: "EquipmentCount");

            migrationBuilder.DropTable(
                name: "EventAccess");

            migrationBuilder.DropTable(
                name: "EventAttendance");

            migrationBuilder.DropTable(
                name: "EventCommunication");

            migrationBuilder.DropTable(
                name: "EventCost");

            migrationBuilder.DropTable(
                name: "EventEquipment");

            migrationBuilder.DropTable(
                name: "EventMinute");

            migrationBuilder.DropTable(
                name: "EventPreRequisiteEvent");

            migrationBuilder.DropTable(
                name: "EventRegistration");

            migrationBuilder.DropTable(
                name: "EventRestrictionList");

            migrationBuilder.DropTable(
                name: "EventRoleUserXRef");

            migrationBuilder.DropTable(
                name: "IndividualMemberShipHistory");

            migrationBuilder.DropTable(
                name: "InvoiceSetting");

            migrationBuilder.DropTable(
                name: "InvolvementMemberXref");

            migrationBuilder.DropTable(
                name: "LandingPage");

            migrationBuilder.DropTable(
                name: "MarketingGroupXRef");

            migrationBuilder.DropTable(
                name: "MarketingProfileXRef");

            migrationBuilder.DropTable(
                name: "MemberActivity");

            migrationBuilder.DropTable(
                name: "MemberAddress");

            migrationBuilder.DropTable(
                name: "MemberAffliationXRef");

            migrationBuilder.DropTable(
                name: "MemberBankingDetail");

            migrationBuilder.DropTable(
                name: "MemberCodeGenerator");

            migrationBuilder.DropTable(
                name: "MemberCommunicationPreference");

            migrationBuilder.DropTable(
                name: "MemberEmailXref");

            migrationBuilder.DropTable(
                name: "MemberFileXref");

            migrationBuilder.DropTable(
                name: "MemberLoginAudit");

            migrationBuilder.DropTable(
                name: "MemberNotesXref");

            migrationBuilder.DropTable(
                name: "MemberPlanHistory");

            migrationBuilder.DropTable(
                name: "MemberQualificationXRef");

            migrationBuilder.DropTable(
                name: "MemberRefereeXref");

            migrationBuilder.DropTable(
                name: "OrganizationBusinessXref");

            migrationBuilder.DropTable(
                name: "OrganizationMemberShipHistory");

            migrationBuilder.DropTable(
                name: "PaymentSettingAllowedCard");

            migrationBuilder.DropTable(
                name: "PayPalConnectionMode");

            migrationBuilder.DropTable(
                name: "PayPalPreferredPaymentGateway");

            migrationBuilder.DropTable(
                name: "PlanCanChangeToXref");

            migrationBuilder.DropTable(
                name: "PromotionResponse");

            migrationBuilder.DropTable(
                name: "Refund");

            migrationBuilder.DropTable(
                name: "RolePermissionXRef");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Tax");

            migrationBuilder.DropTable(
                name: "TaxPolicy");

            migrationBuilder.DropTable(
                name: "TaxScope");

            migrationBuilder.DropTable(
                name: "Theme");

            migrationBuilder.DropTable(
                name: "UserActivity");

            migrationBuilder.DropTable(
                name: "UserRoleXRef");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Billing");

            migrationBuilder.DropTable(
                name: "ClientOrganizationGrade");

            migrationBuilder.DropTable(
                name: "DateSetting");

            migrationBuilder.DropTable(
                name: "TimeFormat");

            migrationBuilder.DropTable(
                name: "ContactUsRelatedTo");

            migrationBuilder.DropTable(
                name: "Disability");

            migrationBuilder.DropTable(
                name: "DisabilityLevel");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "PromotionDetail");

            migrationBuilder.DropTable(
                name: "DWSClass");

            migrationBuilder.DropTable(
                name: "EmailType");

            migrationBuilder.DropTable(
                name: "EmailTemplateName");

            migrationBuilder.DropTable(
                name: "EmploymentCategory");

            migrationBuilder.DropTable(
                name: "EventCostItem");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "EventMinuteStatus");

            migrationBuilder.DropTable(
                name: "EventResponseType");

            migrationBuilder.DropTable(
                name: "EventRole");

            migrationBuilder.DropTable(
                name: "Involvement");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "MarketingGroup");

            migrationBuilder.DropTable(
                name: "MarketingProfile");

            migrationBuilder.DropTable(
                name: "Affliation");

            migrationBuilder.DropTable(
                name: "AccountType");

            migrationBuilder.DropTable(
                name: "CommunicationType");

            migrationBuilder.DropTable(
                name: "FileType");

            migrationBuilder.DropTable(
                name: "PlanDetail");

            migrationBuilder.DropTable(
                name: "QualificationCategory");

            migrationBuilder.DropTable(
                name: "QualificationEnrolmentCategory");

            migrationBuilder.DropTable(
                name: "QualificationType");

            migrationBuilder.DropTable(
                name: "MemberShipChangeReason");

            migrationBuilder.DropTable(
                name: "PaymentCard");

            migrationBuilder.DropTable(
                name: "PromotionResponseType");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "PromotionMaster");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "PlanFrequency");

            migrationBuilder.DropTable(
                name: "PlanMaster");

            migrationBuilder.DropTable(
                name: "InvoiceStatus");

            migrationBuilder.DropTable(
                name: "PaymentGateway");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ClientTimeZone");

            migrationBuilder.DropTable(
                name: "PaymentSetting");

            migrationBuilder.DropTable(
                name: "AddressType");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "RelatedTo");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "MemberUser");

            migrationBuilder.DropTable(
                name: "Ethnicity");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "MemberBranch");

            migrationBuilder.DropTable(
                name: "MemberTeam");

            migrationBuilder.DropTable(
                name: "MembershipType");

            migrationBuilder.DropTable(
                name: "Occupation");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "OrganizationStructure");

            migrationBuilder.DropTable(
                name: "ClientUser");

            migrationBuilder.DropTable(
                name: "PreferredContactTime");

            migrationBuilder.DropTable(
                name: "VolunteerHours");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "ClientBranch");

            migrationBuilder.DropTable(
                name: "MemberLevel");

            migrationBuilder.DropTable(
                name: "MembershipGrade");

            migrationBuilder.DropTable(
                name: "MemberStatus");

            migrationBuilder.DropTable(
                name: "OrganizationGrade");

            migrationBuilder.DropTable(
                name: "OrganizationType");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Designation");

            migrationBuilder.DropTable(
                name: "ReferralType");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
