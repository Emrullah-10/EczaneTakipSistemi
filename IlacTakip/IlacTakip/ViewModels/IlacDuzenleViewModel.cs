using System.ComponentModel.DataAnnotations;

namespace IlacTakip.ViewModels
{
    public class IlacDuzenleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "İlaç adı zorunludur")]
        [Display(Name = "İlaç Adı")]
        public string Ad { get; set; } = string.Empty;

        [Display(Name = "Açıklama")]
        public string? Aciklama { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur")]
        [Display(Name = "Fiyat")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır")]
        public decimal Fiyat { get; set; }

        [Display(Name = "Stok Miktarı")]
        [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı 0'dan küçük olamaz")]
        public int StokMiktari { get; set; }

        [Display(Name = "Reçeteli mi?")]
        public bool ReceteliMi { get; set; }

        [Display(Name = "Kategori")]
        public string? Kategori { get; set; }

        [Display(Name = "Üretici")]
        public string? Uretici { get; set; }

        [Display(Name = "Barkod Numarası")]
        public string? BarkodNumarasi { get; set; }

        [Display(Name = "Son Kullanma Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? SonKullanmaTarihi { get; set; }

        [Display(Name = "Minimum Stok Uyarısı")]
        [Range(0, int.MaxValue, ErrorMessage = "Minimum stok miktarı 0'dan küçük olamaz")]
        public int MinimumStokMiktari { get; set; } = 10;

        [Display(Name = "Raf Konumu")]
        public string? RafKonumu { get; set; }
    }
} 