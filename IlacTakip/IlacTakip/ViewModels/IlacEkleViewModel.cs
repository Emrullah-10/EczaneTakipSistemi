using System.ComponentModel.DataAnnotations;

namespace IlacTakip.ViewModels
{
    public class IlacEkleViewModel
    {
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
        [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı 0 veya pozitif olmalıdır")]
        public int StokMiktari { get; set; } = 0;
        
        [Display(Name = "Barkod Numarası")]
        public string? BarkodNumarasi { get; set; }
        
        [Display(Name = "Son Kullanma Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? SonKullanmaTarihi { get; set; }
    }
} 