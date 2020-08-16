using System.ComponentModel.DataAnnotations;

namespace Pnprpg.DomainService.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Логин")]
        [StringLength(128)]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        [StringLength(128)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}