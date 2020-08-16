using System.Collections.Generic;

namespace Pnprpg.DomainService.Models
{
    public class WeaponViewModel
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; }
        public SkillViewModel Skill { get; set; }
        public List<BonusModel> Bonuses;
    }
}