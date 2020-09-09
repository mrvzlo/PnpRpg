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
            //return _perkRepository.Select().ProjectTo<PerkViewModel>(MapperConfig).AsEnumerable().SelectMany(GetPerkRanks).AsQueryable();
            return _perkRepository.Select().ProjectTo<PerkViewModel>(MapperConfig);
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

            var splitted = perk.Description.Split('[', ']');
            var description = "";
            var baseValues = new List<int>();
            for (var i = 0; i < splitted.Length; i++)
            {
                if (i % 2 == 0)
                {
                    description += splitted[i];
                }
                else
                {
                    description += $"{{{i / 2}}}";
                    baseValues.Add(Convert.ToInt32(splitted[i]));
                }
            }

            for (var i = 0; i < perk.Max; i++)
            {
                var values = baseValues.Select(x => (x + i * x).ToString()).ToArray();
                var child = new PerkViewModel
                {
                    Branch = perk.Branch,
                    BranchId = perk.BranchId, 
                    Id = perk.Id, 
                    Name = i == 0 ? perk.Name : $"{perk.Name} {i+1}", 
                    Level = perk.Level + i * 2,
                    Description = string.Format(description, values)
                };
                list.Add(child);
            }

             return list;
        }
    }
}
