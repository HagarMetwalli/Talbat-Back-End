using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Talbat.Migrations
{
    public partial class offertypetbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    AddressType_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressType_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.AddressType_Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    City_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.City_Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Client_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_Fname = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Client_Lname = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Client_Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Client_DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Client_Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Client_Gender_IsMale = table.Column<int>(type: "int", nullable: false),
                    Client_NewsletterSubscribe = table.Column<int>(type: "int", nullable: false),
                    Client_SmsSubscribe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Client_Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Country_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country_Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Currency_Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Country_Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMan",
                columns: table => new
                {
                    DeliveryMan_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryMan_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DeliveryMan_Salary = table.Column<int>(type: "int", nullable: true),
                    DeliveryMan_HireDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeliveryMan_CurrentLocation = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMan", x => x.DeliveryMan_Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategory",
                columns: table => new
                {
                    ItemCategory_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCategory_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategory", x => x.ItemCategory_Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCategory",
                columns: table => new
                {
                    JobCategory_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCategory_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.JobCategory_Id);
                });

            migrationBuilder.CreateTable(
                name: "JobLocation",
                columns: table => new
                {
                    JobLocation_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobLocation_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLocation", x => x.JobLocation_Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPeriod",
                columns: table => new
                {
                    JobPeriod_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobPeriod_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPeriod", x => x.JobPeriod_Id);
                });

            migrationBuilder.CreateTable(
                name: "JobType",
                columns: table => new
                {
                    JobType_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobType_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobType", x => x.JobType_Id);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Offer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Offer_Image = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "('Default.png')"),
                    Offer_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    OfferType_IsCoupon = table.Column<int>(type: "int", nullable: false),
                    Offer_Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Offer_StartDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    Offer_Quantity = table.Column<int>(type: "int", nullable: false),
                    Offer_DaysNumber = table.Column<int>(type: "int", nullable: false),
                    Offer_Price = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Offer_Id);
                });

            migrationBuilder.CreateTable(
                name: "RateStatus",
                columns: table => new
                {
                    RateStatus_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RateStatus_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateStatus", x => x.RateStatus_Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Region_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Region_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Region_Id);
                });

            migrationBuilder.CreateTable(
                name: "ReviewCategory",
                columns: table => new
                {
                    ReviewCategory_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewCategory_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewCategory", x => x.ReviewCategory_Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreType",
                columns: table => new
                {
                    StoreType_Id = table.Column<int>(type: "int", nullable: false),
                    Store_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreType", x => x.StoreType_Id);
                });

            migrationBuilder.CreateTable(
                name: "SubItemCategory",
                columns: table => new
                {
                    SubItemCategory_Id = table.Column<int>(type: "int", nullable: false),
                    SubItemCategory_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SubItemCategory_Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubItemCategory", x => x.SubItemCategory_Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Job_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_Title = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Job_Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Job_PostedTime = table.Column<DateTime>(type: "date", nullable: true),
                    JobCategory_Id = table.Column<int>(type: "int", nullable: false),
                    JobLocation_Id = table.Column<int>(type: "int", nullable: false),
                    JobType_Id = table.Column<int>(type: "int", nullable: false),
                    JobPeriod_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Job_Id);
                    table.ForeignKey(
                        name: "FK_Job_JobCategory",
                        column: x => x.JobCategory_Id,
                        principalTable: "JobCategory",
                        principalColumn: "JobCategory_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_JobLocation",
                        column: x => x.JobLocation_Id,
                        principalTable: "JobLocation",
                        principalColumn: "JobLocation_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_JobPeriod",
                        column: x => x.JobPeriod_Id,
                        principalTable: "JobPeriod",
                        principalColumn: "JobPeriod_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_JobType",
                        column: x => x.JobType_Id,
                        principalTable: "JobType",
                        principalColumn: "JobType_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client_Offer",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Offer_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Offer", x => new { x.User_Id, x.Offer_Id });
                    table.ForeignKey(
                        name: "FK_User_Offer_Offer",
                        column: x => x.Offer_Id,
                        principalTable: "Offer",
                        principalColumn: "Offer_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Offer_User",
                        column: x => x.User_Id,
                        principalTable: "Client",
                        principalColumn: "Client_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemReview",
                columns: table => new
                {
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    OrderReview_Id = table.Column<int>(type: "int", nullable: false),
                    RateStatus_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemReview", x => x.Item_Id);
                    table.ForeignKey(
                        name: "FK_ItemReview_RateStatus",
                        column: x => x.RateStatus_Id,
                        principalTable: "RateStatus",
                        principalColumn: "RateStatus_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferReview",
                columns: table => new
                {
                    Offer_Id = table.Column<int>(type: "int", nullable: false),
                    OrderReview_Id = table.Column<int>(type: "int", nullable: false),
                    RateStatus_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferReview", x => x.Offer_Id);
                    table.ForeignKey(
                        name: "FK_OfferReview_RateStatus",
                        column: x => x.RateStatus_Id,
                        principalTable: "RateStatus",
                        principalColumn: "RateStatus_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientAddress",
                columns: table => new
                {
                    ClientAddress_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientAddress_MobileNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ClientAddress_LandLine = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "('')"),
                    ClientAddress_AddressTitle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "('')"),
                    ClientAddress_Street = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ClientAddress_Building = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ClientAddress_Floor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ClientAddress_ApartmentNumber = table.Column<int>(type: "int", nullable: false),
                    ClientAddress_OptionalDirections = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ClientAddress_Type_Id = table.Column<int>(type: "int", nullable: false),
                    City_Id = table.Column<int>(type: "int", nullable: false),
                    Region_Id = table.Column<int>(type: "int", nullable: false),
                    Client_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAddress", x => x.ClientAddress_Id);
                    table.ForeignKey(
                        name: "FK_ClientAddress_AddressType",
                        column: x => x.ClientAddress_Type_Id,
                        principalTable: "AddressType",
                        principalColumn: "AddressType_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientAddress_City",
                        column: x => x.City_Id,
                        principalTable: "City",
                        principalColumn: "City_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientAddress_Client",
                        column: x => x.Client_Id,
                        principalTable: "Client",
                        principalColumn: "Client_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientAddress_Region",
                        column: x => x.Region_Id,
                        principalTable: "Region",
                        principalColumn: "Region_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Store_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Store_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Store_Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Country_Id = table.Column<int>(type: "int", nullable: false),
                    Store_Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Store_MinOrder = table.Column<double>(type: "float", nullable: true),
                    Store_DeliveryTime = table.Column<int>(type: "int", nullable: false),
                    Store_DeliveryFee = table.Column<double>(type: "float", nullable: true),
                    Store_PreOrder = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Store_PaymentOnDeliverCash = table.Column<int>(type: "int", nullable: true),
                    Store_PaymentVisa = table.Column<int>(type: "int", nullable: true),
                    Store_Cuisine = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    StoreType_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Store_Id);
                    table.ForeignKey(
                        name: "FK_Store_StoreType",
                        column: x => x.StoreType_Id,
                        principalTable: "StoreType",
                        principalColumn: "StoreType_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TempPartnerRegisterationDetails",
                columns: table => new
                {
                    TempPartnerStore_Id = table.Column<int>(type: "int", nullable: false),
                    Partner_FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Partner_LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Store_Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Partner_PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Partner_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Partner_ContactRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Store_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Store_BranchesNo = table.Column<int>(type: "int", nullable: true),
                    Store_Contact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Store_Address = table.Column<int>(type: "int", nullable: true),
                    Store_Status = table.Column<byte[]>(type: "binary(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Store_Type_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempPartnerRegisterationDetails", x => x.TempPartnerStore_Id);
                    table.ForeignKey(
                        name: "FK_TempPartnerRegisterationDetails_StoreType",
                        column: x => x.Store_Type_Id,
                        principalTable: "StoreType",
                        principalColumn: "StoreType_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client_Seeking_Jobs",
                columns: table => new
                {
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    Job_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Seeking_Jobs", x => new { x.Client_Id, x.Job_Id });
                    table.ForeignKey(
                        name: "FK_Client_Seeking_Jobs_Job",
                        column: x => x.Job_Id,
                        principalTable: "Job",
                        principalColumn: "Job_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Seeking_Jobs_User",
                        column: x => x.Client_Id,
                        principalTable: "Client",
                        principalColumn: "Client_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Item_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false, defaultValueSql: "('Default.png')"),
                    Item_Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Item_Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false, defaultValueSql: "('No Description')"),
                    Item_Price = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ItemCategory_Id = table.Column<int>(type: "int", nullable: false),
                    Country_Id = table.Column<int>(type: "int", nullable: false),
                    Store_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Item_Id);
                    table.ForeignKey(
                        name: "FK_Item_Country",
                        column: x => x.Country_Id,
                        principalTable: "Country",
                        principalColumn: "Country_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Store",
                        column: x => x.Store_Id,
                        principalTable: "Store",
                        principalColumn: "Store_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Cost = table.Column<double>(type: "float", nullable: false),
                    Order_SpecialRequest = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "('none')"),
                    Order_Time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    Store_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Order_Id);
                    table.ForeignKey(
                        name: "FK_Order_Store",
                        column: x => x.Store_Id,
                        principalTable: "Store",
                        principalColumn: "Store_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User",
                        column: x => x.Client_Id,
                        principalTable: "Client",
                        principalColumn: "Client_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    Partner_Id = table.Column<int>(type: "int", nullable: false),
                    Partner_FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Partner_LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Partner_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Partner_PhoneNo = table.Column<int>(type: "int", nullable: true),
                    Store_Id = table.Column<int>(type: "int", nullable: true),
                    Partner_Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.Partner_Id);
                    table.ForeignKey(
                        name: "FK_Partner_Store",
                        column: x => x.Store_Id,
                        principalTable: "Store",
                        principalColumn: "Store_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Review_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review_Content = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Review_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Review_Rates = table.Column<double>(type: "float", nullable: true),
                    ReviewCategory_Id = table.Column<int>(type: "int", nullable: true),
                    User_Id = table.Column<int>(type: "int", nullable: true),
                    Store_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Review_Id);
                    table.ForeignKey(
                        name: "FK_Review_ReviewCategory",
                        column: x => x.ReviewCategory_Id,
                        principalTable: "ReviewCategory",
                        principalColumn: "ReviewCategory_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Store",
                        column: x => x.Store_Id,
                        principalTable: "Store",
                        principalColumn: "Store_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_User",
                        column: x => x.User_Id,
                        principalTable: "Client",
                        principalColumn: "Client_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreWorkingHour",
                columns: table => new
                {
                    StoreWorkingHour_Id = table.Column<int>(type: "int", nullable: false),
                    StoreWorkingHour_Day = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    StoreWorkingHour_Start = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    StoreWorkingHour_End = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    Store_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreWorkingHour", x => x.StoreWorkingHour_Id);
                    table.ForeignKey(
                        name: "FK_StoreWorkingHour_Store",
                        column: x => x.Store_Id,
                        principalTable: "Store",
                        principalColumn: "Store_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferItem",
                columns: table => new
                {
                    Offer_Id = table.Column<int>(type: "int", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    OfferItem_Quantity = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    OfferItem_TypePercentage = table.Column<byte[]>(type: "binary(10)", fixedLength: true, maxLength: 10, nullable: false),
                    OfferItem_SaleValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferItem", x => new { x.Offer_Id, x.Item_Id });
                    table.ForeignKey(
                        name: "FK_OfferItem_Item",
                        column: x => x.Item_Id,
                        principalTable: "Item",
                        principalColumn: "Item_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferItem_Offer",
                        column: x => x.Offer_Id,
                        principalTable: "Offer",
                        principalColumn: "Offer_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubItem",
                columns: table => new
                {
                    SubItem_Id = table.Column<int>(type: "int", nullable: false),
                    SubItem_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SubItem_Price = table.Column<double>(type: "float", nullable: false),
                    SubItem_SelectionType = table.Column<byte[]>(type: "binary(10)", fixedLength: true, maxLength: 10, nullable: false),
                    SubItemCategory_Id = table.Column<int>(type: "int", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubItem", x => x.SubItem_Id);
                    table.ForeignKey(
                        name: "FK_SubItem_Item1",
                        column: x => x.Item_Id,
                        principalTable: "Item",
                        principalColumn: "Item_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubItem_SubItemCategory",
                        column: x => x.SubItemCategory_Id,
                        principalTable: "SubItemCategory",
                        principalColumn: "SubItemCategory_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Invoice_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: true),
                    AddressDetails = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Order_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Invoice_Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Order",
                        column: x => x.Order_Id,
                        principalTable: "Order",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    OrderItem_Qty = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    OrderItem_SpecialRequest = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true, defaultValueSql: "('none')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => new { x.Order_Id, x.Item_Id });
                    table.ForeignKey(
                        name: "FK_OrderItem_Item",
                        column: x => x.Item_Id,
                        principalTable: "Item",
                        principalColumn: "Item_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order",
                        column: x => x.Order_Id,
                        principalTable: "Order",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderReview",
                columns: table => new
                {
                    OrderReview_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    OrderPackaging = table.Column<int>(type: "int", nullable: false),
                    ValueForMoney = table.Column<int>(type: "int", nullable: false),
                    DeliveryTime = table.Column<int>(type: "int", nullable: false),
                    QualityOFFood = table.Column<int>(type: "int", nullable: false),
                    OfferReview_body = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderReview", x => x.OrderReview_Id);
                    table.ForeignKey(
                        name: "FK_OrderReview_Order",
                        column: x => x.Order_Id,
                        principalTable: "Order",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderReview_OrderReview",
                        column: x => x.OrderPackaging,
                        principalTable: "OrderReview",
                        principalColumn: "OrderReview_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderReview_OrderReview1",
                        column: x => x.ValueForMoney,
                        principalTable: "OrderReview",
                        principalColumn: "OrderReview_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderReview_OrderReview2",
                        column: x => x.DeliveryTime,
                        principalTable: "OrderReview",
                        principalColumn: "OrderReview_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderReview_OrderReview3",
                        column: x => x.QualityOFFood,
                        principalTable: "OrderReview",
                        principalColumn: "OrderReview_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientDeliveryManOrder",
                columns: table => new
                {
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    DeliveryMan_Id = table.Column<int>(type: "int", nullable: false),
                    Invoice_Id = table.Column<int>(type: "int", nullable: false),
                    ClientAddress_Id = table.Column<int>(type: "int", nullable: false),
                    Order_Shiping_Time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDeliveryManOrder", x => new { x.Client_Id, x.DeliveryMan_Id, x.Invoice_Id });
                    table.ForeignKey(
                        name: "FK_ClientDeliveryManOrder_Client",
                        column: x => x.Client_Id,
                        principalTable: "Client",
                        principalColumn: "Client_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientDeliveryManOrder_ClientAddress",
                        column: x => x.ClientAddress_Id,
                        principalTable: "ClientAddress",
                        principalColumn: "ClientAddress_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientDeliveryManOrder_DeliveryMan",
                        column: x => x.DeliveryMan_Id,
                        principalTable: "DeliveryMan",
                        principalColumn: "DeliveryMan_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientDeliveryManOrder_Order",
                        column: x => x.Invoice_Id,
                        principalTable: "Invoice",
                        principalColumn: "Invoice_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_Offer_Offer_Id",
                table: "Client_Offer",
                column: "Offer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Seeking_Jobs_Job_Id",
                table: "Client_Seeking_Jobs",
                column: "Job_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_City_Id",
                table: "ClientAddress",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_Client_Id",
                table: "ClientAddress",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_ClientAddress_Type_Id",
                table: "ClientAddress",
                column: "ClientAddress_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_Region_Id",
                table: "ClientAddress",
                column: "Region_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeliveryManOrder_ClientAddress_Id",
                table: "ClientDeliveryManOrder",
                column: "ClientAddress_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeliveryManOrder_DeliveryMan_Id",
                table: "ClientDeliveryManOrder",
                column: "DeliveryMan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeliveryManOrder_Invoice_Id",
                table: "ClientDeliveryManOrder",
                column: "Invoice_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Order_Id",
                table: "Invoice",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Country_Id",
                table: "Item",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Store_Id",
                table: "Item",
                column: "Store_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReview_RateStatus_Id",
                table: "ItemReview",
                column: "RateStatus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobCategory_Id",
                table: "Job",
                column: "JobCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobLocation_Id",
                table: "Job",
                column: "JobLocation_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobPeriod_Id",
                table: "Job",
                column: "JobPeriod_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobType_Id",
                table: "Job",
                column: "JobType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_Item_Id",
                table: "OfferItem",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OfferReview_RateStatus_Id",
                table: "OfferReview",
                column: "RateStatus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Client_Id",
                table: "Order",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Store_Id",
                table: "Order",
                column: "Store_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_Item_Id",
                table: "OrderItem",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReview_DeliveryTime",
                table: "OrderReview",
                column: "DeliveryTime");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReview_Order_Id",
                table: "OrderReview",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReview_OrderPackaging",
                table: "OrderReview",
                column: "OrderPackaging");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReview_QualityOFFood",
                table: "OrderReview",
                column: "QualityOFFood");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReview_ValueForMoney",
                table: "OrderReview",
                column: "ValueForMoney");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_Store_Id",
                table: "Partner",
                column: "Store_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReviewCategory_Id",
                table: "Review",
                column: "ReviewCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Store_Id",
                table: "Review",
                column: "Store_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_User_Id",
                table: "Review",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Store_StoreType_Id",
                table: "Store",
                column: "StoreType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_StoreWorkingHour_Store_Id",
                table: "StoreWorkingHour",
                column: "Store_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubItem_Item_Id",
                table: "SubItem",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubItem_SubItemCategory_Id",
                table: "SubItem",
                column: "SubItemCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TempPartnerRegisterationDetails_Store_Type_Id",
                table: "TempPartnerRegisterationDetails",
                column: "Store_Type_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client_Offer");

            migrationBuilder.DropTable(
                name: "Client_Seeking_Jobs");

            migrationBuilder.DropTable(
                name: "ClientDeliveryManOrder");

            migrationBuilder.DropTable(
                name: "ItemCategory");

            migrationBuilder.DropTable(
                name: "ItemReview");

            migrationBuilder.DropTable(
                name: "OfferItem");

            migrationBuilder.DropTable(
                name: "OfferReview");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "OrderReview");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "StoreWorkingHour");

            migrationBuilder.DropTable(
                name: "SubItem");

            migrationBuilder.DropTable(
                name: "TempPartnerRegisterationDetails");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "ClientAddress");

            migrationBuilder.DropTable(
                name: "DeliveryMan");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "RateStatus");

            migrationBuilder.DropTable(
                name: "ReviewCategory");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "SubItemCategory");

            migrationBuilder.DropTable(
                name: "JobCategory");

            migrationBuilder.DropTable(
                name: "JobLocation");

            migrationBuilder.DropTable(
                name: "JobPeriod");

            migrationBuilder.DropTable(
                name: "JobType");

            migrationBuilder.DropTable(
                name: "AddressType");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "StoreType");
        }
    }
}
