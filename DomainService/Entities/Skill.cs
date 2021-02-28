using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Entities
{
    public class Skill : BaseSettingPart
    {
        public int Difficulty { get; set; }
        public int AbilityId { get; set; }
        public int BranchId { get; set; }
        public SkillType Type { get; set; }
        public string Name { get; set; }

        public virtual Ability Ability { get; set; }
        public virtual Branch Branch { get; set; }
    }
}