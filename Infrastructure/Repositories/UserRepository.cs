using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<AppUser>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext) { }

        public AppUser GetUserByName(string name) => 
            DbContext.AppUsers.SingleOrDefault(x => x.Username == name);
    }
}
