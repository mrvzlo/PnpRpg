using System.Linq;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IBonusService : IEditService<BonusEditModel>, IViewService<BonusViewModel>
    {
        void Save(BonusEditModel model);
        IQueryable<BonusViewModel> Select(BonusType type);
    }
}
