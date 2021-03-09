using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class PerkRepository : BaseSettingPartRepository<Perk>, IPerkRepository
    {
        public PerkRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
