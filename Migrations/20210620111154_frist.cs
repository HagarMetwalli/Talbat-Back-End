using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Talbat.Migrations
{
    public partial class frist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    AddressTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.AddressTypeId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientFname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ClientLname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ClientEmail = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    ClientDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientPassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClientGenderIsMale = table.Column<int>(type: "int", nullable: false),
                    ClientNewsletterSubscribe = table.Column<int>(type: "int", nullable: false),
                    ClientSmsSubscribe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CurrencyName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    CuisineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuisineName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TotalOrdersNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.CuisineId);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMan",
                columns: table => new
                {
                    DeliveryManId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryManName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    DeliveryManSalary = table.Column<int>(type: "int", nullable: false),
                    DeliveryManHireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryManCurrentLocation = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMan", x => x.DeliveryManId);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategory",
                columns: table => new
                {
                    ItemCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCategoryName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategory", x => x.ItemCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "JobCategory",
                columns: table => new
                {
                    JobCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCategoryType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.JobCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "JobLocation",
                columns: table => new
                {
                    JobLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobLocationName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLocation", x => x.JobLocationId);
                });

            migrationBuilder.CreateTable(
                name: "JobPeriod",
                columns: table => new
                {
                    JobPeriodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobPeriodName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPeriod", x => x.JobPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "JobType",
                columns: table => new
                {
                    JobTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTypeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobType", x => x.JobTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "RateStatus",
                columns: table => new
                {
                    RateStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RateStatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateStatus", x => x.RateStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "StoreType",
                columns: table => new
                {
                    StoreTypeId = table.Column<int>(type: "int", nullable: false),
                    StoreTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreType", x => x.StoreTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SubItemCategory",
                columns: table => new
                {
                    SubItemCategoryId = table.Column<int>(type: "int", nullable: false),
                    SubItemCategoryName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubItemCategory", x => x.SubItemCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "SystemReview",
                columns: table => new
                {
                    SystemReviewId = table.Column<int>(type: "int", nullable: false),
                    RateTalabatExperience = table.Column<int>(type: "int", nullable: false),
                    EffortMadeToOrderFood = table.Column<int>(type: "int", nullable: false),
                    RecommendToFriend = table.Column<int>(type: "int", nullable: false),
                    SystemReviewComment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemReview", x => x.SystemReviewId);
                    table.ForeignKey(
                        name: "FK_SystemReview_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, defaultValueSql: "('')"),
                    JobDescription = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false, defaultValueSql: "('')"),
                    JobPostedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobCategoryId = table.Column<int>(type: "int", nullable: false),
                    JobLocationId = table.Column<int>(type: "int", nullable: false),
                    JobTypeId = table.Column<int>(type: "int", nullable: false),
                    JobPeriodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Job_JobCategory",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategory",
                        principalColumn: "JobCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_JobLocation",
                        column: x => x.JobLocationId,
                        principalTable: "JobLocation",
                        principalColumn: "JobLocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_JobPeriod",
                        column: x => x.JobPeriodId,
                        principalTable: "JobPeriod",
                        principalColumn: "JobPeriodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_JobType",
                        column: x => x.JobTypeId,
                        principalTable: "JobType",
                        principalColumn: "JobTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientAddress",
                columns: table => new
                {
                    ClientAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientAddressMobileNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ClientAddressLandLine = table.Column<int>(type: "int", unicode: false, nullable: false, defaultValueSql: "('')"),
                    ClientAddressAddressTitle = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValueSql: "('')"),
                    ClientAddressStreet = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ClientAddressBuilding = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ClientAddressFloor = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ClientAddressApartmentNumber = table.Column<int>(type: "int", nullable: false),
                    ClientAddressOptionalDirections = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ClientAddressTypeId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAddress", x => x.ClientAddressId);
                    table.ForeignKey(
                        name: "FK_ClientAddress_AddressType",
                        column: x => x.ClientAddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "AddressTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientAddress_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientAddress_Client",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientAddress_Region",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    StoreDescription = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StoreAddress = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    StoreLatitude = table.Column<double>(type: "float", nullable: false),
                    StoreLongitude = table.Column<double>(type: "float", nullable: false),
                    StoreDeliveryDistance = table.Column<double>(type: "float", nullable: false),
                    StoreMinOrder = table.Column<double>(type: "float", nullable: false),
                    StoreDeliveryTime = table.Column<int>(type: "int", nullable: false),
                    StoreDeliveryFee = table.Column<double>(type: "float", nullable: false),
                    StorePreOrder = table.Column<int>(type: "int", unicode: false, nullable: false),
                    StorePaymentOnDeliverCash = table.Column<int>(type: "int", nullable: false),
                    StorePaymentVisa = table.Column<int>(type: "int", nullable: false),
                    StoreTypeId = table.Column<int>(type: "int", nullable: false),
                    CuisineId = table.Column<int>(type: "int", nullable: false),
                    StoreOrdersNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_Store_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Store_Cuisines_CuisineId",
                        column: x => x.CuisineId,
                        principalTable: "Cuisines",
                        principalColumn: "CuisineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Store_StoreType",
                        column: x => x.StoreTypeId,
                        principalTable: "StoreType",
                        principalColumn: "StoreTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TempPartnerRegisterationDetails",
                columns: table => new
                {
                    TempPartnerStoreId = table.Column<int>(type: "int", nullable: false),
                    PartnerFname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PartnerLname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StoreCountryId = table.Column<int>(type: "int", nullable: false),
                    PartnerPhoneNumber = table.Column<int>(type: "int", nullable: false),
                    PartnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerContactRole = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StoreBranchesNo = table.Column<int>(type: "int", nullable: false),
                    StoreWebSite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StoreAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StoreTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempPartnerRegisterationDetails", x => x.TempPartnerStoreId);
                    table.ForeignKey(
                        name: "FK_TempPartnerRegisterationDetails_Country_StoreCountryId",
                        column: x => x.StoreCountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempPartnerRegisterationDetails_StoreType",
                        column: x => x.StoreTypeId,
                        principalTable: "StoreType",
                        principalColumn: "StoreTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client_Seeking_Jobs",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Seeking_Jobs", x => new { x.ClientId, x.JobId });
                    table.ForeignKey(
                        name: "FK_Client_Seeking_Jobs_Job",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Seeking_Jobs_User",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false),
                    CouponKey = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CouponStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CouponDaysCount = table.Column<int>(type: "int", nullable: false),
                    CouponAvailableUsingTimes = table.Column<int>(type: "int", nullable: false),
                    CouponPercentageValue = table.Column<int>(type: "int", nullable: false),
                    CouponMaxMoneyValue = table.Column<int>(type: "int", nullable: false),
                    IsForAllStoreItems = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.CouponId);
                    table.ForeignKey(
                        name: "FK_Coupon_Store",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemImage = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false, defaultValueSql: "('Default.png')"),
                    ItemName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ItemDescription = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false, defaultValueSql: "('No Description')"),
                    ItemPrice = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ItemCategoryId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_ItemCategory_ItemCategoryId",
                        column: x => x.ItemCategoryId,
                        principalTable: "ItemCategory",
                        principalColumn: "ItemCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_Store",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCost = table.Column<double>(type: "float", nullable: false),
                    OrderSpecialRequest = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, defaultValueSql: "('none')"),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    AddressDetails = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    IsDelivered = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Store",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    PartnerFname = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PartnerLname = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PartnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerPhoneNo = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    PartnerPassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.PartnerId);
                    table.ForeignKey(
                        name: "FK_Partner_Store",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    PromotionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromotionImage = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false, defaultValueSql: "('Default.png')"),
                    PromotionName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PromotionDescription = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    PromotionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    PromotionDaysNumber = table.Column<int>(type: "int", nullable: false),
                    PromotionQuantity = table.Column<int>(type: "int", nullable: false),
                    PromotionTypePercentage = table.Column<int>(type: "int", nullable: false),
                    PromotionSaleValue = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.PromotionId);
                    table.ForeignKey(
                        name: "FK_Promotion_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreWorkingHour",
                columns: table => new
                {
                    StoreWorkingHourId = table.Column<int>(type: "int", nullable: false),
                    StoreWorkingHourDay = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    StoreWorkingHourStart = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    StoreWorkingHourEnd = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreWorkingHour", x => x.StoreWorkingHourId);
                    table.ForeignKey(
                        name: "FK_StoreWorkingHour_Store",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CouponItem",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponItem", x => new { x.CouponId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_CouponItem_Coupon",
                        column: x => x.CouponId,
                        principalTable: "Coupon",
                        principalColumn: "CouponId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CouponItem_Item",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubItem",
                columns: table => new
                {
                    SubItemId = table.Column<int>(type: "int", nullable: false),
                    SubItemName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SubItemPrice = table.Column<double>(type: "float", nullable: false),
                    SubItemIsRadioButton = table.Column<int>(type: "int", fixedLength: true, nullable: false),
                    SubItemCategoryId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubItem", x => x.SubItemId);
                    table.ForeignKey(
                        name: "FK_SubItem_Item1",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubItem_SubItemCategory",
                        column: x => x.SubItemCategoryId,
                        principalTable: "SubItemCategory",
                        principalColumn: "SubItemCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientCoupon",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CouponId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCoupon", x => new { x.ClientId, x.CouponId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ClientCoupon_Client",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientCoupon_Coupon",
                        column: x => x.CouponId,
                        principalTable: "Coupon",
                        principalColumn: "CouponId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientCoupon_Order",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AddressDetails = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoice_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    OrderItemQty = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    OrderItemSpecialRequest = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, defaultValueSql: "('none')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => new { x.OrderId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_OrderItem_Item",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderReview",
                columns: table => new
                {
                    OrderReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderPackaging = table.Column<int>(type: "int", nullable: false),
                    ValueForMoney = table.Column<int>(type: "int", nullable: false),
                    DeliveryTime = table.Column<int>(type: "int", nullable: false),
                    QualityOfFood = table.Column<int>(type: "int", nullable: false),
                    OrderReviewComment = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, defaultValueSql: "('')"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderReview", x => x.OrderReviewId);
                    table.ForeignKey(
                        name: "FK_OrderReview_Client",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderReview_Order",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientPromotion",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    PromotionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPromotion", x => new { x.ClientId, x.PromotionId });
                    table.ForeignKey(
                        name: "FK_ClientPromotion_Client",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientPromotion_Promotion",
                        column: x => x.PromotionId,
                        principalTable: "Promotion",
                        principalColumn: "PromotionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PromotionItem",
                columns: table => new
                {
                    PromotionId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    PromotionItemQuantity = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferItem", x => new { x.PromotionId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_OfferItem_Item",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferItem_Offer",
                        column: x => x.PromotionId,
                        principalTable: "Promotion",
                        principalColumn: "PromotionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientDeliveryManOrder",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DeliveryManId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ClientAddressId = table.Column<int>(type: "int", nullable: false),
                    OrderShipingTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDeliveryManOrder", x => new { x.ClientId, x.DeliveryManId });
                    table.ForeignKey(
                        name: "FK_ClientDeliveryManOrder_Client",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientDeliveryManOrder_ClientAddress",
                        column: x => x.ClientAddressId,
                        principalTable: "ClientAddress",
                        principalColumn: "ClientAddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientDeliveryManOrder_DeliveryMan",
                        column: x => x.DeliveryManId,
                        principalTable: "DeliveryMan",
                        principalColumn: "DeliveryManId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientDeliveryManOrder_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemReview",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    OrderReviewId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemReview", x => new { x.ItemId, x.OrderReviewId });
                    table.ForeignKey(
                        name: "FK_ItemReview_Item",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemReview_OrderReview",
                        column: x => x.OrderReviewId,
                        principalTable: "OrderReview",
                        principalColumn: "OrderReviewId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PromotionReview",
                columns: table => new
                {
                    PromotionId = table.Column<int>(type: "int", nullable: false),
                    OrderReviewId = table.Column<int>(type: "int", nullable: false),
                    RateStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferReview_1", x => new { x.PromotionId, x.OrderReviewId, x.RateStatusId });
                    table.ForeignKey(
                        name: "FK_OfferReview_OrderReview",
                        column: x => x.OrderReviewId,
                        principalTable: "OrderReview",
                        principalColumn: "OrderReviewId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferReview_Promotion",
                        column: x => x.PromotionId,
                        principalTable: "Promotion",
                        principalColumn: "PromotionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferReview_RateStatus",
                        column: x => x.RateStatusId,
                        principalTable: "RateStatus",
                        principalColumn: "RateStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_Seeking_Jobs_Job_Id",
                table: "Client_Seeking_Jobs",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_City_Id",
                table: "ClientAddress",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_Client_Id",
                table: "ClientAddress",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_ClientAddress_Type_Id",
                table: "ClientAddress",
                column: "ClientAddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_Region_Id",
                table: "ClientAddress",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCoupon_CouponId",
                table: "ClientCoupon",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCoupon_OrderId",
                table: "ClientCoupon",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeliveryManOrder_ClientAddress_Id",
                table: "ClientDeliveryManOrder",
                column: "ClientAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeliveryManOrder_DeliveryMan_Id",
                table: "ClientDeliveryManOrder",
                column: "DeliveryManId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeliveryManOrder_Invoice_Id",
                table: "ClientDeliveryManOrder",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPromotion_PromotionId",
                table: "ClientPromotion",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_StoreId",
                table: "Coupon",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponItem_ItemId",
                table: "CouponItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Order_Id",
                table: "Invoice",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Country_Id",
                table: "Item",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemCategoryId",
                table: "Item",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Store_Id",
                table: "Item",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReview_OrderReviewId",
                table: "ItemReview",
                column: "OrderReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobCategory_Id",
                table: "Job",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobLocation_Id",
                table: "Job",
                column: "JobLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobPeriod_Id",
                table: "Job",
                column: "JobPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobType_Id",
                table: "Job",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Client_Id",
                table: "Order",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Store_Id",
                table: "Order",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_Item_Id",
                table: "OrderItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReview_ClientId",
                table: "OrderReview",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReview_DeliveryTime",
                table: "OrderReview",
                column: "DeliveryTime");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReview_OrderId",
                table: "OrderReview",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReview_OrderPackaging",
                table: "OrderReview",
                column: "OrderPackaging");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReview_QualityOFFood",
                table: "OrderReview",
                column: "QualityOfFood");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReview_ValueForMoney",
                table: "OrderReview",
                column: "ValueForMoney");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_Store_Id",
                table: "Partner",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_StoreId",
                table: "Promotion",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_Item_Id",
                table: "PromotionItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferReview_RateStatus_Id",
                table: "PromotionReview",
                column: "RateStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionReview_OrderReviewId",
                table: "PromotionReview",
                column: "OrderReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_CountryId",
                table: "Store",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_CuisineId",
                table: "Store",
                column: "CuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_StoreType_Id",
                table: "Store",
                column: "StoreTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreWorkingHour_Store_Id",
                table: "StoreWorkingHour",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SubItem_Item_Id",
                table: "SubItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SubItem_SubItemCategory_Id",
                table: "SubItem",
                column: "SubItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemReview_ClientId",
                table: "SystemReview",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TempPartnerRegisterationDetails_Store_Type_Id",
                table: "TempPartnerRegisterationDetails",
                column: "StoreTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TempPartnerRegisterationDetails_StoreCountryId",
                table: "TempPartnerRegisterationDetails",
                column: "StoreCountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client_Seeking_Jobs");

            migrationBuilder.DropTable(
                name: "ClientCoupon");

            migrationBuilder.DropTable(
                name: "ClientDeliveryManOrder");

            migrationBuilder.DropTable(
                name: "ClientPromotion");

            migrationBuilder.DropTable(
                name: "CouponItem");

            migrationBuilder.DropTable(
                name: "ItemReview");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropTable(
                name: "PromotionItem");

            migrationBuilder.DropTable(
                name: "PromotionReview");

            migrationBuilder.DropTable(
                name: "StoreWorkingHour");

            migrationBuilder.DropTable(
                name: "SubItem");

            migrationBuilder.DropTable(
                name: "SystemReview");

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
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "OrderReview");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropTable(
                name: "RateStatus");

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
                name: "ItemCategory");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Cuisines");

            migrationBuilder.DropTable(
                name: "StoreType");
        }
    }
}
