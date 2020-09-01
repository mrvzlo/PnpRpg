using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class EffectDescModel
    {
        public string Description { get; set; }
        public int Value { get; set; }
        public int TargetId { get; set; }
        public EffectTarget TargetType { get; set; }
        public int ParentId { get; set; }
        public AssignableType ParentType { get; set; }

        public Upgradeable Target { get; set; }

        public void Revert() => Value = -Value;

        public override string ToString()
        {
            var valueStr = Value.ToString();
            if (Value > 0)
                valueStr = "+" + valueStr;

            return ToString(valueStr);
        }

        public string ToString(string valueStr)
        {
            if (TargetType == EffectTarget.None)
                return Value == 0 ? Description : string.Format(Description, valueStr);

            if (string.IsNullOrEmpty(Description))
                return $"{valueStr} {Target.Name}";

            return string.Format(Description, valueStr, Target.Name);
        }
    }
}
