using System.Linq;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IPerkService: IEditService<PerkEditModel>, IViewService<PerkViewModel>
    {
        void Save(PerkEditModel model);
    }
}
