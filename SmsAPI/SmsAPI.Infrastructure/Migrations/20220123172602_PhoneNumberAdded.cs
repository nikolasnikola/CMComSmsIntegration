using Microsoft.EntityFrameworkCore.Migrations;

namespace SmsAPI.Infrastructure.Migrations
{
    public partial class PhoneNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToUserId",
                table: "SMSResponses");

            migrationBuilder.AddColumn<string>(
                name: "MessageStatus",
                table: "SMSResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "SMSResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToUserPhoneNumber",
                table: "SMSResponses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageStatus",
                table: "SMSResponses");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "SMSResponses");

            migrationBuilder.DropColumn(
                name: "ToUserPhoneNumber",
                table: "SMSResponses");

            migrationBuilder.AddColumn<int>(
                name: "ToUserId",
                table: "SMSResponses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
