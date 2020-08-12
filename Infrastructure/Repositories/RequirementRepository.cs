using System.Data.Entity;
using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class RequirementRepository : BaseRepository<RequirementForPerk>, IRequirementRepository
    {
        public RequirementRepository(AppDbContext dbContext) : base(dbContext) { }

        public void ClearPerkRequirements(int perkId)
        {
            foreach (var requirement in DbContext.RequirementsForPerks
                .Where(x => x.PerkId == perkId))
                DbContext.Entry(requirement).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }
    }
}
