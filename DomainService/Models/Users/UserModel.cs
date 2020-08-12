using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models.Users
{
    public class UserModel
    {
        public int Id;
        public string Username;
        public string Password;
        public string HeroCode;
        public int? Room;
        public HeroModel Hero;
        public UserRole Role;
    }
}