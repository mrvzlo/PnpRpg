using System.Collections.Generic;
using Pnprpg.DomainService.Entities;

namespace Pnprpg.DomainService.Models
{
    public class RaceViewModel : AssignableWithEffects, IBaseViewModel
    {
        public string Description { get; set; }
        public virtual ICollection<BonusViewModel> Bonuses { get; set; }
    }
}