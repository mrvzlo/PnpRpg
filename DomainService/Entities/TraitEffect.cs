using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Entities
{
    public class TraitEffect : BaseSettingPart
    {
        public int Value { get; set; }
        public EffectTarget TargetType { get; set; }
        public int TargetId { get; set; }
        public int TraitId { get; set; }
        public string Description { get; set; }
        public EffectType Type { get; set; }

        public virtual Trait Trait { get; set; }
    }
}