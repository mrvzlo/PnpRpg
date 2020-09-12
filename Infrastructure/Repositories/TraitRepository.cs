using System.Data.Entity;
using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class TraitRepository : BaseRepository<Trait>, ITraitRepository
    {
        public TraitRepository(AppDbContext dbContext) : base(dbContext) { }
        public override IQueryable<Trait> Select() => base.Select().Include(x => x.Effects);
    }
}
