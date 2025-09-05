using System.ComponentModel.DataAnnotations;

namespace IlacTakip.Models
{
    public class Ilac
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
        public decimal Fiyat { get; set; }
        
        [Display(Name = "Stok Miktarı")]
        public int StokMiktari { get; set; } = 0;
        
        [Display(Name = "Barkod Numarası")]
        public string? BarkodNumarasi { get; set; }
        
        [Display(Name = "Son Kullanma Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? SonKullanmaTarihi { get; set; }
        
        [Display(Name = "Oluşturma Tarihi")]
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
    }
} 