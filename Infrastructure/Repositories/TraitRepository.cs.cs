using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class TraitRepository : BaseRepository<Trait>, ITraitRepository
    {
        public TraitRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
