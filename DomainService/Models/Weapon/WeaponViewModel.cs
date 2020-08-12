using System.Collections.Generic;
using Pnprpg.DomainService.Models.Skills;

namespace Pnprpg.DomainService.Models.Weapon
{
    public class WeaponViewModel
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; }
        public SkillModel Skill { get; set; }
        public List<BonusModel> Bonuses;
    }
}