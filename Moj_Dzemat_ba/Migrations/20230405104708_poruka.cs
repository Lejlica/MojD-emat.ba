using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojDzematba.Migrations
{
    /// <inheritdoc />
    public partial class poruka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poruka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poruka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poruka_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Poruka_KorisnikId",
                table: "Poruka",
                column: "KorisnikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poruka");
        }
    }
}
