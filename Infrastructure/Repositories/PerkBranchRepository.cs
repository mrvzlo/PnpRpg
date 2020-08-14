using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class PerkBranchRepository : BaseRepository<PerkBranch>, IPerkBranchRepository
    {
        public PerkBranchRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
