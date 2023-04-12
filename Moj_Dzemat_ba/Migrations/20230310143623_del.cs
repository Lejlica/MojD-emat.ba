using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojDzematba.Migrations
{
    /// <inheritdoc />
    public partial class del : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KvizPitanje");

            migrationBuilder.DropTable(
                name: "OdabraniOdgovor");

            migrationBuilder.DropTable(
                name: "PonudjeniOdgovor");

            migrationBuilder.DropTable(
                name: "Pitanje");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pitanje",
                columns: table => new
                {
                    PitanjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    tekst = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitanje", x => x.PitanjeID);
                });

            migrationBuilder.CreateTable(
                name: "KvizPitanje",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kvizId = table.Column<int>(type: "int", nullable: false),
                    pitanjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KvizPitanje", x => x.id);
                    table.ForeignKey(
                        name: "FK_KvizPitanje_Kviz_kvizId",
                        column: x => x.kvizId,
                        principalTable: "Kviz",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KvizPitanje_Pitanje_pitanjeId",
                        column: x => x.pitanjeId,
                        principalTable: "Pitanje",
                        principalColumn: "PitanjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PonudjeniOdgovor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pitanjeId = table.Column<int>(type: "int", nullable: false),
                    isCorrect = table.Column<bool>(type: "bit", nullable: false),
                    tekst = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PonudjeniOdgovor", x => x.id);
                    table.ForeignKey(
                        name: "FK_PonudjeniOdgovor_Pitanje_pitanjeId",
                        column: x => x.pitanjeId,
                        principalTable: "Pitanje",
                        principalColumn: "PitanjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdabraniOdgovor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolazeId = table.Column<int>(type: "int", nullable: false),
                    PonudjeniOdgovorId = table.Column<int>(type: "int", nullable: false),
                    isCorrect = table.Column<bool>(type: "bit", nullable: false),
                    vrijemeOdgovora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdabraniOdgovor", x => x.id);
                    table.ForeignKey(
                        name: "FK_OdabraniOdgovor_Polaze_PolazeId",
                        column: x => x.PolazeId,
                        principalTable: "Polaze",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdabraniOdgovor_PonudjeniOdgovor_PonudjeniOdgovorId",
                        column: x => x.PonudjeniOdgovorId,
                        principalTable: "PonudjeniOdgovor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KvizPitanje_kvizId",
                table: "KvizPitanje",
                column: "kvizId");

            migrationBuilder.CreateIndex(
                name: "IX_KvizPitanje_pitanjeId",
                table: "KvizPitanje",
                column: "pitanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_OdabraniOdgovor_PolazeId",
                table: "OdabraniOdgovor",
                column: "PolazeId");

            migrationBuilder.CreateIndex(
                name: "IX_OdabraniOdgovor_PonudjeniOdgovorId",
                table: "OdabraniOdgovor",
                column: "PonudjeniOdgovorId");

            migrationBuilder.CreateIndex(
                name: "IX_PonudjeniOdgovor_pitanjeId",
                table: "PonudjeniOdgovor",
                column: "pitanjeId");
        }
    }
}
