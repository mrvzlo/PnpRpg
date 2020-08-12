using Pnprpg.DomainService.Entities;

namespace Pnprpg.DomainService.IRepositories
{
    public interface IWeaponBonusRepository : IBaseRepository<WeaponBonus>
    {
        void ClearWeaponBonuses(int weaponId);
    }
}
