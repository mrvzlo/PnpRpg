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
    public class CreatureService : BaseService, ICreatureService
    {
        private readonly ICreatureRepository _creatureRepository;

        public CreatureService(IMapper mapper, ICreatureRepository creatureRepository) : base(mapper)
        {
            _creatureRepository = creatureRepository;
        }

        public IQueryable<CreatureViewModel> GetAll(MajorType major, int? filter = null)
        {
            return _creatureRepository.Select(major).ProjectTo<CreatureViewModel>(MapperConfig);
        }
        
        public CreatureEditModel GetForEdit(int? id)
        {
            if (id == null)
                return new CreatureEditModel();
            var model = _creatureRepository.Get(id.Value).ProjectTo<CreatureEditModel>(MapperConfig).FirstOrDefault();
            return model ?? new CreatureEditModel();
        }

        public int Save(CreatureEditModel model) => MappingSave(_creatureRepository, model);

        public void Delete(int id) => _creatureRepository.Delete(id);
    }
}
