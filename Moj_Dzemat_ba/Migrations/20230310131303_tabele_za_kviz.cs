using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojDzematba.Migrations
{
    /// <inheritdoc />
    public partial class tabelezakviz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kviz_Moderator_ModeratorId",
                table: "Kviz");

            migrationBuilder.DropForeignKey(
                name: "FK_KvizPitanje_Kviz_KvizId",
                table: "KvizPitanje");

            migrationBuilder.DropForeignKey(
                name: "FK_KvizPitanje_Pitanje_PitanjeId",
                table: "KvizPitanje");

            migrationBuilder.DropForeignKey(
                name: "FK_PonudjeniOdgovor_Pitanje_PitanjeID",
                table: "PonudjeniOdgovor");

            migrationBuilder.RenameColumn(
                name: "PitanjeID",
                table: "PonudjeniOdgovor",
                newName: "pitanjeId");

            migrationBuilder.RenameIndex(
                name: "IX_PonudjeniOdgovor_PitanjeID",
                table: "PonudjeniOdgovor",
                newName: "IX_PonudjeniOdgovor_pitanjeId");

            migrationBuilder.RenameColumn(
                name: "PitanjeId",
                table: "KvizPitanje",
                newName: "pitanjeId");

            migrationBuilder.RenameColumn(
                name: "KvizId",
                table: "KvizPitanje",
                newName: "kvizId");

            migrationBuilder.RenameIndex(
                name: "IX_KvizPitanje_PitanjeId",
                table: "KvizPitanje",
                newName: "IX_KvizPitanje_pitanjeId");

            migrationBuilder.RenameIndex(
                name: "IX_KvizPitanje_KvizId",
                table: "KvizPitanje",
                newName: "IX_KvizPitanje_kvizId");

            migrationBuilder.RenameColumn(
                name: "ModeratorId",
                table: "Kviz",
                newName: "moderator_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Kviz_ModeratorId",
                table: "Kviz",
                newName: "IX_Kviz_moderator_Id");

            migrationBuilder.AddColumn<string>(
                name: "opis",
                table: "Kviz",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Kviz_Moderator_moderator_Id",
                table: "Kviz",
                column: "moderator_Id",
                principalTable: "Moderator",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KvizPitanje_Kviz_kvizId",
                table: "KvizPitanje",
                column: "kvizId",
                principalTable: "Kviz",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KvizPitanje_Pitanje_pitanjeId",
                table: "KvizPitanje",
                column: "pitanjeId",
                principalTable: "Pitanje",
                principalColumn: "PitanjeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PonudjeniOdgovor_Pitanje_pitanjeId",
                table: "PonudjeniOdgovor",
                column: "pitanjeId",
                principalTable: "Pitanje",
                principalColumn: "PitanjeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kviz_Moderator_moderator_Id",
                table: "Kviz");

            migrationBuilder.DropForeignKey(
                name: "FK_KvizPitanje_Kviz_kvizId",
                table: "KvizPitanje");

            migrationBuilder.DropForeignKey(
                name: "FK_KvizPitanje_Pitanje_pitanjeId",
                table: "KvizPitanje");

            migrationBuilder.DropForeignKey(
                name: "FK_PonudjeniOdgovor_Pitanje_pitanjeId",
                table: "PonudjeniOdgovor");

            migrationBuilder.DropColumn(
                name: "opis",
                table: "Kviz");

            migrationBuilder.RenameColumn(
                name: "pitanjeId",
                table: "PonudjeniOdgovor",
                newName: "PitanjeID");

            migrationBuilder.RenameIndex(
                name: "IX_PonudjeniOdgovor_pitanjeId",
                table: "PonudjeniOdgovor",
                newName: "IX_PonudjeniOdgovor_PitanjeID");

            migrationBuilder.RenameColumn(
                name: "pitanjeId",
                table: "KvizPitanje",
                newName: "PitanjeId");

            migrationBuilder.RenameColumn(
                name: "kvizId",
                table: "KvizPitanje",
                newName: "KvizId");

            migrationBuilder.RenameIndex(
                name: "IX_KvizPitanje_pitanjeId",
                table: "KvizPitanje",
                newName: "IX_KvizPitanje_PitanjeId");

            migrationBuilder.RenameIndex(
                name: "IX_KvizPitanje_kvizId",
                table: "KvizPitanje",
                newName: "IX_KvizPitanje_KvizId");

            migrationBuilder.RenameColumn(
                name: "moderator_Id",
                table: "Kviz",
                newName: "ModeratorId");

            migrationBuilder.RenameIndex(
                name: "IX_Kviz_moderator_Id",
                table: "Kviz",
                newName: "IX_Kviz_ModeratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kviz_Moderator_ModeratorId",
                table: "Kviz",
                column: "ModeratorId",
                principalTable: "Moderator",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KvizPitanje_Kviz_KvizId",
                table: "KvizPitanje",
                column: "KvizId",
                principalTable: "Kviz",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KvizPitanje_Pitanje_PitanjeId",
                table: "KvizPitanje",
                column: "PitanjeId",
                principalTable: "Pitanje",
                principalColumn: "PitanjeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PonudjeniOdgovor_Pitanje_PitanjeID",
                table: "PonudjeniOdgovor",
                column: "PitanjeID",
                principalTable: "Pitanje",
                principalColumn: "PitanjeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
