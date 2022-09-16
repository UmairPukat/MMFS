using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMFS_Context.Migrations
{
    public partial class add_UserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.CreateTable(
                name: "BusinessProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    EnterpriseSSMNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SSMExpiryDate = table.Column<DateTime>(type: "Date", nullable: false),
                    BusinessAddress = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AGPManagerName = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    AGPManagerPhoneNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HouseType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HomeFurnishing = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ShopLot = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessProfile_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProfile_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProfile_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessProfile_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserChequeProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PloteAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlotePaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PloteRemark = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    OperationReserveAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OperationReservePaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OperationReserveRemark = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    JVAgreementAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JVAgreementPaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JVAgreementRemark = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    StampingAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StampingPaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StampingRemark = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    HouseUtilitiesAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HouseUtilitiesPaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HouseUtilitiesRemark = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    HouseFurnishingAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HouseFurnishingPaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HouseFurnishingRemark = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ShopLotAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShopLotPaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShopLotRemark = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChequeProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserChequeProfile_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserEmergencyProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Covid19Vaccination = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEmergencyProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEmergencyProfile_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPersonalProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AGPIdCard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewNRICNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OldNRICNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MobilePhoneNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DOB = table.Column<DateTime>(type: "Date", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    ReligionId = table.Column<int>(type: "int", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DrivingLicenseType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DrivingLicenseClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyVehiclePlateNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyVehicleModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyHouseAddress = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPersonalProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPersonalProfile_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPersonalProfile_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPersonalProfile_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPersonalProfile_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPersonalProfile_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProfile_BankId",
                table: "BusinessProfile",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProfile_CityId",
                table: "BusinessProfile",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProfile_StateId",
                table: "BusinessProfile",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProfile_UserId",
                table: "BusinessProfile",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserChequeProfile_UserId",
                table: "UserChequeProfile",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserEmergencyProfile_UserId",
                table: "UserEmergencyProfile",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalProfile_CityId",
                table: "UserPersonalProfile",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalProfile_RaceId",
                table: "UserPersonalProfile",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalProfile_ReligionId",
                table: "UserPersonalProfile",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalProfile_StateId",
                table: "UserPersonalProfile",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalProfile_UserId",
                table: "UserPersonalProfile",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessProfile");

            migrationBuilder.DropTable(
                name: "UserChequeProfile");

            migrationBuilder.DropTable(
                name: "UserEmergencyProfile");

            migrationBuilder.DropTable(
                name: "UserPersonalProfile");

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AGPIdCard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AGPManagerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AGPManagerPhoneNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Amount = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    BankAccountNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    BusinessAddress = table.Column<bool>(type: "bit", maxLength: 10, nullable: false),
                    BusinessCityId = table.Column<int>(type: "int", nullable: true),
                    BusinessPostcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusinessStateId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyHouseAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyVehicleModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyVehiclePlateNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Covid19Vaccination = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DOB = table.Column<DateTime>(type: "Date", nullable: false),
                    DrivingLicenseClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DrivingLicenseType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnterpriseSSMNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HomeFurnishing = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HouseType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "Date", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NewNRICNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OldNRICNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Particulars = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReligionId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SSMExpiryDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ShopLot = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfile_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfile_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfile_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfile_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfile_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_BankId",
                table: "UserProfile",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_CityId",
                table: "UserProfile",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_RaceId",
                table: "UserProfile",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_ReligionId",
                table: "UserProfile",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_StateId",
                table: "UserProfile",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_UserId",
                table: "UserProfile",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
