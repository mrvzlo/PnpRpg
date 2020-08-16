using System;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class MagicService : BaseService, IMagicService
    {
        private readonly IMagicSchoolRepository _magicSchoolRepository;
        private readonly ISpellRepository _spellRepository;

        public MagicService(IMagicSchoolRepository magicSchoolRepository, ISpellRepository spellRepository)
        {
            _magicSchoolRepository = magicSchoolRepository;
            _spellRepository = spellRepository;
        }

        public IQueryable<MagicSchoolModel> GetAll()
        {
            return _magicSchoolRepository.Select().ProjectTo<MagicSchoolModel>(MapperConfig);
        }

        public SpellModel GetRandomSpell()
        {
            var spell = _spellRepository.GetRandom();
            return Mapper.Map<SpellModel>(spell);
        }
    }
}
