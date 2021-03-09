using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class BaseSettingPartRepository<T> : BaseRepository<T>, IBaseSettingPartRepository<T> where T : BaseSettingPart
    {
        protected BaseSettingPartRepository(AppDbContext context) : base(context) { }

        public virtual IQueryable<T> Select(MajorType major)
        {
            var query = base.Select();
            if (major != MajorType.Common)
                query = query.Where(x => x.MajorId == (int)major);
            return query;
        }
    }
}
