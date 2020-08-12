using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class SkillRepository : BaseRepository<SkillInfo>, ISkillRepository
    {
        public SkillRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
