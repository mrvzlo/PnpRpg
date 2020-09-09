using System.Collections.Generic;

namespace Pnprpg.DomainService.Models
{
    public class RaceViewModel : Assignable, IBaseViewModel
    {
        public string Description { get; set; }
        public List<BonusViewModel> Bonuses { get; set; }
        public List<AbilityModifier> Modifiers { get; set; }

        public void Trim()
        {
            Description = null;
            Bonuses = null;
            Modifiers = null;
        }
    }
}