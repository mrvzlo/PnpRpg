using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Entities
{
    public class Effect : BaseEntity<int>
    {
        public int Value { get; set; }
        public EffectTarget TargetType { get; set; }
        public int TargetId { get; set; }
        public AssignableType ParentType { get; set; }
        public int ParentId { get; set; }
        public string Description { get; set; }
    }
}