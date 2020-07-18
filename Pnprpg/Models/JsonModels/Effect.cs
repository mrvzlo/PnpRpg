using Boot.Enums;

namespace Boot.Models.JsonModels
{
    public class Effect
    {
        public EffectType Type;
        public string Desc, StatId;
        public int Value;
        public Stat Stat;
    }
}