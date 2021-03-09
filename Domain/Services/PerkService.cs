using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class PerkService : BaseService, IPerkService
    {
        private readonly IPerkRepository _perkRepository;

        public PerkService(IMapper mapper, IPerkRepository perkRepository) : base(mapper)
        {
            _perkRepository = perkRepository;
        }

        public IQueryable<PerkViewModel> GetAll(MajorType major, int? filter = null)
        {
            var query = _perkRepository.Select(major).ProjectTo<PerkViewModel>(MapperConfig);
            return filter is null ? query : query.Where(x => x.BranchId == filter);
        }
        public IQueryable<PerkViewModel> GetAllSimplified(MajorType major)
        {
            return _perkRepository.Select(major).ProjectTo<PerkViewModel>(MapperConfig).AsEnumerable().SelectMany(GetPerkRanks).AsQueryable();
        }

        public PerkEditModel GetForEdit(int? id)
        {
            if (id == null)
                return new PerkEditModel();
            var model = _perkRepository.Get(id.Value).ProjectTo<PerkEditModel>(MapperConfig).FirstOrDefault();
            return model ?? new PerkEditModel();
        }

        public int Save(PerkEditModel model) => MappingSave(_perkRepository, model);

        public void Delete(int id) => _perkRepository.Delete(id);

        public List<PerkViewModel> GetPerkRanks(PerkViewModel perk)
        {
            var list = new List<PerkViewModel>();
            if (perk.Max == 1)
            {
                list.Add(perk);
                return list;
            }
            
            for (var i = 0; i < perk.Max; i++)
            {
                var child = new PerkViewModel
                {
                    Branch = perk.Branch,
                    BranchId = perk.BranchId, 
                    Id = perk.Id, 
                    Name = i == 0 ? perk.Name : $"{perk.Name} {i+1}", 
                    Level = perk.Level + i * 2,
                    Description = perk.Description
                };
                list.Add(child);
            }

            return list;
        }
    }
}
