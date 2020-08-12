using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class MagicSchoolGroupsRepository : BaseRepository<MagicSchoolGroup>, IMagicSchoolGroupsRepository
    {
        public MagicSchoolGroupsRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
