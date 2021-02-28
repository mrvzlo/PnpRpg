using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
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

        public IQueryable<CreatureViewModel> GetAll(int? filter = null)
        {
            var query = _creatureRepository.Select().ProjectTo<CreatureViewModel>(MapperConfig);
            return query;
        }
        
        public CreatureEditModel GetForEdit(int? id)
        {
            if (id == null)
                return new CreatureEditModel();
            var model = _creatureRepository.Get(id.Value).ProjectTo<CreatureEditModel>(MapperConfig).FirstOrDefault();
            return model ?? new CreatureEditModel();
        }

        public int Save(CreatureEditModel model)
        {
            var entity = new Creature
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name,
                Group = model.Group,
                Level = model.Level
            };

            return _creatureRepository.InsertOrUpdate(entity);
        }

        public void Delete(int id)
        {
            _creatureRepository.Delete(id);
        }
    }
}
