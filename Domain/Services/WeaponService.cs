using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class WeaponService : BaseService, IWeaponService
    {
        private readonly IWeaponRepository _weaponRepository;
        private readonly IBonusRepository _bonusRepository;

        public WeaponService(IWeaponRepository weaponRepository, IBonusRepository bonusRepository)
        {
            _weaponRepository = weaponRepository;
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

        public void Save(WeaponEditModel model)
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

        public void Delete(int id)
        {
            _bonusRepository.ClearBonuses(id, BonusType.Weapon);
            _weaponRepository.Delete(id);
        }
        
        private void SaveBonuses(List<BonusViewModel> list, int weaponId)
        {
            _bonusRepository.ClearBonuses(weaponId, BonusType.Weapon);
            if (list == null)
                return;

            var bonuses = list.Select(x => new WeaponBonus
            {
                WeaponId = weaponId,
                BonusId = x.Id
            }).AsQueryable();

            _bonusRepository.BatchInsertBonuses(bonuses);
        }
    }
}
