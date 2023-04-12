using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojDzematba.Migrations
{
    /// <inheritdoc />
    public partial class kvizPitanje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KvizPitanje");
        }
    }
}
