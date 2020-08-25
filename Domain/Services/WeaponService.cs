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
        private readonly IBonusService _bonusService;

        public WeaponService(IWeaponRepository weaponRepository, IBonusService bonusService)
        {
            _weaponRepository = weaponRepository;
            _bonusService = bonusService;
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

            var bonuses = model.Bonuses?.Select(x => new WeaponBonus
            {
                WeaponId = model.Id,
                BonusId = x
            }).AsQueryable();

            _bonusService.BatchSave(bonuses, weapon.Id, BonusType.Weapon);
        }

        public void Delete(int id)
        {
            _bonusService.BatchClear(id, BonusType.Weapon);
            _weaponRepository.Delete(id);
        }
    }
}
