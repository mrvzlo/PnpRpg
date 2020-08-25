using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class PerkRepository : BaseRepository<Perk>, IPerkRepository
    {
        public PerkRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
