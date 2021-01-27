using Microsoft.EntityFrameworkCore.Migrations;

namespace ZSözlük.Migrations
{
    public partial class addSocialMediaColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link_facebook",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link_insta",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link_twitter",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link_facebook",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Link_insta",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Link_twitter",
                table: "AspNetUsers");
        }
    }
}
