using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class WeaponService : BaseService, IWeaponService
    {
        private readonly IWeaponRepository _weaponRepository;
        private readonly IBonusRepository _bonusRepository;
        private readonly IWeaponBonusRepository _weaponBonusRepository;

        public WeaponService(IWeaponRepository weaponRepository, IWeaponBonusRepository weaponBonusRepository,
            IBonusRepository bonusRepository)
        {
            _weaponRepository = weaponRepository;
            _weaponBonusRepository = weaponBonusRepository;
            _bonusRepository = bonusRepository;
        }

        public IQueryable<WeaponViewModel> GetAll()
        {
            return _weaponRepository.Select().ProjectTo<WeaponViewModel>(MapperConfig);
        }

        public WeaponEditModel GetForEdit(int? id)
        {
            var weapon = id != null
                ? _weaponRepository.Get(id.Value)
                : new Weapon();

            return Mapper.Map<WeaponEditModel>(weapon);
        }

        public void SaveWeapon(WeaponEditModel model)
        {
            var weapon = new Weapon
            {
                Id = model.Id,
                Level = model.Level,
                Name = model.Name,
                SkillId = model.SkillId,
                Weight = model.Weight
            };

            weapon.Id = _weaponRepository.InsertOrUpdate(weapon);

            SaveBonuses(model.Bonuses, weapon.Id);
        }

        public void DeleteWeapon(int id)
        {
            _weaponBonusRepository.ClearWeaponBonuses(id);
            _weaponRepository.Delete(id);
        }

        public IQueryable<BonusModel> GetAllBonuses() =>
            _bonusRepository.Select().ProjectTo<BonusModel>(MapperConfig);

        private void SaveBonuses(List<BonusModel> list, int weaponId)
        {
            _weaponBonusRepository.ClearWeaponBonuses(weaponId);
            if (list == null)
                return;

            var bonuses = list.Select(x => new WeaponBonus
            {
                WeaponId = weaponId,
                BonusId = x.Id
            }).AsQueryable();

            _weaponBonusRepository.BatchInsert(bonuses);
        }
    }
}
