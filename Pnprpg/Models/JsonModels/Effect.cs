using Boot.Enums;

namespace Boot.Models.JsonModels
{
    public class Effect
    {
        public EffectType type;
        public string desc, statId;
        public int value;
        public Stat Stat;
    }
}