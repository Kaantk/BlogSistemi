using System.ComponentModel.DataAnnotations;

namespace Web.Models.ViewModels.Auth
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "E-posta adresi zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [Display(Name = "E-posta Adresi")]
        public string Email { get; set; }
    }
}
