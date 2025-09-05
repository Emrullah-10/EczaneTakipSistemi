using System.ComponentModel.DataAnnotations;

namespace IlacTakip.Models
{
    public class Personel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Ad zorunludur")]
        [Display(Name = "Ad")]
        public string Ad { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Soyad zorunludur")]
        [Display(Name = "Soyad")]
        public string Soyad { get; set; } = string.Empty;
        
        [Display(Name = "Telefon")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        public string? Telefon { get; set; }
        
        [Display(Name = "Pozisyon")]
        public string? Pozisyon { get; set; }
        
        [Required(ErrorMessage = "Maaş zorunludur")]
        [Display(Name = "Maaş")]
        [DataType(DataType.Currency)]
        public decimal Maas { get; set; }
        
        [Display(Name = "İşe Başlama Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? IseBaslamaTarihi { get; set; }
        
        [Display(Name = "Aktif Mi")]
        public bool AktifMi { get; set; } = true;
        
        [Display(Name = "Oluşturma Tarihi")]
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
    }
} 