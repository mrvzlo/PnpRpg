using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class PerkService : BaseService, IPerkService
    {
        private readonly IPerkRepository _perkRepository;

        public PerkService(IPerkRepository perkRepository)
        {
            _perkRepository = perkRepository;
        }

        public IQueryable<PerkViewModel> GetAll()
        {
            return _perkRepository.Select().ProjectTo<PerkViewModel>(MapperConfig);
        }
        public IQueryable<PerkViewModel> GetAllSimplified()
        {
            return _perkRepository.Select().ProjectTo<PerkViewModel>(MapperConfig).AsEnumerable().SelectMany(GetPerkRanks).AsQueryable();
        }

        public PerkEditModel GetForEdit(int? id)
        {
            if (id == null)
                return new PerkEditModel();
            var perk = _perkRepository.Get(id.Value);
            return perk != null ? Mapper.Map<PerkEditModel>(perk) : new PerkEditModel();
        }

        public void Save(PerkEditModel model)
        {
            var perk = new Perk
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name,
                BranchId = model.BranchId,
                Level = model.Level,
                Max = model.Max
            };

            model.Id = _perkRepository.InsertOrUpdate(perk);
        }

        public void Delete(int id)
        {
            _perkRepository.Delete(id);
        }

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
