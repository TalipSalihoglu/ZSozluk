using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZSözlük.Migrations
{
    public partial class addedApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Icerikler",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Icerikler_UserId",
                table: "Icerikler",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Icerikler_AspNetUsers_UserId",
                table: "Icerikler",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icerikler_AspNetUsers_UserId",
                table: "Icerikler");

            migrationBuilder.DropIndex(
                name: "IX_Icerikler_UserId",
                table: "Icerikler");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Icerikler");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
