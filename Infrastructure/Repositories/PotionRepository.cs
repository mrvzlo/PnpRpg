using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class PotionRepository : BaseRepository<Potion>, IPotionRepository
    {
        public PotionRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
