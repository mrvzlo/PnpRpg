using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class UserEditModel
    {
        public int Id { get; set; }
        public UserRole Role { get; set; }
        public string Username { get; set; }
    }
}