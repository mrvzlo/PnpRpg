using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Entities
{
    public class TraitEffect : BaseEntity<int>
    {
        public int Value { get; set; }
        public EffectTarget TargetType { get; set; }
        public int TargetId { get; set; }
        public int TraitId { get; set; }
        public string Description { get; set; }
    }
}