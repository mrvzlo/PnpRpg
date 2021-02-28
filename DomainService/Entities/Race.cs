using System.Collections.Generic;

namespace Pnprpg.DomainService.Entities
{
    public class Race : BaseSettingPart
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RaceBonus> Bonuses { get; set; }
        public virtual ICollection<RaceAbility> Abilities { get; set; }
    }
}