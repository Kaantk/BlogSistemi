using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Web.Models.Common.User
{
    public class UserSettingsViewModel
    {
        // Profil Bilgileri
        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [Display(Name = "E-posta Adresi")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Profil Fotoğrafı")]
        public IFormFile ProfileImage { get; set; }

        // Mevcut profil fotoğrafı URL'i (gösterim için)
        public string CurrentProfileImageUrl { get; set; }

        // Şifre Değiştirme
        [DataType(DataType.Password)]
        [Display(Name = "Mevcut Şifre")]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter olmalıdır")]
        [Display(Name = "Yeni Şifre")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor")]
        [Display(Name = "Yeni Şifre (Tekrar)")]
        public string ConfirmPassword { get; set; }

        // Bildirim Tercihleri
        [Display(Name = "E-posta Bildirimleri")]
        public bool EmailNotifications { get; set; }

        [Display(Name = "Haftalık Bülten")]
        public bool WeeklyNewsletter { get; set; }

        [Display(Name = "Yorum Bildirimleri")]
        public bool CommentNotifications { get; set; }

        // Kullanıcı ID (güncelleme işlemleri için)
        public int UserId { get; set; }

        // Rol bilgisi (görüntüleme için)
        public string UserRole { get; set; }
    }
}