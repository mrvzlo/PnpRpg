using System.ComponentModel.DataAnnotations;

namespace Boot.Models
{
    public class RegistrationModel : LoginModel
    {
        [Required]
        [Display(Name = "Подтвердить")]
        [StringLength(128)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}