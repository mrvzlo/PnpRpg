using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class TraitEffectDescModel
    {
        public string Description { get; set; }
        public int Value { get; set; }
        public int TargetId { get; set; }
        public EffectTarget TargetType { get; set; }
        public int TraitId { get; set; }
        public EffectType Type { get; set; }

        public TraitModel Trait { get; set; }
        public SkillViewModel Skill { get; set; }

        public void Revert() => Value = -Value;

        public override string ToString()
        {
            var valueStr = Value.ToString();
            if (Value > 0 && Type == EffectType.Positive)
                valueStr = "+" + valueStr;

            return ToString(valueStr);
        }

        public string ToString(string valueStr)
        {
            return Value == 0 ? Description : string.Format(Description, valueStr);
        }
    }
}
