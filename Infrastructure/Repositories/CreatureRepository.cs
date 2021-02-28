using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class CreatureRepository : BaseRepository<Creature>, ICreatureRepository
    {
        public CreatureRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
