using System.Collections.Generic;
using System.Linq;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IPerkService: IEditService<PerkEditModel>
    {
        int Save(PerkEditModel model);
        IQueryable<PerkViewModel> GetAllSimplified(MajorType major);
        List<PerkViewModel> GetPerkRanks(PerkViewModel perk);
        IQueryable<PerkViewModel> GetAll(MajorType major, int? filter = null);
    }
}
