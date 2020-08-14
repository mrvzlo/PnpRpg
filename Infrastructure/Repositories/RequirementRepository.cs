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
            BatchDelete(DbContext.RequirementsForPerks.Where(x => x.PerkId == perkId));
        }
    }
}
