using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Entities
{
    public class AppUser : BaseEntity
    {
        public UserRole Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}