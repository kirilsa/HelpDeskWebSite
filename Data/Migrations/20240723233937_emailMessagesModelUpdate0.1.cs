using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDeskWebSite.Data.Migrations
{
    public partial class emailMessagesModelUpdate01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Timestamp",
                table: "EmailMessages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AttachmentCount",
                table: "EmailMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BodyHtml",
                table: "EmailMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BodyPlain",
                table: "EmailMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContentIdMap",
                table: "EmailMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MessageHeaders",
                table: "EmailMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StrippedHtml",
                table: "EmailMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StrippedSignature",
                table: "EmailMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StrippedText",
                table: "EmailMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachmentCount",
                table: "EmailMessages");

            migrationBuilder.DropColumn(
                name: "BodyHtml",
                table: "EmailMessages");

            migrationBuilder.DropColumn(
                name: "BodyPlain",
                table: "EmailMessages");

            migrationBuilder.DropColumn(
                name: "ContentIdMap",
                table: "EmailMessages");

            migrationBuilder.DropColumn(
                name: "MessageHeaders",
                table: "EmailMessages");

            migrationBuilder.DropColumn(
                name: "StrippedHtml",
                table: "EmailMessages");

            migrationBuilder.DropColumn(
                name: "StrippedSignature",
                table: "EmailMessages");

            migrationBuilder.DropColumn(
                name: "StrippedText",
                table: "EmailMessages");

            migrationBuilder.AlterColumn<int>(
                name: "Timestamp",
                table: "EmailMessages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
