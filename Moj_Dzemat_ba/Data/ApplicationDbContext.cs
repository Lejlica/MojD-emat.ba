using FIT_Api_Example.Modul0_Autentifikacija.Models;
using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul2.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.SqlTypes;
using System;

namespace FIT_Api_Example.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }
        
        public DbSet<Korisnik> Korisnik { get; set; }
      
        public DbSet<Aktivnost> Aktivnost { get; set; }
 
        public DbSet<PrijavaAktivnosti> PrijavaAktivnosti { get;set; }
        public DbSet<Dzemat> Dzemat { get; set; }
        public DbSet<Kviz> Kviz { get; set; }
       
        public DbSet<Porodica> Porodica { get; set; }
        public DbSet<Clan> Clan { get; set; }
        public DbSet<Imam> Imam { get; set; }
        public DbSet<Vijest> Vijest { get; set; }
        public DbSet<Slika> Slika { get; set; }
        public DbSet<Medzlis> Medzlis { get; set; }
        public DbSet<Muftijstvo> Muftijstvo { get; set; }
        public DbSet<Moderator> Moderator { get; set; }
        public DbSet<DuhovnaVjezba> DuhovnaVjezba { get; set; }
        public DbSet<DnevnaVjezba> DnevnaVjezba { get; set; }
        public DbSet<MojeVjezbe> MojeVjezbe { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<LogKretanjePoSistemu> LogKretanjePoSistemu { get; set; }
        public DbSet<PonudjeniOdgovor> PonudjeniOdgovor { get; set; }
        public DbSet<Pitanje> Pitanje { get; set; }
        public DbSet<KvizPitanje> KvizPitanje { get; set; }
        public DbSet<AktivacijaKviza> AktivacijaKviza { get; set; }
        public DbSet<KorisnikKviz> KorisnikKviz { get; set; }
        public DbSet<KorisnikKvizPitanja> KorisnikKvizPitanja { get; set; }
        public DbSet<Poruka> Poruka { get; set; }



        // public DbSet<VijestOdabrana> VijestOdabrana { get; set; } ne treba

        //public DbSet<Blog> Blogs { get; set; }
        //public DbSet<RssBlog> RssBlogs { get; set; }


        //public class Blog
        //{
        //    public int BlogId { get; set; }
        //    public string Url { get; set; }
        //}

        //public class RssBlog : Blog
        //{
        //    public string RssUrl { get; set; }
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Blog>()
        //        .HasDiscriminator<string>("blog_type")
        //        .HasValue<Blog>("blog_base")
        //        .HasValue<RssBlog>("blog_rss");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Blog>()
        //        .Property("Discriminator")
        //        .HasMaxLength(200);
        //}
        public DbSet<BlogBase> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(b => b.Url)
                .HasColumnName("Url");

            modelBuilder.Entity<RssBlog>()
                .Property(b => b.Url)
                .HasColumnName("Url");
        }
        public abstract class BlogBase
        {
            [Key]
            public int BlogId { get; set; }
        }

        public class Blog : BlogBase
        {
            public string Url { get; set; }
        }

        public class RssBlog : BlogBase
        {
            public string Url { get; set; }
        }

        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    //ovdje pise FluentAPI konfiguraciju

        //    //modelBuilder.Entity<Student>().ToTable("Student");
        //    //modelBuilder.Entity<Nastavnik>().ToTable("Nastavnik");
        //}

    }
}
