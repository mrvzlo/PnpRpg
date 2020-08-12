using System;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models.Magic;

namespace Pnprpg.Domain.Services
{
    public class MagicService : BaseService, IMagicService
    {
        private readonly IMagicSchoolGroupsRepository _magicSchoolGroupsRepository;
        private readonly ISpellRepository _spellRepository;

        public MagicService(IMagicSchoolGroupsRepository magicSchoolGroupsRepository, ISpellRepository spellRepository)
        {
            _magicSchoolGroupsRepository = magicSchoolGroupsRepository;
            _spellRepository = spellRepository;
        }

        public IQueryable<MagicSchoolGroupModel> GetAllGroups()
        {
            return _magicSchoolGroupsRepository.Select().ProjectTo<MagicSchoolGroupModel>(MapperConfig);
        }

        public SpellModel GetRandomSpell()
        {
            var spell = _spellRepository.GetRandom();
            return Mapper.Map<SpellModel>(spell);
        }
    }
}
