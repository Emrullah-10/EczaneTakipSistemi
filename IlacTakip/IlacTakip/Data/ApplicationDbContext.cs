using Microsoft.EntityFrameworkCore;
using IlacTakip.Models;

namespace IlacTakip.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Sadece 3 Tablo - Temiz ve Basit
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Ilac> Ilaclar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Türkçe Tablo İsimleri
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Personel>().ToTable("Personeller");
            modelBuilder.Entity<Ilac>().ToTable("Ilaclar");

            // Decimal Precision Ayarları
            modelBuilder.Entity<Ilac>()
                .Property(i => i.Fiyat)
                .HasPrecision(18, 2);
                
            modelBuilder.Entity<Personel>()
                .Property(p => p.Maas)
                .HasPrecision(18, 2);

            // Türkçe Kolon İsimleri
            
            // Admin Tablosu
            modelBuilder.Entity<Admin>()
                .Property(a => a.Id).HasColumnName("AdminId");
            modelBuilder.Entity<Admin>()
                .Property(a => a.Ad).HasColumnName("Ad");
            modelBuilder.Entity<Admin>()
                .Property(a => a.Soyad).HasColumnName("Soyad");
            modelBuilder.Entity<Admin>()
                .Property(a => a.Email).HasColumnName("EPosta");
            modelBuilder.Entity<Admin>()
                .Property(a => a.Sifre).HasColumnName("Sifre");
            modelBuilder.Entity<Admin>()
                .Property(a => a.OlusturmaTarihi).HasColumnName("OlusturmaTarihi");
            modelBuilder.Entity<Admin>()
                .Property(a => a.SonGirisTarihi).HasColumnName("SonGirisTarihi");
            modelBuilder.Entity<Admin>()
                .Property(a => a.AktifMi).HasColumnName("AktifMi");

            // Personel Tablosu
            modelBuilder.Entity<Personel>()
                .Property(p => p.Id).HasColumnName("PersonelId");
            modelBuilder.Entity<Personel>()
                .Property(p => p.Ad).HasColumnName("Ad");
            modelBuilder.Entity<Personel>()
                .Property(p => p.Soyad).HasColumnName("Soyad");
            modelBuilder.Entity<Personel>()
                .Property(p => p.Telefon).HasColumnName("Telefon");
            modelBuilder.Entity<Personel>()
                .Property(p => p.Pozisyon).HasColumnName("Pozisyon");
            modelBuilder.Entity<Personel>()
                .Property(p => p.Maas).HasColumnName("Maas");
            modelBuilder.Entity<Personel>()
                .Property(p => p.IseBaslamaTarihi).HasColumnName("IseBaslamaTarihi");
            modelBuilder.Entity<Personel>()
                .Property(p => p.AktifMi).HasColumnName("AktifMi");
            modelBuilder.Entity<Personel>()
                .Property(p => p.OlusturmaTarihi).HasColumnName("OlusturmaTarihi");

            // Ilac Tablosu
            modelBuilder.Entity<Ilac>()
                .Property(i => i.Id).HasColumnName("IlacId");
            modelBuilder.Entity<Ilac>()
                .Property(i => i.Ad).HasColumnName("IlacAdi");
            modelBuilder.Entity<Ilac>()
                .Property(i => i.Aciklama).HasColumnName("Aciklama");
            modelBuilder.Entity<Ilac>()
                .Property(i => i.Fiyat).HasColumnName("Fiyat");
            modelBuilder.Entity<Ilac>()
                .Property(i => i.StokMiktari).HasColumnName("StokMiktari");
            modelBuilder.Entity<Ilac>()
                .Property(i => i.BarkodNumarasi).HasColumnName("BarkodNumarasi");
            modelBuilder.Entity<Ilac>()
                .Property(i => i.SonKullanmaTarihi).HasColumnName("SonKullanmaTarihi");
            modelBuilder.Entity<Ilac>()
                .Property(i => i.OlusturmaTarihi).HasColumnName("OlusturmaTarihi");
        }
    }
} 