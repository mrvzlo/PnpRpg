using System.Collections.Generic;
using Boot.Enums;

namespace Boot.Models.JsonModels
{
    public class Effect
    {
        public EffectType type;
        public string desc;
        public int value;
        public StatType? stat;
    }
}