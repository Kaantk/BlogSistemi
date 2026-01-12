using System.ComponentModel.DataAnnotations;

namespace Web.Models.Home
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Ad Soyad zorunludur")]
        [MinLength(3, ErrorMessage = "Ad Soyad en az 3 karakter olmalıdır")]
        [MaxLength(100, ErrorMessage = "Ad Soyad en fazla 100 karakter olabilir")]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Konu zorunludur")]
        [MinLength(5, ErrorMessage = "Konu en az 5 karakter olmalıdır")]
        [MaxLength(200, ErrorMessage = "Konu en fazla 200 karakter olabilir")]
        [Display(Name = "Konu")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj zorunludur")]
        [MinLength(10, ErrorMessage = "Mesaj en az 10 karakter olmalıdır")]
        [MaxLength(1000, ErrorMessage = "Mesaj en fazla 1000 karakter olabilir")]
        [Display(Name = "Mesaj")]
        public string Message { get; set; }
    }
}
