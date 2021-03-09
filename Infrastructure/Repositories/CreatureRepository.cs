using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class CreatureRepository : BaseSettingPartRepository<Creature>, ICreatureRepository
    {
        public CreatureRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
