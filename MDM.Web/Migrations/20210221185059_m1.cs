using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MDM.Web.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Block",
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
                    table.PrimaryKey("PK_Block", x => x.Id);
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
                name: "Floor",
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
                    table.PrimaryKey("PK_Floor", x => x.Id);
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
                name: "Group",
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
                    table.PrimaryKey("PK_Group", x => x.Id);
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
                name: "Portfolio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.Id);
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
                name: "ServiceProvider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    plumbing = table.Column<bool>(nullable: false),
                    electrician = table.Column<bool>(nullable: false),
                    dstv = table.Column<bool>(nullable: false),
                    horticulturist = table.Column<bool>(nullable: false),
                    buildingrenovation = table.Column<bool>(nullable: false),
                    painting = table.Column<bool>(nullable: false),
                    waterproofing = table.Column<bool>(nullable: false),
                    csddocuments = table.Column<bool>(nullable: false),
                    taxcertificate = table.Column<bool>(nullable: false),
                    beecertificate = table.Column<bool>(nullable: false),
                    accreditation = table.Column<bool>(nullable: false),
                    coideclaration = table.Column<bool>(nullable: false),
                    signedselfassesmentform = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
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
                    table.PrimaryKey("PK_Status", x => x.Id);
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
                        name: "FK_ContactUs_ContactUsRelatedTo",
                        column: x => x.ContactUsRelatedToId,
                        principalTable: "ContactUsRelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Province",
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
                    table.PrimaryKey("PK_Province", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Province_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    No = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    FloorId = table.Column<int>(nullable: true),
                    BlockId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Block",
                        column: x => x.BlockId,
                        principalTable: "Block",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Unit_Floor",
                        column: x => x.FloorId,
                        principalTable: "Floor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    HomeLanguageId = table.Column<int>(nullable: true),
                    EthnicityId = table.Column<int>(nullable: true),
                    OccupationId = table.Column<int>(nullable: true),
                    Initials = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    TermAccepted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true),
                    Photo = table.Column<byte[]>(type: "blob", nullable: true),
                    IDNumber = table.Column<string>(maxLength: 100, nullable: true),
                    IsAdminCreated = table.Column<bool>(nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime", nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    TitleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Ethnicity",
                        column: x => x.EthnicityId,
                        principalTable: "Ethnicity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Gender",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_Language",
                        column: x => x.HomeLanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_Occupation",
                        column: x => x.OccupationId,
                        principalTable: "Occupation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Title",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 50, nullable: true),
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
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true),
                    UserTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_UserType_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    BuildingName = table.Column<string>(nullable: true),
                    ComplexName = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    PostalCode = table.Column<string>(maxLength: 50, nullable: true),
                    AdditionalLine1 = table.Column<string>(nullable: true),
                    AdditionalLine2 = table.Column<string>(nullable: true),
                    PrimaryContactNo = table.Column<string>(maxLength: 50, nullable: true),
                    SecondaryContactNo = table.Column<string>(maxLength: 50, nullable: true),
                    PrimaryEmail = table.Column<string>(maxLength: 50, nullable: true),
                    SecondaryEmail = table.Column<string>(maxLength: 50, nullable: true),
                    GPSCoordinates = table.Column<string>(maxLength: 50, nullable: true),
                    CityName = table.Column<string>(nullable: true),
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
                        name: "FK_Address_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Province",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_RelatedTo",
                        column: x => x.RelatedToId,
                        principalTable: "RelatedTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 1500, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DueOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ClosedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ProgressPercentage = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    PriorityId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    GroupId = table.Column<int>(nullable: true),
                    UnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItem_Group",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskItem_Priority",
                        column: x => x.PriorityId,
                        principalTable: "Priority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskItem_Status",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskItem_Unit",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(nullable: false),
                    isCurrent = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    From = table.Column<DateTime>(type: "datetime", nullable: true),
                    To = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    PortfolioId = table.Column<int>(nullable: true),
                    SystemUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Board_Portfolio",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Board_SystemUser",
                        column: x => x.SystemUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderTrusteeApproval",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ServiceProviderId = table.Column<int>(nullable: true),
                    SystemUserId = table.Column<int>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false),
                    DecisionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderTrusteeApproval", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderTrusteeApproval_ServiceProvider",
                        column: x => x.ServiceProviderId,
                        principalTable: "ServiceProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceProviderTrusteeApproval_SystemUser",
                        column: x => x.SystemUserId,
                        principalTable: "SystemUser",
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
                name: "TaskItemAssignee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TaskItemId = table.Column<int>(nullable: true),
                    SystemUserId = table.Column<int>(nullable: true),
                    AssignedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItemAssignee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItemAssignee_AssignedByUser",
                        column: x => x.AssignedByUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskItemAssignee_TaskItem",
                        column: x => x.TaskItemId,
                        principalTable: "TaskItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskItemComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TaskItemId = table.Column<int>(nullable: true),
                    SystemUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(maxLength: 2000, nullable: false),
                    FileTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItemComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItemComment_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskItemComment_SystemUser",
                        column: x => x.SystemUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskItemComment_TaskItem",
                        column: x => x.TaskItemId,
                        principalTable: "TaskItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskItemFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TaskItemId = table.Column<int>(nullable: true),
                    SystemUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    FileTypeId = table.Column<int>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItemFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItemFile_FileType",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskItemFile_SystemUser",
                        column: x => x.SystemUserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskItemFile_TaskItem",
                        column: x => x.TaskItemId,
                        principalTable: "TaskItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AddressType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Postal Address" },
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Physical Address" },
                    { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Billing Address" },
                    { 4, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Business Address" },
                    { 5, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipping Address" },
                    { 6, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contact Address" },
                    { 7, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Venue" }
                });

            migrationBuilder.InsertData(
                table: "Block",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 18, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block18" },
                    { 19, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block19" },
                    { 20, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block20" },
                    { 21, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block21" },
                    { 22, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block22" },
                    { 23, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block23" },
                    { 26, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block26" },
                    { 25, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block25" },
                    { 17, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block17" },
                    { 27, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block27" },
                    { 29, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block29" },
                    { 30, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block30" },
                    { 24, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block24" },
                    { 16, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block16" },
                    { 28, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block28" },
                    { 14, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block14" },
                    { 13, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block13" },
                    { 12, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block12" },
                    { 11, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block11" },
                    { 10, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block10" },
                    { 9, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block9" },
                    { 8, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block8" },
                    { 7, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block7" },
                    { 6, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block6" },
                    { 5, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block5" },
                    { 4, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block4" },
                    { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block3" },
                    { 15, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block15" },
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block2" },
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block1" }
                });

            migrationBuilder.InsertData(
                table: "ContactUsRelatedTo",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Registration" },
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membership" },
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Events" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 178, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pitcairn", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pitcairn" },
                    { 166, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norfolk Island", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norfolk Island" },
                    { 167, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Korean", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Korea" },
                    { 168, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Northern Mariana Islands", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Northern Mariana Islands" },
                    { 169, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norwegian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway" },
                    { 170, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omani", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oman" },
                    { 165, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niue", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niue" },
                    { 171, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pakistani", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pakistan" },
                    { 172, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palau", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palau" },
                    { 173, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palestine", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palestine" },
                    { 174, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panamanian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panama" },
                    { 176, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paraguayan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paraguay" },
                    { 177, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peruvian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peru" },
                    { 179, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Polish", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poland" },
                    { 188, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Helena", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Helena" },
                    { 181, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Puerto Rico", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Puerto Rico" },
                    { 182, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qatari", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qatar" },
                    { 183, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Réunion", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Réunion" },
                    { 184, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romanian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romania" },
                    { 185, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Russian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Russia" },
                    { 186, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rwandan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rwanda" },
                    { 187, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Barthélemy", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Barthélemy" },
                    { 189, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Kitts and Nevis", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Kitts and Nevis" },
                    { 190, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Lucia", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Lucia" },
                    { 191, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Martin (French part)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Martin (French part)" },
                    { 192, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Pierre and Miquelon", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Pierre and Miquelon" },
                    { 193, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Vincent and the Grenadines", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Vincent and the Grenadines" },
                    { 164, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nigerian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nigeria" },
                    { 180, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portuguese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portugal" },
                    { 163, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nigerien", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niger" },
                    { 143, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martinique", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martinique" },
                    { 161, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealander", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealand" },
                    { 132, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lithuanian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lithuania" },
                    { 133, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luxembourger", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luxembourg" },
                    { 134, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macao", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macao" },
                    { 135, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macedonian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macedonia" },
                    { 136, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madagascan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madagascar" },
                    { 137, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malawian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malawi" },
                    { 138, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malaysian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malaysia" },
                    { 139, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maldivian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maldives" },
                    { 140, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mali" },
                    { 141, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maltese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta" },
                    { 142, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marshall Islands", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marshall Islands" },
                    { 194, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samoa", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samoa" },
                    { 144, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritanian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritania" },
                    { 145, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritius" },
                    { 146, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mayotte", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mayotte" },
                    { 147, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexican", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico" },
                    { 148, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Micronesia", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Micronesia" },
                    { 149, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moldovan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moldova" },
                    { 150, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monacan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monaco" },
                    { 151, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mongolian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mongolia" },
                    { 152, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montenegrin", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montenegro" },
                    { 153, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montserrat", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montserrat" },
                    { 154, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moroccan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morocco" },
                    { 155, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mozambican", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mozambique" },
                    { 156, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burmese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Myanmar" },
                    { 157, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nauru", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nauru" },
                    { 158, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nepalese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nepal" },
                    { 159, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dutch", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Netherlands" },
                    { 160, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Caledonia", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Caledonia" },
                    { 162, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicaraguan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicaragua" },
                    { 195, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Marino", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Marino" },
                    { 215, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surinamese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suriname" },
                    { 197, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saudi Arabian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saudi Arabia" },
                    { 231, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tunisian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tunisia" },
                    { 232, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkish", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkey" },
                    { 233, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkmen or Turkoman", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkmenistan" },
                    { 234, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turks and Caicos Islands", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turks and Caicos Islands" },
                    { 235, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuvaluan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuvalu" },
                    { 236, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ugandan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uganda" },
                    { 237, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ukrainian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ukraine" },
                    { 238, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emirati", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Arab Emirates" },
                    { 239, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Briton", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" },
                    { 240, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States Minor Outlying Islands", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States Minor Outlying Islands" },
                    { 241, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US citizen", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States of America" },
                    { 242, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uruguayan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uruguay" },
                    { 243, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzbek", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzbekistan" },
                    { 230, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trinidadian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trinidad and Tobago" },
                    { 244, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vanuatuan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vanuatu" },
                    { 246, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Venezuelan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Venezuela" },
                    { 247, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vietnamese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "VietNam" },
                    { 248, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virgin Islands -U.S.", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virgin Islands -U.S." },
                    { 249, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virgin Islands-British", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virgin Islands-British" },
                    { 250, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welsh", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wales" },
                    { 251, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wallis and Futuna", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wallis and Futuna" },
                    { 252, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western Sahara", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western Sahara" },
                    { 253, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western Samoan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western Samoa" },
                    { 254, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yemeni", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yemen" },
                    { 255, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yugoslav", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yugoslavia" },
                    { 256, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zaïrean", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zaire" },
                    { 257, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zambian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zambia" },
                    { 258, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zimbabwean", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zimbabwe" },
                    { 245, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vatican", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vatican City" },
                    { 229, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tonga", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tonga" },
                    { 228, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tokelau", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tokelau" },
                    { 227, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Togolese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Togo" },
                    { 198, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scottish", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scotland" },
                    { 199, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senegalese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senegal" },
                    { 200, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serb or Serbian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serbia" },
                    { 201, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seychellois", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seychelles" },
                    { 202, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sierra Leonian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sierra Leone" },
                    { 203, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singaporean", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore" },
                    { 204, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sint Maarten (Dutch part)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sint Maarten (Dutch part)" },
                    { 205, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovak", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovakia" },
                    { 206, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovenian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovenia" },
                    { 207, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solomon Islander", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solomon Islands" },
                    { 208, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Somali", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Somalia" },
                    { 209, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Georgia and the South Sandwich Islands", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Georgia and the South Sandwich Islands" },
                    { 210, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Korean", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Korea" },
                    { 211, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Sudan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Sudan" },
                    { 212, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spanish", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain" },
                    { 213, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sri Lankan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sri Lanka" },
                    { 214, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sudanese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sudan" },
                    { 131, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liechtensteiner", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liechtenstein" },
                    { 216, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Svalbard and Jan Mayen", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Svalbard and Jan Mayen" },
                    { 217, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swazi", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SWAZILAND" },
                    { 218, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swedish", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweden" },
                    { 219, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swiss", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Switzerland" },
                    { 220, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Syrian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Syria" },
                    { 221, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taiwanese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taiwan" },
                    { 222, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tajik or Tadjik", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tajikistan" },
                    { 223, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tanzanian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tanzania" },
                    { 224, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thai", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thailand" },
                    { 225, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Philippine", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Philippines" },
                    { 226, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Timor-Leste", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Timor-Leste" },
                    { 196, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sao Tome and Principe", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sao Tome and Principe" },
                    { 130, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Libyan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Libya" },
                    { 175, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Papua New Guinean", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Papua New Guinea" },
                    { 128, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lesotho", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lesotho" },
                    { 34, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brazilian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brazil" },
                    { 35, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "British Indian Ocean Territory", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "British Indian Ocean Territory" },
                    { 36, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bruneian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brunei" },
                    { 37, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bulgarian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bulgaria" },
                    { 38, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burkinese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burkina Faso" },
                    { 39, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burundian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burundi" },
                    { 40, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cambodian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cambodia" },
                    { 41, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cameroonian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cameroon" },
                    { 42, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canadian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canada" },
                    { 43, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cape Verdean", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cape Verde Islands" },
                    { 44, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cayman Islands", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cayman Islands" },
                    { 45, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central African Republic", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central African Republic" },
                    { 46, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chadian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chad" },
                    { 32, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botswanan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botswana" },
                    { 47, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chilean", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chile" },
                    { 49, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas Island", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas Island" },
                    { 50, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cocos (Keeling) Islands", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cocos (Keeling) Islands" },
                    { 51, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colombian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colombia" },
                    { 52, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comoros", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comoros" },
                    { 53, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Congolese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Congo" },
                    { 55, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cook Islands", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cook Islands" },
                    { 56, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Costa Rican", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Costa Rica" },
                    { 57, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Côte d'Ivoire", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Côte d'Ivoire" },
                    { 58, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Croatian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Croatia" },
                    { 59, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cuban", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cuba" },
                    { 60, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Curaçao", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Curaçao" },
                    { 61, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cypriot", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyprus" },
                    { 62, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Czech", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Czech Republic" },
                    { 48, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chinese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "China" },
                    { 31, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bosnian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bosnia-Herzegovina" },
                    { 30, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bonaire", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bonaire" },
                    { 29, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bolivian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bolivia" },
                    { 129, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liberian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liberia" },
                    { 1, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "South African", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Africa" },
                    { 2, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Namibian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Namibia" },
                    { 3, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afghan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afghanistan" },
                    { 4, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Åland Islands", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Åland Islands" },
                    { 5, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Albanian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Albania" },
                    { 6, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Algerian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Algeria" },
                    { 7, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "American Samoa", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "American Samoa" },
                    { 8, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andorran", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andorra" },
                    { 9, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angolan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angola" },
                    { 10, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anguilla", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anguilla" },
                    { 11, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antarctica", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antarctica" },
                    { 12, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antigua and Barbuda", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antigua and Barbuda" },
                    { 13, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Argentinian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Argentina" },
                    { 14, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Armenian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Armenia" },
                    { 15, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aruba", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aruba" },
                    { 16, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia" },
                    { 17, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Austrian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Austria" },
                    { 18, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azerbaijani", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azerbaijan" },
                    { 19, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahamian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahamas" },
                    { 20, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahraini", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahrain" },
                    { 21, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bangladeshi", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bangladesh" },
                    { 22, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barbadian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barbados" },
                    { 23, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belarusan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belarus" },
                    { 24, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belgian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belgium" },
                    { 25, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belizean", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belize" },
                    { 26, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beninese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benin" },
                    { 27, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bermuda", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bermuda" },
                    { 28, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bhutanese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bhutan" },
                    { 63, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danish", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denmark" },
                    { 64, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Djiboutian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Djibouti" },
                    { 33, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bouvet Island", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bouvet Island" },
                    { 66, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominican", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominican Republic" },
                    { 99, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guyanese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guyana" },
                    { 100, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haitian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haiti" },
                    { 101, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heard Island and McDonald Islands", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heard Island and McDonald Islands" },
                    { 102, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Holy See", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Holy See" },
                    { 103, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honduran", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honduras" },
                    { 104, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong" },
                    { 105, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hungarian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hungary" },
                    { 106, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Icelandic", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iceland" },
                    { 107, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "India" },
                    { 108, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indonesian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indonesia" },
                    { 109, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iranian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iran" },
                    { 111, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Irish", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ireland" },
                    { 112, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isle of Man", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isle of Man" },
                    { 113, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Israel", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Israel" },
                    { 114, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy" },
                    { 115, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamaican", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamaica" },
                    { 116, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japanese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japan" },
                    { 117, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jersey", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jersey" },
                    { 118, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordanian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordan" },
                    { 119, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kazakh", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kazakhstan" },
                    { 120, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kenyan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kenya" },
                    { 121, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiribati", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiribati" },
                    { 122, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuwaiti", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuwait" },
                    { 123, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyrgyzstan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyrgyzstan" },
                    { 124, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lao People's Democratic Republic", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lao People's Democratic Republic" },
                    { 125, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laotian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laos" },
                    { 126, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Latvian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Latvia" },
                    { 65, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominican", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominica" },
                    { 127, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lebanese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lebanon" },
                    { 98, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guinea-Bissau", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guinea-Bissau" },
                    { 97, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guinean", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guinea" },
                    { 110, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iraqi", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iraq" },
                    { 95, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guatemalan", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guatemala" },
                    { 67, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ecuadorean", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ecuador" },
                    { 96, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guernsey", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guernsey" },
                    { 69, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egyptian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egypt" },
                    { 70, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salvadorean", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "El Salvador" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 71, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Equatorial Guinea", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Equatorial Guinea" },
                    { 72, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eritrean", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eritrea" },
                    { 73, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estonian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estonia" },
                    { 74, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eswatini", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eswatini" },
                    { 75, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethiopian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethiopia" },
                    { 76, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Falkland Islands", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Falkland Islands [Malvinas]" },
                    { 77, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faroe Islands", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faroe Islands" },
                    { 78, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fijian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fiji" },
                    { 79, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finnish", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finland" },
                    { 80, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "French", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "France" },
                    { 81, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Guiana", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Guiana" },
                    { 68, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egyptian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egypt" },
                    { 83, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Southern Territories", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Southern Territories" },
                    { 82, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Polynesia", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Polynesia" },
                    { 93, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guadeloupe", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guadeloupe" },
                    { 92, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grenadian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grenada" },
                    { 91, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greenland", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greenland" },
                    { 90, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greek", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece" },
                    { 89, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gibraltar", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gibraltar" },
                    { 94, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guam", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guam" },
                    { 87, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "German", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Germany" },
                    { 86, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgia" },
                    { 85, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gambian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gambia" },
                    { 84, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabonese", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabon" },
                    { 88, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghanaian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghana" }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name", "Symbol" },
                values: new object[,]
                {
                    { 179, "PAB", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "PANAMA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Balboa", " " },
                    { 178, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "PALAU", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 177, "PKR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "PAKISTAN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pakistan Rupee", " " },
                    { 176, "OMR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "OMAN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rial Omani", " " },
                    { 175, "NOK", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "NORWAY", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norwegian Krone", " " },
                    { 173, "AUD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "NORFOLK ISLAND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 172, "NZD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "NIUE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealand Dollar", " " },
                    { 171, "NGN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "NIGERIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Naira", " " },
                    { 170, "XOF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "NIGER (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 180, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "PANAMA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 168, "NZD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW ZEALAND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealand Dollar", " " },
                    { 169, "NIO", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "NICARAGUA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cordoba Oro", " " },
                    { 174, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "NORTHERN MARIANA ISLANDS (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 181, "PGK", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "PAPUA NEW GUINEA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kina", " " },
                    { 188, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "PUERTO RICO", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 183, "PEN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "PERU", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nuevo Sol", " " },
                    { 184, "PHP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "PHILIPPINES (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Philippine Peso", " " },
                    { 185, "NZD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "PITCAIRN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealand Dollar", " " },
                    { 186, "PLN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "POLAND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zloty", " " },
                    { 187, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "PORTUGAL", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 189, "QAR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "QATAR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qatari Rial", " " },
                    { 190, "MKD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "REPUBLIC OF NORTH MACEDONIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denar", " " },
                    { 191, "RON", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ROMANIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romanian Leu", " " },
                    { 192, "RUB", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "RUSSIAN FEDERATION (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Russian Ruble", " " },
                    { 193, "RWF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "RWANDA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rwanda Franc", " " },
                    { 194, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "RÉUNION", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 195, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAINT BARTHÉLEMY", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 196, "SHP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAINT HELENA, ASCENSION AND TRISTAN DA CUNHA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Helena Pound", " " },
                    { 167, "XPF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW CALEDONIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFP Franc", " " },
                    { 182, "PYG", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "PARAGUAY", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guarani", " " },
                    { 166, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "NETHERLANDS (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 136, "CHF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "LIECHTENSTEIN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swiss Franc", " " },
                    { 164, "AUD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "NAURU", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 135, "LYD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "LIBYA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Libyan Dinar", " " },
                    { 197, "XCD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAINT KITTS AND NEVIS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 137, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "LITHUANIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 138, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "LUXEMBOURG", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 139, "MOP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MACAO", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pataca", " " },
                    { 140, "MGA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MADAGASCAR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malagasy Ariary", " " },
                    { 141, "MWK", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MALAWI", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kwacha", " " },
                    { 142, "MYR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MALAYSIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malaysian Ringgit", " " },
                    { 143, "MVR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MALDIVES", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rufiyaa", " " },
                    { 144, "XOF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MALI", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 145, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MALTA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 146, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MARSHALL ISLANDS (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 147, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MARTINIQUE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 148, "MRU", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAURITANIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ouguiya", " " },
                    { 149, "MUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAURITIUS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritius Rupee", " " },
                    { 150, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAYOTTE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 151, "MXN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MEXICO", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexican Peso", " " },
                    { 152, "MXV", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MEXICO", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexican Unidad de Inversion (UDI)", " " },
                    { 153, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MICRONESIA (FEDERATED STATES OF)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 154, "MDL", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MOLDOVA (THE REPUBLIC OF)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moldovan Leu", " " },
                    { 155, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MONACO", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 156, "MNT", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MONGOLIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tugrik", " " },
                    { 157, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MONTENEGRO", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 158, "XCD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MONTSERRAT", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 159, "MAD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MOROCCO", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moroccan Dirham", " " },
                    { 160, "MZN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MOZAMBIQUE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mozambique Metical", " " },
                    { 161, "MMK", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "MYANMAR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyat", " " },
                    { 162, "NAD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "NAMIBIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Namibia Dollar", " " },
                    { 163, "ZAR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "NAMIBIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rand", " " },
                    { 165, "NPR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEPAL", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nepalese Rupee", " " },
                    { 198, "XCD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAINT LUCIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 262, "ZWL", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZIMBABWE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zimbabwe Dollar", " " },
                    { 200, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAINT PIERRE AND MIQUELON", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 235, "NZD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TOKELAU", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealand Dollar", " " },
                    { 236, "TOP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TONGA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pa’anga", " " },
                    { 237, "TTD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TRINIDAD AND TOBAGO", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trinidad and Tobago Dollar", " " },
                    { 238, "TND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TUNISIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tunisian Dinar", " " },
                    { 239, "TRY", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TURKEY", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkish Lira", " " },
                    { 240, "TMT", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TURKMENISTAN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkmenistan New Manat", " " },
                    { 241, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TURKS AND CAICOS ISLANDS (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 242, "AUD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TUVALU", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 243, "UGX", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "UGANDA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uganda Shilling", " " },
                    { 244, "UAH", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "UKRAINE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hryvnia", " " },
                    { 245, "AED", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNITED ARAB EMIRATES (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "UAE Dirham", " " },
                    { 246, "GBP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNITED KINGDOM OF GREAT BRITAIN AND NORTHERN IRELAND (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pound Sterling", " " },
                    { 247, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNITED STATES MINOR OUTLYING ISLANDS (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 248, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNITED STATES OF AMERICA (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 249, "USN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNITED STATES OF AMERICA (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar (Next day)", " " },
                    { 250, "UYI", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "URUGUAY", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uruguay Peso en Unidades Indexadas (URUIURUI)", " " },
                    { 251, "UYU", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "URUGUAY", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peso Uruguayo", " " },
                    { 252, "UZS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "UZBEKISTAN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzbekistan Sum", " " },
                    { 253, "VUV", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "VANUATU", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vatu", " " },
                    { 254, "VEF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "VENEZUELA (BOLIVARIAN REPUBLIC OF)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bolivar", " " },
                    { 255, "VND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "VIET NAM", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dong", " " },
                    { 256, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "VIRGIN ISLANDS (BRITISH)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 257, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "VIRGIN ISLANDS (U.S.)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 258, "XPF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "WALLIS AND FUTUNA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFP Franc", " " },
                    { 259, "MAD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "WESTERN SAHARA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moroccan Dirham", " " },
                    { 260, "YER", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "YEMEN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yemeni Rial", " " },
                    { 261, "ZMW", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZAMBIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zambian Kwacha", " " },
                    { 263, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ÅLAND ISLANDS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 134, "LRD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "LIBERIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liberian Dollar", " " },
                    { 234, "XOF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TOGO", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 233, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TIMOR-LESTE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 232, "THB", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "THAILAND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Baht", " " },
                    { 231, "TZS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TANZANIA, UNITED REPUBLIC OF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tanzanian Shilling", " " },
                    { 201, "XCD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAINT VINCENT AND THE GRENADINES", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 202, "WST", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAMOA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tala", " " },
                    { 203, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAN MARINO", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 204, "STN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAO TOME AND PRINCIPE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dobra", " " },
                    { 205, "SAR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAUDI ARABIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saudi Riyal", " " },
                    { 206, "XOF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SENEGAL", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 207, "RSD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SERBIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serbian Dinar", " " },
                    { 208, "SCR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEYCHELLES", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seychelles Rupee", " " },
                    { 209, "SLL", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SIERRA LEONE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leone", " " },
                    { 210, "SGD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SINGAPORE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore Dollar", " " },
                    { 211, "ANG", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SINT MAARTEN (DUTCH PART)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Netherlands Antillean Guilder", " " },
                    { 212, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLOVAKIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 213, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLOVENIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 214, "SBD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SOLOMON ISLANDS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solomon Islands Dollar", " " },
                    { 199, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAINT MARTIN (FRENCH PART)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 215, "SOS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SOMALIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Somali Shilling", " " },
                    { 217, "SSP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SOUTH SUDAN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Sudanese Pound", " " },
                    { 218, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SPAIN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 219, "LKR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SRI LANKA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sri Lanka Rupee", " " },
                    { 220, "SDG", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SUDAN (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sudanese Pound", " " },
                    { 221, "SRD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SURINAME", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surinam Dollar", " " },
                    { 222, "NOK", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SVALBARD AND JAN MAYEN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norwegian Krone", " " },
                    { 223, "SZL", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SWAZILAND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lilangeni", " " },
                    { 224, "SEK", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SWEDEN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swedish Krona", " " },
                    { 225, "CHE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SWITZERLAND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "WIR Euro", " " },
                    { 226, "CHF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SWITZERLAND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swiss Franc", " " },
                    { 227, "CHW", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SWITZERLAND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "WIR Franc", " " },
                    { 228, "SYP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SYRIAN ARAB REPUBLIC", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Syrian Pound", " " },
                    { 229, "TWD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TAIWAN (PROVINCE OF CHINA)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Taiwan Dollar", " " },
                    { 230, "TJS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TAJIKISTAN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Somoni", " " },
                    { 216, "ZAR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SOUTH AFRICA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rand", " " },
                    { 133, "ZAR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "LESOTHO", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rand", " " },
                    { 91, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GREECE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 131, "LBP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "LEBANON", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lebanese Pound", " " },
                    { 34, "BND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BRUNEI DARUSSALAM", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brunei Dollar", " " },
                    { 35, "BGN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BULGARIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bulgarian Lev", " " },
                    { 36, "XOF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BURKINA FASO", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 37, "BIF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BURUNDI", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burundi Franc", " " },
                    { 38, "CVE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CABO VERDE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cabo Verde Escudo", " " },
                    { 39, "KHR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAMBODIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riel", " " },
                    { 40, "XAF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAMEROON", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BEAC", " " },
                    { 41, "CAD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CANADA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canadian Dollar", " " },
                    { 42, "KYD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAYMAN ISLANDS (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cayman Islands Dollar", " " },
                    { 44, "XAF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHAD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BEAC", " " },
                    { 45, "CLF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHILE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unidad de Fomento", " " },
                    { 46, "CLP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHILE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chilean Peso", " " },
                    { 47, "CNY", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHINA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yuan Renminbi", " " },
                    { 48, "AUD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHRISTMAS ISLAND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 49, "AUD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "COCOS (KEELING) ISLANDS (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 50, "COP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "COLOMBIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colombian Peso", " " },
                    { 51, "COU", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "COLOMBIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unidad de Valor Real", " " },
                    { 52, "KMF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMOROS (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comoro Franc", " " },
                    { 53, "CDF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CONGO (THE DEMOCRATIC REPUBLIC OF THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Congolese Franc", " " },
                    { 54, "XAF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CONGO (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BEAC", " " },
                    { 55, "NZD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "COOK ISLANDS (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealand Dollar", " " },
                    { 56, "CRC", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "COSTA RICA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Costa Rican Colon", " " },
                    { 57, "HRK", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CROATIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuna", " " },
                    { 58, "CUC", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUBA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peso Convertible", " " },
                    { 59, "CUP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUBA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cuban Peso", " " },
                    { 60, "ANG", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CURAÇAO", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Netherlands Antillean Guilder", " " },
                    { 61, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CYPRUS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 62, "CZK", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CZECH REPUBLIC (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Czech Koruna", " " },
                    { 63, "XOF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CÔTE D'IVOIRE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 33, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BRITISH INDIAN OCEAN TERRITORY (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 32, "BRL", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BRAZIL", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brazilian Real", " " },
                    { 31, "NOK", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOUVET ISLAND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norwegian Krone", " " },
                    { 30, "BWP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOTSWANA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pula", " " },
                    { 132, "LSL", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "LESOTHO", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loti", " " },
                    { 1, "AFN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Currency for  AFGHANISTAN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afghani", " " },
                    { 2, "ALL", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALBANIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lek", " " },
                    { 3, "DZD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALGERIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Algerian Dinar", " " },
                    { 4, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "AMERICAN SAMOA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 5, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANDORRA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 6, "AOA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANGOLA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kwanza", " " },
                    { 7, "XCD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANGUILLA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 8, "XCD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANTIGUA AND BARBUDA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 9, "ARS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ARGENTINA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Argentine Peso", "" },
                    { 10, "AMD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ARMENIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Armenian Dram", " " },
                    { 11, "AWG", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ARUBA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aruban Florin", " " },
                    { 12, "AUD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUSTRALIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 13, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUSTRIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 64, "DKK", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "DENMARK", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danish Krone", " " },
                    { 14, "AZN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "AZERBAIJAN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azerbaijanian Manat", " " },
                    { 16, "BHD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BAHRAIN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahraini Dinar", " " },
                    { 17, "BDT", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BANGLADESH", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taka", " " },
                    { 18, "BBD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BARBADOS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barbados Dollar", " " },
                    { 19, "BYN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BELARUS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belarussian Ruble", " " },
                    { 20, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BELGIUM", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 21, "BZD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BELIZE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belize Dollar", " " },
                    { 22, "XOF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BENIN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 23, "BMD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BERMUDA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bermudian Dollar", " " },
                    { 24, "BTN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BHUTAN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngultrum", " " },
                    { 25, "INR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BHUTAN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indian Rupee", " " },
                    { 26, "BOB", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOLIVIA (PLURINATIONAL STATE OF)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boliviano", " " },
                    { 27, "BOV", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOLIVIA (PLURINATIONAL STATE OF)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mvdol", " " },
                    { 28, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BONAIRE, SINT EUSTATIUS AND SABA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 29, "BAM", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOSNIA AND HERZEGOVINA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Convertible Mark", " " },
                    { 15, "BSD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "BAHAMAS (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahamian Dollar", " " },
                    { 65, "DJF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "DJIBOUTI", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Djibouti Franc", " " },
                    { 43, "XAF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CENTRAL AFRICAN REPUBLIC (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BEAC", " " },
                    { 67, "DOP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOMINICAN REPUBLIC (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominican Peso", " " },
                    { 101, "HTG", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "HAITI", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gourde", " " },
                    { 102, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "HAITI", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 103, "AUD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "HEARD ISLAND AND McDONALD ISLANDS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 104, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "HOLY SEE (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 105, "HNL", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "HONDURAS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lempira", " " },
                    { 106, "HKD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "HONG KONG", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong Dollar", " " },
                    { 107, "HUF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "HUNGARY", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forint", " " },
                    { 108, "ISK", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ICELAND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iceland Krona", " " },
                    { 109, "INR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "INDIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indian Rupee", " " },
                    { 110, "IDR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "INDONESIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rupiah", " " }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name", "Symbol" },
                values: new object[,]
                {
                    { 111, "XDR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "INTERNATIONAL MONETARY FUND (IMF) ", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SDR (Special Drawing Right)", " " },
                    { 112, "IRR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "IRAN (ISLAMIC REPUBLIC OF)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iranian Rial", " " },
                    { 113, "IQD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "IRAQ", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iraqi Dinar", " " },
                    { 114, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "IRELAND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 100, "GYD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GUYANA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guyana Dollar", " " },
                    { 115, "GBP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISLE OF MAN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pound Sterling", " " },
                    { 117, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ITALY", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 118, "JMD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "JAMAICA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamaican Dollar", " " },
                    { 119, "JPY", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "JAPAN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yen", " " },
                    { 120, "GBP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "JERSEY", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pound Sterling", " " },
                    { 66, "XCD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOMINICA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 122, "KZT", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "KAZAKHSTAN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tenge", " " },
                    { 123, "KES", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "KENYA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kenyan Shilling", " " },
                    { 124, "AUD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "KIRIBATI", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australian Dollar", " " },
                    { 125, "KPW", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "KOREA (THE DEMOCRATIC PEOPLE’S REPUBLIC OF)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Korean Won", " " },
                    { 126, "KRW", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "KOREA (THE REPUBLIC OF)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Won", " " },
                    { 127, "KWD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "KUWAIT", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuwaiti Dinar", " " },
                    { 128, "KGS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "KYRGYZSTAN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Som", " " },
                    { 129, "LAK", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "LAO PEOPLE’S DEMOCRATIC REPUBLIC (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kip", " " },
                    { 130, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "LATVIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 116, "ILS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISRAEL", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Israeli Sheqel", " " },
                    { 99, "XOF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GUINEA-BISSAU", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BCEAO", " " },
                    { 121, "JOD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "JORDAN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordanian Dinar", " " },
                    { 97, "GBP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GUERNSEY", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pound Sterling", " " },
                    { 69, "EGP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "EGYPT", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egyptian Pound", " " },
                    { 70, "SVC", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "EL SALVADOR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "El Salvador Colon", " " },
                    { 71, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "EL SALVADOR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 72, "XAF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "EQUATORIAL GUINEA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BEAC", " " },
                    { 73, "ERN", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ERITREA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nakfa", " " },
                    { 74, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ESTONIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 75, "ETB", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ETHIOPIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethiopian Birr", " " },
                    { 76, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUROPEAN UNION", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 77, "FKP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FALKLAND ISLANDS (THE) [MALVINAS]", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Falkland Islands Pound", " " },
                    { 78, "DKK", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FAROE ISLANDS (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danish Krone", " " },
                    { 80, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FINLAND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 81, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FRANCE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 82, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FRENCH GUIANA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 83, "XPF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FRENCH POLYNESIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFP Franc", " " },
                    { 79, "FJD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FIJI", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fiji Dollar", " " },
                    { 85, "XAF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GABON", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CFA Franc BEAC", " " },
                    { 96, "GTQ", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GUATEMALA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quetzal", " " },
                    { 95, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GUAM", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 84, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FRENCH SOUTHERN TERRITORIES (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 93, "XCD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GRENADA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Caribbean Dollar", " " },
                    { 92, "DKK", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GREENLAND", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danish Krone", " " },
                    { 68, "USD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ECUADOR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "US Dollar", " " },
                    { 94, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GUADELOUPE", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 89, "GHS", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GHANA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghana Cedi", " " },
                    { 88, "EUR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GERMANY", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euro", " " },
                    { 87, "GEL", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GEORGIA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lari", " " },
                    { 86, "GMD", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GAMBIA (THE)", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dalasi", " " },
                    { 90, "GIP", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GIBRALTAR", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gibraltar Pound", " " },
                    { 98, "GNF", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GUINEA", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guinea Franc", " " }
                });

            migrationBuilder.InsertData(
                table: "Ethnicity",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black" },
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "White", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "White" },
                    { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indian" },
                    { 4, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coloured", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coloured" },
                    { 5, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asian", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asian" },
                    { 6, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other" }
                });

            migrationBuilder.InsertData(
                table: "FileType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Note" },
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Document" }
                });

            migrationBuilder.InsertData(
                table: "Floor",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Second" },
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ground" },
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "First" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male" },
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female" },
                    { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other" }
                });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 12, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laundry" },
                    { 14, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oaner Requests" },
                    { 13, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Club House" },
                    { 11, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly Reports" },
                    { 10, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Invoices & Approvals" },
                    { 9, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Special Projects" },
                    { 8, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mainteance" },
                    { 6, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Legal" },
                    { 5, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finance" },
                    { 4, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trustees & Portfolios" },
                    { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gardening" },
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Security" },
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vetting &Vendors" },
                    { 7, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compliance" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 8, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiTsonga", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiTsonga" },
                    { 12, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SiSwati", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SiSwati" },
                    { 11, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "sePedi", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "sePedi" },
                    { 10, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiXhosa", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiXhosa" },
                    { 9, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other" },
                    { 7, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiNdebele", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiNdebele" },
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "English", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "English" },
                    { 5, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "tshiVenda", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "tshiVenda" },
                    { 4, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "seTswana", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "seTswana" },
                    { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "seSotho", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "seSotho" },
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afrikaans", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afrikaans" },
                    { 6, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiZulu", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "isiZulu" }
                });

            migrationBuilder.InsertData(
                table: "Occupation",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 11, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Director / Manager (not in the water industry)" },
                    { 12, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Process Controller" },
                    { 10, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Director / Manager (in water industry)" },
                    { 15, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other" },
                    { 14, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consultant" },
                    { 13, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Self Employed" },
                    { 9, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Technician" },
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Retired – not working" },
                    { 7, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engineer" },
                    { 6, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scientist" },
                    { 5, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Researcher" },
                    { 4, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Academic" },
                    { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full time student" },
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unemployed" },
                    { 8, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Practitioner" }
                });

            migrationBuilder.InsertData(
                table: "Portfolio",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 10, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Special Projects" },
                    { 9, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClubHouse" },
                    { 8, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laundry" },
                    { 7, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compliance" },
                    { 6, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Legal" },
                    { 4, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garden" },
                    { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Security" },
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vice Chair" },
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chair Person" },
                    { 5, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finance" }
                });

            migrationBuilder.InsertData(
                table: "RelatedTo",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 6, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tenant", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garden Vendor" },
                    { 8, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Service Provider", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Service Provider" },
                    { 7, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Service Provider", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Security Vendor" },
                    { 5, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Service Provider", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estate Management Vendor" },
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Service Provider", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Owner" },
                    { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Service Provider", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tenant" },
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tenant", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trustee" },
                    { 4, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Service Provider", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estate Manager" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Open" },
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Progress" },
                    { 4, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 5, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Review" },
                    { 6, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accepted" },
                    { 7, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rejected" },
                    { 8, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blocked" },
                    { 9, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Closed" }
                });

            migrationBuilder.InsertData(
                table: "TaskItem",
                columns: new[] { "Id", "ClosedOn", "CreatedBy", "CreatedOn", "Description", "DueOn", "GroupId", "ModifiedBy", "ModifiedOn", "Name", "PriorityId", "ProgressPercentage", "StatusId", "UnitId" },
                values: new object[,]
                {
                    { 7, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rejected", null, null, null, null },
                    { 9, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Closed", null, null, null, null },
                    { 8, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blocked", null, null, null, null },
                    { 6, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accepted", null, null, null, null },
                    { 4, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", null, null, null, null },
                    { 3, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Progress", null, null, null, null },
                    { 2, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", null, null, null, null },
                    { 1, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Open", null, null, null, null },
                    { 5, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Review", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Title",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr" },
                    { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mrs" },
                    { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ms" },
                    { 4, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr" },
                    { 5, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prof" }
                });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "BlockId", "CreatedBy", "CreatedOn", "FloorId", "ModifiedBy", "ModifiedOn", "No" },
                values: new object[,]
                {
                    { 86, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 86 },
                    { 77, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 77 },
                    { 78, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 78 },
                    { 79, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 79 },
                    { 61, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 61 },
                    { 84, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 84 },
                    { 81, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 81 },
                    { 82, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 82 },
                    { 83, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 83 },
                    { 76, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 76 },
                    { 85, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 85 },
                    { 80, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 80 },
                    { 75, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 75 },
                    { 70, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 70 },
                    { 73, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 73 },
                    { 72, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 72 },
                    { 71, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 71 },
                    { 69, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 69 },
                    { 68, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 68 },
                    { 67, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 67 },
                    { 66, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 66 },
                    { 65, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 65 },
                    { 64, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 64 },
                    { 63, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 63 },
                    { 62, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 62 },
                    { 74, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 74 },
                    { 87, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 87 },
                    { 110, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 110 },
                    { 89, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 89 },
                    { 115, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 115 },
                    { 114, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 114 },
                    { 113, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 113 },
                    { 112, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 112 },
                    { 111, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 111 },
                    { 60, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 60 },
                    { 109, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 109 },
                    { 108, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 108 },
                    { 107, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 107 },
                    { 106, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 106 },
                    { 105, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 105 },
                    { 104, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 104 },
                    { 88, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 88 },
                    { 103, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 103 },
                    { 101, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 101 },
                    { 100, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 99, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { 98, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 98 },
                    { 97, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 97 },
                    { 96, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 96 },
                    { 95, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 95 },
                    { 94, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 94 },
                    { 93, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 93 },
                    { 92, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 92 },
                    { 91, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 91 },
                    { 90, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 90 },
                    { 102, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 102 },
                    { 59, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 59 },
                    { 36, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 36 },
                    { 57, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 57 },
                    { 25, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 25 },
                    { 24, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 24 },
                    { 23, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 23 },
                    { 22, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 22 },
                    { 21, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 21 },
                    { 20, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 20 },
                    { 19, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 19 },
                    { 18, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 18 },
                    { 17, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 17 },
                    { 16, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 15, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 14, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 13, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 12, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 11, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 10, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 9, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 8, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 7, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 6, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 5, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 4, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 3, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 58, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 58 },
                    { 27, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 27 },
                    { 26, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 26 },
                    { 29, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 29 },
                    { 56, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 56 },
                    { 55, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 55 },
                    { 54, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 54 },
                    { 53, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 53 },
                    { 52, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 52 },
                    { 51, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 51 },
                    { 50, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 50 },
                    { 49, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 49 },
                    { 48, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 48 },
                    { 47, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 47 },
                    { 46, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 46 },
                    { 28, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 28 },
                    { 44, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 44 },
                    { 45, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 45 },
                    { 42, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 42 },
                    { 30, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 30 },
                    { 31, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 31 },
                    { 32, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 32 },
                    { 43, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 43 },
                    { 34, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 34 },
                    { 33, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 33 },
                    { 37, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 37 },
                    { 38, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 38 },
                    { 39, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 39 },
                    { 40, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 40 },
                    { 41, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 41 },
                    { 35, null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 35 }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 3, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tenant", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tenant" });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trustee", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trustee" });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 2, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Owner", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Owner" });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 4, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Service Provider", null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Service Provider" });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "CountryId", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eastern Cape" },
                    { 2, 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Free State" },
                    { 3, 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gauteng" },
                    { 4, 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "KwaZulu-Natal" },
                    { 5, 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limpopo" },
                    { 6, 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mpumalanga" },
                    { 7, 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "North West" },
                    { 8, 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Northern Cape" },
                    { 9, 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western Cape" },
                    { 10, 1, null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddressTypeId",
                table: "Address",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ProvinceId",
                table: "Address",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_RelatedToId",
                table: "Address",
                column: "RelatedToId");

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
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserTypeId",
                table: "AspNetUsers",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Board_PortfolioId",
                table: "Board",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Board_SystemUserId",
                table: "Board",
                column: "SystemUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_ContactUsRelatedToId",
                table: "ContactUs",
                column: "ContactUsRelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Province_CountryId",
                table: "Province",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderTrusteeApproval_ServiceProviderId",
                table: "ServiceProviderTrusteeApproval",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderTrusteeApproval_SystemUserId",
                table: "ServiceProviderTrusteeApproval",
                column: "SystemUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_EthnicityId",
                table: "SystemUser",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_GenderId",
                table: "SystemUser",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_HomeLanguageId",
                table: "SystemUser",
                column: "HomeLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_OccupationId",
                table: "SystemUser",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_TitleId",
                table: "SystemUser",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_GroupId",
                table: "TaskItem",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_PriorityId",
                table: "TaskItem",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_StatusId",
                table: "TaskItem",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_UnitId",
                table: "TaskItem",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItemAssignee_AssignedByUserId",
                table: "TaskItemAssignee",
                column: "AssignedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItemAssignee_TaskItemId",
                table: "TaskItemAssignee",
                column: "TaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItemComment_FileTypeId",
                table: "TaskItemComment",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItemComment_SystemUserId",
                table: "TaskItemComment",
                column: "SystemUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItemComment_TaskItemId",
                table: "TaskItemComment",
                column: "TaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItemFile_FileTypeId",
                table: "TaskItemFile",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItemFile_SystemUserId",
                table: "TaskItemFile",
                column: "SystemUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItemFile_TaskItemId",
                table: "TaskItemFile",
                column: "TaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_BlockId",
                table: "Unit",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_FloorId",
                table: "Unit",
                column: "FloorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

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
                name: "Board");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "ServiceProviderTrusteeApproval");

            migrationBuilder.DropTable(
                name: "TaskItemAssignee");

            migrationBuilder.DropTable(
                name: "TaskItemComment");

            migrationBuilder.DropTable(
                name: "TaskItemFile");

            migrationBuilder.DropTable(
                name: "UserActivity");

            migrationBuilder.DropTable(
                name: "AddressType");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "RelatedTo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.DropTable(
                name: "ContactUsRelatedTo");

            migrationBuilder.DropTable(
                name: "ServiceProvider");

            migrationBuilder.DropTable(
                name: "FileType");

            migrationBuilder.DropTable(
                name: "SystemUser");

            migrationBuilder.DropTable(
                name: "TaskItem");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "Ethnicity");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Occupation");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Priority");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Block");

            migrationBuilder.DropTable(
                name: "Floor");
        }
    }
}
