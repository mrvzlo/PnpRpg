using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class RaceRepository : BaseRepository<Race>, IRaceRepository
    {
        public RaceRepository(AppDbContext dbContext) : base(dbContext) { }

        public override IQueryable<Race> Select() => base.Select().OrderBy(x => x.Name);
    }
}
