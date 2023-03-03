using Microsoft.EntityFrameworkCore.Migrations;

namespace Comments.Infrastructure.Migrations
{
    public partial class addfilenamecomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAttachment",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Comments");

            migrationBuilder.AddColumn<bool>(
                name: "HasAttachment",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
