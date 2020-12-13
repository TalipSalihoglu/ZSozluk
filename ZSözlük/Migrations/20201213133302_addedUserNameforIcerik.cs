using Microsoft.EntityFrameworkCore.Migrations;

namespace ZSözlük.Migrations
{
    public partial class addedUserNameforIcerik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icerikler_AspNetUsers_UserId",
                table: "Icerikler");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Icerikler",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Icerikler_UserId",
                table: "Icerikler",
                newName: "IX_Icerikler_UserID");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Icerikler",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Icerikler_AspNetUsers_UserID",
                table: "Icerikler",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icerikler_AspNetUsers_UserID",
                table: "Icerikler");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Icerikler");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Icerikler",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Icerikler_UserID",
                table: "Icerikler",
                newName: "IX_Icerikler_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Icerikler_AspNetUsers_UserId",
                table: "Icerikler",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
