using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class SkillEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public int AbilityId { get; set; }
        public int BranchId { get; set; }
        public SkillType Type { get; set; }
    }
}
