using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface ICreatureService : IViewService<CreatureViewModel>, IEditService<CreatureEditModel>
    {
        int Save(CreatureEditModel model);
    }
}
