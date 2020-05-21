using Boot.Enums;
using System.Collections.Generic;

namespace Boot.Models.JsonModels
{
    public class Weapon
    {
        public int Level, SkillId, Weight;
        public List<EffectType> Effects;
        public string Name;
        public SkillInfo Skill;
    }
}