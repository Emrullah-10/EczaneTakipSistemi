using System.ComponentModel.DataAnnotations;

namespace IlacTakip.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad zorunludur")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad zorunludur")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-posta zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [Display(Name = "E-posta")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre zorunludur")]
        [StringLength(100, ErrorMessage = "{0} en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Rol seçimi zorunludur")]
        [Display(Name = "Rol")]
        public string Role { get; set; } = string.Empty;

        // Eczane sahibi için ek alanlar
        [Display(Name = "Eczane Adı")]
        public string? EczaneAdi { get; set; }

        [Display(Name = "Adres")]
        public string? Adres { get; set; }

        [Display(Name = "Telefon")]
        public string? Telefon { get; set; }
    }
} 