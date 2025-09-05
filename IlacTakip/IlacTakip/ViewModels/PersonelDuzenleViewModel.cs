using System.ComponentModel.DataAnnotations;

namespace IlacTakip.ViewModels
{
    public class PersonelDuzenleViewModel
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

        [Display(Name = "E-posta")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        public string? Email { get; set; }

        [Display(Name = "Pozisyon")]
        public string? Pozisyon { get; set; }

        [Required(ErrorMessage = "Maaş zorunludur")]
        [Display(Name = "Maaş")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Maaş 0'dan büyük olmalıdır")]
        public decimal Maas { get; set; }

        [Display(Name = "İşe Başlama Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? IseBaslamaTarihi { get; set; }

        [Display(Name = "İş Sona Erme Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? IsSonaErmeTarihi { get; set; }

        [Display(Name = "Çalışma Durumu")]
        public bool AktifMi { get; set; } = true;

        [Display(Name = "TC Kimlik No")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC Kimlik No 11 haneli olmalıdır")]
        public string? TcKimlikNo { get; set; }

        [Display(Name = "Adres")]
        public string? Adres { get; set; }
    }
} 