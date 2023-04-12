using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojDzematba.Migrations
{
    /// <inheritdoc />
    public partial class korisNalogFKuPrijavaAktivnostitabeli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrijavaAktivnosti_Korisnik_KorisnikId",
                table: "PrijavaAktivnosti");

            migrationBuilder.RenameColumn(
                name: "KorisnikId",
                table: "PrijavaAktivnosti",
                newName: "korisnickiNalogPrijavljenogId");

            migrationBuilder.RenameIndex(
                name: "IX_PrijavaAktivnosti_KorisnikId",
                table: "PrijavaAktivnosti",
                newName: "IX_PrijavaAktivnosti_korisnickiNalogPrijavljenogId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrijavaAktivnosti_KorisnickiNalog_korisnickiNalogPrijavljenogId",
                table: "PrijavaAktivnosti",
                column: "korisnickiNalogPrijavljenogId",
                principalTable: "KorisnickiNalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrijavaAktivnosti_KorisnickiNalog_korisnickiNalogPrijavljenogId",
                table: "PrijavaAktivnosti");

            migrationBuilder.RenameColumn(
                name: "korisnickiNalogPrijavljenogId",
                table: "PrijavaAktivnosti",
                newName: "KorisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_PrijavaAktivnosti_korisnickiNalogPrijavljenogId",
                table: "PrijavaAktivnosti",
                newName: "IX_PrijavaAktivnosti_KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrijavaAktivnosti_Korisnik_KorisnikId",
                table: "PrijavaAktivnosti",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
