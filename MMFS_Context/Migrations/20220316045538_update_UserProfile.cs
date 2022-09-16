using Microsoft.EntityFrameworkCore.Migrations;

namespace MMFS_Context.Migrations
{
    public partial class update_UserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessProfile_AspNetUsers_UserId",
                table: "BusinessProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessProfile_Bank_BankId",
                table: "BusinessProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessProfile_City_CityId",
                table: "BusinessProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessProfile_States_StateId",
                table: "BusinessProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessProfile",
                table: "BusinessProfile");

            migrationBuilder.RenameTable(
                name: "BusinessProfile",
                newName: "UserBusinessProfile");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessProfile_UserId",
                table: "UserBusinessProfile",
                newName: "IX_UserBusinessProfile_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessProfile_StateId",
                table: "UserBusinessProfile",
                newName: "IX_UserBusinessProfile_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessProfile_CityId",
                table: "UserBusinessProfile",
                newName: "IX_UserBusinessProfile_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessProfile_BankId",
                table: "UserBusinessProfile",
                newName: "IX_UserBusinessProfile_BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBusinessProfile",
                table: "UserBusinessProfile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBusinessProfile_AspNetUsers_UserId",
                table: "UserBusinessProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBusinessProfile_Bank_BankId",
                table: "UserBusinessProfile",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBusinessProfile_City_CityId",
                table: "UserBusinessProfile",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBusinessProfile_States_StateId",
                table: "UserBusinessProfile",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBusinessProfile_AspNetUsers_UserId",
                table: "UserBusinessProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBusinessProfile_Bank_BankId",
                table: "UserBusinessProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBusinessProfile_City_CityId",
                table: "UserBusinessProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBusinessProfile_States_StateId",
                table: "UserBusinessProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBusinessProfile",
                table: "UserBusinessProfile");

            migrationBuilder.RenameTable(
                name: "UserBusinessProfile",
                newName: "BusinessProfile");

            migrationBuilder.RenameIndex(
                name: "IX_UserBusinessProfile_UserId",
                table: "BusinessProfile",
                newName: "IX_BusinessProfile_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBusinessProfile_StateId",
                table: "BusinessProfile",
                newName: "IX_BusinessProfile_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBusinessProfile_CityId",
                table: "BusinessProfile",
                newName: "IX_BusinessProfile_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBusinessProfile_BankId",
                table: "BusinessProfile",
                newName: "IX_BusinessProfile_BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessProfile",
                table: "BusinessProfile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessProfile_AspNetUsers_UserId",
                table: "BusinessProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessProfile_Bank_BankId",
                table: "BusinessProfile",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessProfile_City_CityId",
                table: "BusinessProfile",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessProfile_States_StateId",
                table: "BusinessProfile",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
