using System.Data.Entity;
using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class SkillRepository : BaseRepository<SkillInfo>, ISkillRepository
    {
        public SkillRepository(AppDbContext dbContext) : base(dbContext) { }

        public override IQueryable<SkillInfo> Select() =>
            base.Select().Include(x => x.Branch);

        public override SkillInfo Get(int id) =>
            Select().FirstOrDefault(x => x.Id == id);
    }
}
