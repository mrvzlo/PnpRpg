using System.Linq;
using Pnprpg.DomainService.Models.Perks;

namespace Pnprpg.DomainService.IServices
{
    public interface IPerkService
    {
        IQueryable<PerkViewModel> GetAll();
        PerkEditModel GetForEdit(int? id);
        void SavePerk(PerkEditModel model);
        void DeletePerk(int id);
    }
}
