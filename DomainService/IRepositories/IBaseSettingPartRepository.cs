using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.IRepositories
{
    public interface IBaseSettingPartRepository<T> : IBaseRepository<T> where T : BaseSettingPart
    {
        IQueryable<T> Select(MajorType major);
    }
}
