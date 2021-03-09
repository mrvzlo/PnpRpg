using System.Linq;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface ICreatureService : IEditService<CreatureEditModel>
    {
        int Save(CreatureEditModel model);
        IQueryable<CreatureViewModel> GetAll(MajorType major, int? filter = null);
    }
}
