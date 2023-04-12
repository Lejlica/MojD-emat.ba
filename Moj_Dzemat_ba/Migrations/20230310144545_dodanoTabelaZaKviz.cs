using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojDzematba.Migrations
{
    /// <inheritdoc />
    public partial class dodanoTabelaZaKviz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polaze");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Polaze",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnikId = table.Column<int>(type: "int", nullable: false),
                    kvizId = table.Column<int>(type: "int", nullable: false),
                    bodovi = table.Column<int>(type: "int", nullable: false),
                    vrijemePokretanja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polaze", x => x.id);
                    table.ForeignKey(
                        name: "FK_Polaze_Korisnik_korisnikId",
                        column: x => x.korisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polaze_Kviz_kvizId",
                        column: x => x.kvizId,
                        principalTable: "Kviz",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Polaze_korisnikId",
                table: "Polaze",
                column: "korisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Polaze_kvizId",
                table: "Polaze",
                column: "kvizId");
        }
    }
}
