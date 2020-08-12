using Pnprpg.DomainService.Entities;

namespace Pnprpg.DomainService.IRepositories
{
    public interface IUserRepository : IBaseRepository<AppUser>
    {
        AppUser GetUserByName(string name);
    }
}
