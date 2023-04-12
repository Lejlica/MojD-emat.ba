﻿// <auto-generated />
using System;
using FIT_Api_Example.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MojDzematba.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230124141857_m")]
    partial class m
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FIT_Api_Example.Data.ApplicationDbContext+BlogBase", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogId"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BlogBase");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FIT_Api_Example.Modul0_Autentifikacija.Models.AutentifikacijaToken", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("KorisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<string>("ipAdresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vrijednost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("vrijemeEvidentiranja")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("AutentifikacijaToken");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul0_Autentifikacija.Models.KorisnickiNalog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("korisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("KorisnickiNalog");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("FIT_Api_Example.Modul1.Models.PonudjeniOdgovor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("PitanjeID")
                        .HasColumnType("int");

                    b.Property<bool>("isCorrect")
                        .HasColumnType("bit");

                    b.Property<string>("tekst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("PitanjeID");

                    b.ToTable("PonudjeniOdgovor");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Aktivnost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lokacija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aktivnost");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Clan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Mekteb")
                        .HasColumnType("bit");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OdnosSaNosiocem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PorodicaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PorodicaID");

                    b.ToTable("Clan");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.DnevnaVjezba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<int>("DuhovnaVjezbaId")
                        .HasColumnType("int");

                    b.Property<string>("Naslov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tekst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uvod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DuhovnaVjezbaId");

                    b.ToTable("DnevnaVjezba");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.DuhovnaVjezba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumPocetka")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZavrsetka")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ModeratorId")
                        .HasColumnType("int");

                    b.Property<string>("Naslov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tekst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("slika_korisnika_bytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModeratorId");

                    b.ToTable("DuhovnaVjezba");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Dzemat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DzematskiOdbor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Informacije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KratkiOpis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LokacijaDzamije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedzlisId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("slika_dzemata_bytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("MedzlisId");

                    b.ToTable("Dzemat");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Kviz", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("ModeratorId")
                        .HasColumnType("int");

                    b.Property<int>("brojPitanja")
                        .HasColumnType("int");

                    b.Property<DateTime>("datumKviza")
                        .HasColumnType("datetime2");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vrstaKviza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("ModeratorId");

                    b.ToTable("Kviz");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.KvizPitanje", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("KvizId")
                        .HasColumnType("int");

                    b.Property<int>("PitanjeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("KvizId");

                    b.HasIndex("PitanjeId");

                    b.ToTable("KvizPitanje");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Medzlis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Informacije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MuftijstvoId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MuftijstvoId");

                    b.ToTable("Medzlis");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.MojeVjezbe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DuhovnaVjezbaId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DuhovnaVjezbaId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("MojeVjezbe");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Muftijstvo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Informacije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KontaktOsoba")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Muftijstvo");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.OdabraniOdgovor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("PolazeId")
                        .HasColumnType("int");

                    b.Property<int>("PonudjeniOdgovorId")
                        .HasColumnType("int");

                    b.Property<bool>("isCorrect")
                        .HasColumnType("bit");

                    b.Property<DateTime>("vrijemeOdgovora")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("PolazeId");

                    b.HasIndex("PonudjeniOdgovorId");

                    b.ToTable("OdabraniOdgovor");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Pitanje", b =>
                {
                    b.Property<int>("PitanjeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PitanjeID"));

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("tekst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PitanjeID");

                    b.ToTable("Pitanje");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Polaze", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("bodovi")
                        .HasColumnType("int");

                    b.Property<int>("korisnikId")
                        .HasColumnType("int");

                    b.Property<int>("kvizId")
                        .HasColumnType("int");

                    b.Property<DateTime>("vrijemePokretanja")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("korisnikId");

                    b.HasIndex("kvizId");

                    b.ToTable("Polaze");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Porodica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ClanoviHarema")
                        .HasColumnType("bit");

                    b.Property<bool>("ClanoviIZ")
                        .HasColumnType("bit");

                    b.Property<string>("Lokacija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NosiocPorodice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dzematId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("dzematId");

                    b.ToTable("Porodica");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.PrijavaAktivnosti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AktivnostId")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<DateTime>("VrijemePrijave")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AktivnostId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("PrijavaAktivnosti");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Slika", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VijestId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("VijestId");

                    b.ToTable("Slika");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Vijest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("ImamId")
                        .HasColumnType("int");

                    b.Property<string>("Naslov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tekst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("slika_bajtovi")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImamId");

                    b.ToTable("Vijest");
                });

            modelBuilder.Entity("FIT_Api_Example.Data.ApplicationDbContext+Blog", b =>
                {
                    b.HasBaseType("FIT_Api_Example.Data.ApplicationDbContext+BlogBase");

                    b.Property<string>("Url")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Url");

                    b.HasDiscriminator().HasValue("Blog");
                });

            modelBuilder.Entity("FIT_Api_Example.Data.ApplicationDbContext+RssBlog", b =>
                {
                    b.HasBaseType("FIT_Api_Example.Data.ApplicationDbContext+BlogBase");

                    b.Property<string>("Url")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Url");

                    b.HasDiscriminator().HasValue("RssBlog");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Imam", b =>
                {
                    b.HasBaseType("FIT_Api_Example.Modul0_Autentifikacija.Models.KorisnickiNalog");

                    b.Property<string>("Biografija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumImenovanja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Fakultet")
                        .HasColumnType("bit");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dzematId")
                        .HasColumnType("int");

                    b.Property<byte[]>("slika_imama_bytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasIndex("dzematId");

                    b.ToTable("Imam");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Korisnik", b =>
                {
                    b.HasBaseType("FIT_Api_Example.Modul0_Autentifikacija.Models.KorisnickiNalog");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dzematId")
                        .HasColumnType("int");

                    b.HasIndex("dzematId");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Moderator", b =>
                {
                    b.HasBaseType("FIT_Api_Example.Modul0_Autentifikacija.Models.KorisnickiNalog");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Moderator");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul0_Autentifikacija.Models.AutentifikacijaToken", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul0_Autentifikacija.Models.KorisnickiNalog", "korisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnickiNalog");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul1.Models.PonudjeniOdgovor", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.Pitanje", "Pitanje")
                        .WithMany()
                        .HasForeignKey("PitanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pitanje");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Clan", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.Porodica", "Porodica")
                        .WithMany()
                        .HasForeignKey("PorodicaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Porodica");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.DnevnaVjezba", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.DuhovnaVjezba", "DuhovnaVjezba")
                        .WithMany()
                        .HasForeignKey("DuhovnaVjezbaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DuhovnaVjezba");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.DuhovnaVjezba", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.Moderator", "Moderator")
                        .WithMany()
                        .HasForeignKey("ModeratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Moderator");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Dzemat", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.Medzlis", "Medzlis")
                        .WithMany()
                        .HasForeignKey("MedzlisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medzlis");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Kviz", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.Moderator", "Moderator")
                        .WithMany()
                        .HasForeignKey("ModeratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Moderator");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.KvizPitanje", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.Kviz", "Kviz")
                        .WithMany()
                        .HasForeignKey("KvizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_Api_Example.Modul2.Models.Pitanje", "Pitanje")
                        .WithMany()
                        .HasForeignKey("PitanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kviz");

                    b.Navigation("Pitanje");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Medzlis", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.Muftijstvo", "Muftijstvo")
                        .WithMany()
                        .HasForeignKey("MuftijstvoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Muftijstvo");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.MojeVjezbe", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.DuhovnaVjezba", "DuhovnaVjezba")
                        .WithMany()
                        .HasForeignKey("DuhovnaVjezbaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_Api_Example.Modul2.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DuhovnaVjezba");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.OdabraniOdgovor", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.Polaze", "Polaze")
                        .WithMany()
                        .HasForeignKey("PolazeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_Api_Example.Modul1.Models.PonudjeniOdgovor", "PonudjeniOdgovor")
                        .WithMany()
                        .HasForeignKey("PonudjeniOdgovorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Polaze");

                    b.Navigation("PonudjeniOdgovor");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Polaze", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_Api_Example.Modul2.Models.Kviz", "kviz")
                        .WithMany()
                        .HasForeignKey("kvizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnik");

                    b.Navigation("kviz");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Porodica", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.Dzemat", "dzemat")
                        .WithMany()
                        .HasForeignKey("dzematId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dzemat");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.PrijavaAktivnosti", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.Aktivnost", "Aktivnost")
                        .WithMany()
                        .HasForeignKey("AktivnostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_Api_Example.Modul2.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aktivnost");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Slika", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.Vijest", "Vijest")
                        .WithMany()
                        .HasForeignKey("VijestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vijest");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Vijest", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.Imam", "Imam")
                        .WithMany()
                        .HasForeignKey("ImamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imam");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Imam", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.Dzemat", "dzemat")
                        .WithMany()
                        .HasForeignKey("dzematId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_Api_Example.Modul0_Autentifikacija.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("FIT_Api_Example.Modul2.Models.Imam", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dzemat");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Korisnik", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul2.Models.Dzemat", "dzemat")
                        .WithMany()
                        .HasForeignKey("dzematId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_Api_Example.Modul0_Autentifikacija.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("FIT_Api_Example.Modul2.Models.Korisnik", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dzemat");
                });

            modelBuilder.Entity("FIT_Api_Example.Modul2.Models.Moderator", b =>
                {
                    b.HasOne("FIT_Api_Example.Modul0_Autentifikacija.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("FIT_Api_Example.Modul2.Models.Moderator", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
