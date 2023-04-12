using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojDzematba.Migrations
{
    /// <inheritdoc />
    public partial class inicijalna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktivnost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lokacija = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktivnost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Muftijstvo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Informacije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KontaktOsoba = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muftijstvo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pitanje",
                columns: table => new
                {
                    PitanjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitanje", x => x.PitanjeID);
                });

            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickiNalogId = table.Column<int>(type: "int", nullable: false),
                    vrijemeEvidentiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ipAdresa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.id);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Moderator",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moderator", x => x.id);
                    table.ForeignKey(
                        name: "FK_Moderator_KorisnickiNalog_id",
                        column: x => x.id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Medzlis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Informacije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuftijstvoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medzlis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medzlis_Muftijstvo_MuftijstvoId",
                        column: x => x.MuftijstvoId,
                        principalTable: "Muftijstvo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PonudjeniOdgovor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isCorrect = table.Column<bool>(type: "bit", nullable: false),
                    PitanjeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PonudjeniOdgovor", x => x.id);
                    table.ForeignKey(
                        name: "FK_PonudjeniOdgovor_Pitanje_PitanjeID",
                        column: x => x.PitanjeID,
                        principalTable: "Pitanje",
                        principalColumn: "PitanjeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DuhovnaVjezba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumPocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    slikakorisnikabytes = table.Column<byte[]>(name: "slika_korisnika_bytes", type: "varbinary(max)", nullable: false),
                    ModeratorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuhovnaVjezba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuhovnaVjezba_Moderator_ModeratorId",
                        column: x => x.ModeratorId,
                        principalTable: "Moderator",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Kviz",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vrstaKviza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumKviza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    brojPitanja = table.Column<int>(type: "int", nullable: false),
                    ModeratorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kviz", x => x.id);
                    table.ForeignKey(
                        name: "FK_Kviz_Moderator_ModeratorId",
                        column: x => x.ModeratorId,
                        principalTable: "Moderator",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Dzemat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KratkiOpis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DzematskiOdbor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slikadzematabytes = table.Column<byte[]>(name: "slika_dzemata_bytes", type: "varbinary(max)", nullable: false),
                    LokacijaDzamije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Informacije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedzlisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dzemat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dzemat_Medzlis_MedzlisId",
                        column: x => x.MedzlisId,
                        principalTable: "Medzlis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DnevnaVjezba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uvod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumObjave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuhovnaVjezbaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DnevnaVjezba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DnevnaVjezba_DuhovnaVjezba_DuhovnaVjezbaId",
                        column: x => x.DuhovnaVjezbaId,
                        principalTable: "DuhovnaVjezba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KvizPitanje",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KvizId = table.Column<int>(type: "int", nullable: false),
                    PitanjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KvizPitanje", x => x.id);
                    table.ForeignKey(
                        name: "FK_KvizPitanje_Kviz_KvizId",
                        column: x => x.KvizId,
                        principalTable: "Kviz",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KvizPitanje_Pitanje_PitanjeId",
                        column: x => x.PitanjeId,
                        principalTable: "Pitanje",
                        principalColumn: "PitanjeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Imam",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biografija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slikaimamabytes = table.Column<byte[]>(name: "slika_imama_bytes", type: "varbinary(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fakultet = table.Column<bool>(type: "bit", nullable: false),
                    DatumImenovanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dzematId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imam", x => x.id);
                    table.ForeignKey(
                        name: "FK_Imam_Dzemat_dzematId",
                        column: x => x.dzematId,
                        principalTable: "Dzemat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Imam_KorisnickiNalog_id",
                        column: x => x.id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dzematId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.id);
                    table.ForeignKey(
                        name: "FK_Korisnik_Dzemat_dzematId",
                        column: x => x.dzematId,
                        principalTable: "Dzemat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Korisnik_KorisnickiNalog_id",
                        column: x => x.id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Porodica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NosiocPorodice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokacija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClanoviIZ = table.Column<bool>(type: "bit", nullable: false),
                    ClanoviHarema = table.Column<bool>(type: "bit", nullable: false),
                    dzematId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porodica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Porodica_Dzemat_dzematId",
                        column: x => x.dzematId,
                        principalTable: "Dzemat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Vijest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    slikabajtovi = table.Column<byte[]>(name: "slika_bajtovi", type: "varbinary(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vijest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vijest_Imam_ImamId",
                        column: x => x.ImamId,
                        principalTable: "Imam",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MojeVjezbe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    DuhovnaVjezbaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MojeVjezbe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MojeVjezbe_DuhovnaVjezba_DuhovnaVjezbaId",
                        column: x => x.DuhovnaVjezbaId,
                        principalTable: "DuhovnaVjezba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MojeVjezbe_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Polaze",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijemePokretanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bodovi = table.Column<int>(type: "int", nullable: false),
                    korisnikId = table.Column<int>(type: "int", nullable: false),
                    kvizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polaze", x => x.id);
                    table.ForeignKey(
                        name: "FK_Polaze_Korisnik_korisnikId",
                        column: x => x.korisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Polaze_Kviz_kvizId",
                        column: x => x.kvizId,
                        principalTable: "Kviz",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PrijavaAktivnosti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrijemePrijave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    AktivnostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijavaAktivnosti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrijavaAktivnosti_Aktivnost_AktivnostId",
                        column: x => x.AktivnostId,
                        principalTable: "Aktivnost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrijavaAktivnosti_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Clan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdnosSaNosiocem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PorodicaID = table.Column<int>(type: "int", nullable: false),
                    Mekteb = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clan_Porodica_PorodicaID",
                        column: x => x.PorodicaID,
                        principalTable: "Porodica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Slika",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VijestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slika", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Slika_Vijest_VijestId",
                        column: x => x.VijestId,
                        principalTable: "Vijest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OdabraniOdgovor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijemeOdgovora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isCorrect = table.Column<bool>(type: "bit", nullable: false),
                    PonudjeniOdgovorId = table.Column<int>(type: "int", nullable: false),
                    PolazeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdabraniOdgovor", x => x.id);
                    table.ForeignKey(
                        name: "FK_OdabraniOdgovor_Polaze_PolazeId",
                        column: x => x.PolazeId,
                        principalTable: "Polaze",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OdabraniOdgovor_PonudjeniOdgovor_PonudjeniOdgovorId",
                        column: x => x.PonudjeniOdgovorId,
                        principalTable: "PonudjeniOdgovor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Clan_PorodicaID",
                table: "Clan",
                column: "PorodicaID");

            migrationBuilder.CreateIndex(
                name: "IX_DnevnaVjezba_DuhovnaVjezbaId",
                table: "DnevnaVjezba",
                column: "DuhovnaVjezbaId");

            migrationBuilder.CreateIndex(
                name: "IX_DuhovnaVjezba_ModeratorId",
                table: "DuhovnaVjezba",
                column: "ModeratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Dzemat_MedzlisId",
                table: "Dzemat",
                column: "MedzlisId");

            migrationBuilder.CreateIndex(
                name: "IX_Imam_dzematId",
                table: "Imam",
                column: "dzematId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_dzematId",
                table: "Korisnik",
                column: "dzematId");

            migrationBuilder.CreateIndex(
                name: "IX_Kviz_ModeratorId",
                table: "Kviz",
                column: "ModeratorId");

            migrationBuilder.CreateIndex(
                name: "IX_KvizPitanje_KvizId",
                table: "KvizPitanje",
                column: "KvizId");

            migrationBuilder.CreateIndex(
                name: "IX_KvizPitanje_PitanjeId",
                table: "KvizPitanje",
                column: "PitanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medzlis_MuftijstvoId",
                table: "Medzlis",
                column: "MuftijstvoId");

            migrationBuilder.CreateIndex(
                name: "IX_MojeVjezbe_DuhovnaVjezbaId",
                table: "MojeVjezbe",
                column: "DuhovnaVjezbaId");

            migrationBuilder.CreateIndex(
                name: "IX_MojeVjezbe_KorisnikId",
                table: "MojeVjezbe",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_OdabraniOdgovor_PolazeId",
                table: "OdabraniOdgovor",
                column: "PolazeId");

            migrationBuilder.CreateIndex(
                name: "IX_OdabraniOdgovor_PonudjeniOdgovorId",
                table: "OdabraniOdgovor",
                column: "PonudjeniOdgovorId");

            migrationBuilder.CreateIndex(
                name: "IX_Polaze_korisnikId",
                table: "Polaze",
                column: "korisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Polaze_kvizId",
                table: "Polaze",
                column: "kvizId");

            migrationBuilder.CreateIndex(
                name: "IX_PonudjeniOdgovor_PitanjeID",
                table: "PonudjeniOdgovor",
                column: "PitanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Porodica_dzematId",
                table: "Porodica",
                column: "dzematId");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaAktivnosti_AktivnostId",
                table: "PrijavaAktivnosti",
                column: "AktivnostId");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaAktivnosti_KorisnikId",
                table: "PrijavaAktivnosti",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Slika_VijestId",
                table: "Slika",
                column: "VijestId");

            migrationBuilder.CreateIndex(
                name: "IX_Vijest_ImamId",
                table: "Vijest",
                column: "ImamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutentifikacijaToken");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Clan");

            migrationBuilder.DropTable(
                name: "DnevnaVjezba");

            migrationBuilder.DropTable(
                name: "KvizPitanje");

            migrationBuilder.DropTable(
                name: "MojeVjezbe");

            migrationBuilder.DropTable(
                name: "OdabraniOdgovor");

            migrationBuilder.DropTable(
                name: "PrijavaAktivnosti");

            migrationBuilder.DropTable(
                name: "Slika");

            migrationBuilder.DropTable(
                name: "Porodica");

            migrationBuilder.DropTable(
                name: "DuhovnaVjezba");

            migrationBuilder.DropTable(
                name: "Polaze");

            migrationBuilder.DropTable(
                name: "PonudjeniOdgovor");

            migrationBuilder.DropTable(
                name: "Aktivnost");

            migrationBuilder.DropTable(
                name: "Vijest");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Kviz");

            migrationBuilder.DropTable(
                name: "Pitanje");

            migrationBuilder.DropTable(
                name: "Imam");

            migrationBuilder.DropTable(
                name: "Moderator");

            migrationBuilder.DropTable(
                name: "Dzemat");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "Medzlis");

            migrationBuilder.DropTable(
                name: "Muftijstvo");
        }
    }
}
