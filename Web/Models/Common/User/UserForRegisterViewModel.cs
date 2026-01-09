using System.ComponentModel.DataAnnotations;

namespace Web.Models.Common.User
{
    public class UserForRegisterViewModel
    {
        [Required(ErrorMessage = "Ad Soyad zorunludur")]
        [MinLength(3, ErrorMessage = "Ad Soyad en az 3 karakter olmalıdır")]
        [MaxLength(100, ErrorMessage = "Ad Soyad en fazla 100 karakter olabilir")]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [MaxLength(100, ErrorMessage = "E-posta en fazla 100 karakter olabilir")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [RegularExpression(@"^(\+90|0)?5\d{9}$", ErrorMessage = "Geçerli bir Türkiye telefon numarası giriniz")]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır")]
        [MaxLength(100, ErrorMessage = "Şifre en fazla 100 karakter olabilir")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı zorunludur")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Kullanım şartlarını kabul etmelisiniz")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Kullanım şartlarını kabul etmelisiniz")]
        [Display(Name = "Kullanım Şartlarını Kabul Ediyorum")]
        public bool AcceptTerms { get; set; }
    }
}