using Microsoft.EntityFrameworkCore.Migrations;

namespace MMFS_Context.Migrations
{
    public partial class Update_UserProfile_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBusinessProfile_AspNetUsers_UserId",
                table: "UserBusinessProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChequeProfile_AspNetUsers_UserId",
                table: "UserChequeProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEmergencyProfile_AspNetUsers_UserId",
                table: "UserEmergencyProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPersonalProfile_AspNetUsers_UserId",
                table: "UserPersonalProfile");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBusinessProfile_AspNetUsers_UserId",
                table: "UserBusinessProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChequeProfile_AspNetUsers_UserId",
                table: "UserChequeProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEmergencyProfile_AspNetUsers_UserId",
                table: "UserEmergencyProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPersonalProfile_AspNetUsers_UserId",
                table: "UserPersonalProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBusinessProfile_AspNetUsers_UserId",
                table: "UserBusinessProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChequeProfile_AspNetUsers_UserId",
                table: "UserChequeProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEmergencyProfile_AspNetUsers_UserId",
                table: "UserEmergencyProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPersonalProfile_AspNetUsers_UserId",
                table: "UserPersonalProfile");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBusinessProfile_AspNetUsers_UserId",
                table: "UserBusinessProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChequeProfile_AspNetUsers_UserId",
                table: "UserChequeProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEmergencyProfile_AspNetUsers_UserId",
                table: "UserEmergencyProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPersonalProfile_AspNetUsers_UserId",
                table: "UserPersonalProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
