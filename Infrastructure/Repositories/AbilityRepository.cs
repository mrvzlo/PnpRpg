using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class AbilityRepository : BaseSettingPartRepository<Ability>, IAbilityRepository
    {
        public AbilityRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
