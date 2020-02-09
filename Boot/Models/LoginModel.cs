using System.ComponentModel.DataAnnotations;

namespace Boot.Models
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