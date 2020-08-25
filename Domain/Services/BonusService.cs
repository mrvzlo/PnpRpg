using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class BonusService : BaseService, IBonusService
    {
        private readonly IBonusRepository _bonusRepository;

        public BonusService(IBonusRepository bonusRepository)
        {
            _bonusRepository = bonusRepository;
        }

        public BonusEditModel GetForEdit(int? id)
        {
            var bonus = id == null ? new Bonus() : _bonusRepository.Get(id.Value);
            return Mapper.Map<BonusEditModel>(bonus);
        }

        public void Delete(int id) => _bonusRepository.Delete(id);

        public IQueryable<BonusViewModel> GetAll()
        {
            return _bonusRepository.Select().ProjectTo<BonusViewModel>(MapperConfig);
        }

        public IQueryable<BonusViewModel> Select(BonusType type)
        {
            return GetAll().Where(x => x.Type == type);
        }

        public void Save(BonusEditModel model)
        {
            var bonus = new Bonus
            {
                Id = model.Id,
                Description = model.Description,
                Type = model.Type,
                Name = model.Name,
                Icon = model.Icon
            };

            _bonusRepository.InsertOrUpdate(bonus);
        }
    }
}
