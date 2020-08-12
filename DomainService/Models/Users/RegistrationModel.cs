using System.ComponentModel.DataAnnotations;

namespace Pnprpg.DomainService.Models.Users
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