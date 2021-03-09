using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class SkillRepository : BaseSettingPartRepository<Skill>, ISkillRepository
    {
        public SkillRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
