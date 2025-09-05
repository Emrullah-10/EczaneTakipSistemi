using System.ComponentModel.DataAnnotations;

namespace IlacTakip.Models
{
    public class Admin
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Ad zorunludur")]
        [Display(Name = "Ad")]
        public string Ad { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Soyad zorunludur")]
        [Display(Name = "Soyad")]
        public string Soyad { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "E-posta zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [Display(Name = "E-posta")]
        public string Email { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Şifre zorunludur")]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; } = string.Empty;
        
        [Display(Name = "Oluşturma Tarihi")]
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
        
        [Display(Name = "Son Giriş Tarihi")]
        public DateTime? SonGirisTarihi { get; set; }
        
        [Display(Name = "Aktif Mi")]
        public bool AktifMi { get; set; } = true;
    }
} 