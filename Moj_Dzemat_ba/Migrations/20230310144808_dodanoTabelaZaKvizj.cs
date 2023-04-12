using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojDzematba.Migrations
{
    /// <inheritdoc />
    public partial class dodanoTabelaZaKvizj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AktivacijaKviza",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trajanjeMinute = table.Column<float>(type: "real", nullable: false),
                    pocetak = table.Column<DateTime>(type: "datetime2", nullable: false),
                    kraj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KvizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AktivacijaKviza", x => x.id);
                    table.ForeignKey(
                        name: "FK_AktivacijaKviza_Kviz_KvizId",
                        column: x => x.KvizId,
                        principalTable: "Kviz",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikKviz",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijemePokretanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vrijemeZavrsetka = table.Column<DateTime>(type: "datetime2", nullable: true),
                    uspjeh = table.Column<float>(type: "real", nullable: true),
                    korisnikPokrenuoId = table.Column<int>(type: "int", nullable: false),
                    AktivacijaKvizaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikKviz", x => x.id);
                    table.ForeignKey(
                        name: "FK_KorisnikKviz_AktivacijaKviza_AktivacijaKvizaId",
                        column: x => x.AktivacijaKvizaId,
                        principalTable: "AktivacijaKviza",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikKviz_KorisnickiNalog_korisnikPokrenuoId",
                        column: x => x.korisnikPokrenuoId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikKvizPitanja",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikKvizId = table.Column<int>(type: "int", nullable: false),
                    PitanjeId = table.Column<int>(type: "int", nullable: false),
                    maxBodovi = table.Column<float>(type: "real", nullable: true),
                    ostvareniBodovi = table.Column<float>(type: "real", nullable: true),
                    oznaceniOdgTekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OznaceniOdgovoriIDsString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikKvizPitanja", x => x.id);
                    table.ForeignKey(
                        name: "FK_KorisnikKvizPitanja_KorisnikKviz_KorisnikKvizId",
                        column: x => x.KorisnikKvizId,
                        principalTable: "KorisnikKviz",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikKvizPitanja_Pitanje_PitanjeId",
                        column: x => x.PitanjeId,
                        principalTable: "Pitanje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AktivacijaKviza_KvizId",
                table: "AktivacijaKviza",
                column: "KvizId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikKviz_AktivacijaKvizaId",
                table: "KorisnikKviz",
                column: "AktivacijaKvizaId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikKviz_korisnikPokrenuoId",
                table: "KorisnikKviz",
                column: "korisnikPokrenuoId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikKvizPitanja_KorisnikKvizId",
                table: "KorisnikKvizPitanja",
                column: "KorisnikKvizId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikKvizPitanja_PitanjeId",
                table: "KorisnikKvizPitanja",
                column: "PitanjeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisnikKvizPitanja");

            migrationBuilder.DropTable(
                name: "KorisnikKviz");

            migrationBuilder.DropTable(
                name: "AktivacijaKviza");
        }
    }
}
