using System.Linq;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IWeaponService
    {
        IQueryable<WeaponViewModel> GetAll();
        WeaponEditModel GetForEdit(int? id);
        void SaveWeapon(WeaponEditModel model);
        void DeleteWeapon(int id);
        IQueryable<BonusModel> GetAllBonuses();
    }
}
