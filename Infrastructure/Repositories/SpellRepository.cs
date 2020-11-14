using System.Data.Entity;
using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class SpellRepository : BaseRepository<Spell>, ISpellRepository
    {
        public SpellRepository(AppDbContext dbContext) : base(dbContext) { }

        public override IQueryable<Spell> Select() => base.Select().Include(x => x.MagicSchool);
    }
}
