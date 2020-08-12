using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class EffectRepository : BaseRepository<Effect>, IEffectRepository
    {
        public EffectRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
