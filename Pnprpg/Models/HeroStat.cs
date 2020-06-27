using Boot.Helpers;

namespace Boot.Models
{
    public class HeroStat : Stat
    {
        public int Value, Min, Max;

        public HeroStat(Stat parent)
        {
            Id = parent.Id;
            Color = parent.Color;
            Name = parent.Name;
            Min = Constants.ManualMinStat;
            Max = Constants.ManualMaxStat;
        }

        public bool IsValid() => Value <= Max && Value >= Min;

        public void Set(ChaosLevel chaos)
        {
            if (chaos == ChaosLevel.Normal)
                Value = Min;
            else if (chaos == ChaosLevel.High)
                Value = Constants.MinStat;
        }

        public bool ManualBoost(int bonus)
        {
            Value += bonus;
            if (IsValid()) 
                return true;
            Value -= bonus;
            return false;
        }

        public void EffectBoost(int value, bool baseOnly)
        {
            Min += value;
            Max += value;
            if (!baseOnly)
                Value += value;
        }
    }
}