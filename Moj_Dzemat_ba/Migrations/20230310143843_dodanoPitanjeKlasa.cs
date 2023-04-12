using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojDzematba.Migrations
{
    /// <inheritdoc />
    public partial class dodanoPitanjeKlasa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pitanje",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    bodovi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitanje", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PonudjeniOdgovor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isCorrect = table.Column<bool>(type: "bit", nullable: false),
                    pitanjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PonudjeniOdgovor", x => x.id);
                    table.ForeignKey(
                        name: "FK_PonudjeniOdgovor_Pitanje_pitanjeId",
                        column: x => x.pitanjeId,
                        principalTable: "Pitanje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PonudjeniOdgovor_pitanjeId",
                table: "PonudjeniOdgovor",
                column: "pitanjeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PonudjeniOdgovor");

            migrationBuilder.DropTable(
                name: "Pitanje");
        }
    }
}
