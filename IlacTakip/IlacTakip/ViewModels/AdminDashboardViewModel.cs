using IlacTakip.Models;

namespace IlacTakip.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int ToplamIlac { get; set; }
        public int ToplamPersonel { get; set; }
        public decimal ToplamMaasGideri { get; set; }
        
        public List<Ilac> StokUyarisiIlaclar { get; set; } = new List<Ilac>();
        public List<Ilac> SonKullanmaUyarisiIlaclar { get; set; } = new List<Ilac>();
        
        // Dashboard İstatistikleri
        public decimal ToplamIlacDegeri { get; set; }
        public int AktifPersonelSayisi { get; set; }
    }
} 