using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class MagicService : BaseService, IMagicService
    {
        private readonly IMagicSchoolRepository _magicSchoolRepository;
        private readonly ISpellRepository _spellRepository;

        public MagicService(IMapper mapper, IMagicSchoolRepository magicSchoolRepository, ISpellRepository spellRepository) : base(mapper)
        {
            _magicSchoolRepository = magicSchoolRepository;
            _spellRepository = spellRepository;
        }

        public IQueryable<MagicSchoolModel> GetAllSchools()
        {
            return _magicSchoolRepository.Select().ProjectTo<MagicSchoolModel>(MapperConfig);
        }

        public SpellViewModel GetRandomSpell()
        {
            var spell = _spellRepository.GetRandom();
            return Mapper.Map<SpellViewModel>(spell);
        }

        public IQueryable<SpellViewModel> GetAll(int? filter = null)
        {
            var query = _spellRepository.Select().ProjectTo<SpellViewModel>(MapperConfig);
            return filter is null ? query : query.Where(x => x.MagicSchoolId == filter);
        }

        public SpellEditModel GetForEdit(int? id)
        {
            if (id == null)
                return new SpellEditModel();
            var spell = _spellRepository.Get(id.Value);
            return spell != null ? Mapper.Map<SpellEditModel>(spell) : new SpellEditModel();
        }

        public void Save(SpellEditModel model)
        {
            var perk = new Spell
            {
                Id = model.Id,
                MagicSchoolId = model.MagicSchoolId,
                Level = model.Level,
                Cost = model.Cost,
                Damage = model.Damage,
                Effect = model.Effect,
                Name = model.Name
            };

            model.Id = _spellRepository.InsertOrUpdate(perk);
        }

        public void Delete(int id)
        {
            _spellRepository.Delete(id);
        }
    }
}
