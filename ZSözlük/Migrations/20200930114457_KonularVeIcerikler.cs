using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZSözlük.Migrations
{
    public partial class KonularVeIcerikler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "Konular",
                columns: table => new
                {
                    KonuID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KonuBaslık = table.Column<string>(maxLength: 75, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konular", x => x.KonuID);
                });

         
            migrationBuilder.CreateTable(
                name: "Icerikler",
                columns: table => new
                {
                    IcerikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IcerikFull = table.Column<string>(nullable: true),
                    KonuID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icerikler", x => x.IcerikID);
                    table.ForeignKey(
                        name: "FK_Icerikler_Konular_KonuID",
                        column: x => x.KonuID,
                        principalTable: "Konular",
                        principalColumn: "KonuID",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_Icerikler_KonuID",
                table: "Icerikler",
                column: "KonuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropTable(
                name: "Icerikler");



            migrationBuilder.DropTable(
                name: "Konular");
        }
    }
}
