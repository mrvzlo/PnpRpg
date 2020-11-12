using System.Collections.Generic;
using System.Linq;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class BranchViewModel : IBaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public List<BonusViewModel> Bonuses { get; set; }
        public List<SkillViewModel> Skills { get; set; }
        public List<PerkViewModel> Perks { get; set; }

        public int SpellCount() => Skills.Count(x => x.Type == SkillType.Magic);

        public void Trim()
        {
            Description = null;
            Bonuses = null;
            Skills = null;
            Perks = null;
        }
    }
}