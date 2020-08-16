using System.Linq;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IPerkService
    {
        IQueryable<PerkViewModel> GetAll();
        IQueryable<BranchModel> GetAllBranches();
        PerkEditModel GetForEdit(int? id);
        void SavePerk(PerkEditModel model);
        void DeletePerk(int id);
    }
}
