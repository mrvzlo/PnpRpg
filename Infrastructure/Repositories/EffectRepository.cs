using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class EffectRepository : BaseRepository<TraitEffect>, IEffectRepository
    {
        public EffectRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
