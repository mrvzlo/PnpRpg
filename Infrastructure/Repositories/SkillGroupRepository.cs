using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class SkillGroupRepository : BaseRepository<SkillGroup>, ISkillGroupRepository
    {
        public SkillGroupRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
