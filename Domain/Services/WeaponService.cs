using System.Linq;
using AutoMapper;
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

        public WeaponService(IMapper mapper, IWeaponRepository weaponRepository, IBonusService bonusService) : base(mapper)
        {
            _weaponRepository = weaponRepository;
            _bonusService = bonusService;
        }

        public IQueryable<WeaponViewModel> GetAll(int? filter = null)
        {
            var query = _weaponRepository.Select().ProjectTo<WeaponViewModel>(MapperConfig);
            return filter is null ? query : query.Where(x => x.Skill.Id == filter);
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
