using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class BranchService : BaseService, IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public IQueryable<BranchViewModel> GetAll() =>
            _branchRepository.Select().ProjectTo<BranchViewModel>(MapperConfig);
        
        public BranchEditModel GetForEdit(int? id)
        {
            var race = id != null ? _branchRepository.Get(id.Value) : new Branch();
            return Mapper.Map<BranchEditModel>(race);
        }

        public void Delete(int id)
        {
            _branchRepository.Delete(id);
        }

        public void Save(BranchEditModel model)
        {
            var branch = new Branch
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            _branchRepository.InsertOrUpdate(branch);
        }
    }
}
