using System;
using System.Collections.Generic;
using System.Linq;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;

namespace Pnprpg.DomainService.Models
{
    public class HeroModel
    {
        public int Level { get; set; }
        public ChaosLevel Chaos { get; set; }
        public string Name { get; set; }
        public string Player { get; set; }
        public HeroAbilityGroup Abilities { get; set; }
        public HeroSkillGroup Skills { get; set; }
        public TraitGroup Traits { get; set; }
        public RaceModel Race { get; set; }

        public HeroModel(){}

        public HeroModel(ChaosLevel chaos)
        {
            Name = "";
            Level = 1;
            Chaos = chaos;
            Abilities = new HeroAbilityGroup();
            Skills = new HeroSkillGroup(this);
            Traits = new TraitGroup();
        }

        public int FreeSkillPoints() =>
            Constants.BaseSkillPoints + Constants.SkillPointsPerLvl * Level - Skills.TotalSpentPoints();

        public int FreeAbilityPoints() =>
            Constants.BaseHeroAbilityLevelSum - Abilities.TotalSpentPoints();

        public int BaseArmor() => (GetAbilityLevel(AbilityKey.E) + 5) / 10;
        public int BaseDmg() => (GetAbilityLevel(AbilityKey.S) + 5) / 10;
        public int MaxHp() => GetAbilityLevel(AbilityKey.E) + Level * 2 - 2;
        public int MaxEp() => Math.Max(GetAbilityLevel(AbilityKey.I) + Level - 4, 0);
        public int MaxCarry() => GetAbilityLevel(AbilityKey.S) * GetAbilityLevel(AbilityKey.E) / 10;

        private int GetAbilityLevel(AbilityKey id) => Abilities.Get((int) id).Level;

        public bool ApplyEffectList(List<EffectDescModel> list) => list.All(ApplyEffect);

        private bool ApplyEffect(EffectDescModel effect)
        {
            switch (effect.TargetType)
            {
                case EffectTarget.Ability:
                    return Abilities.Update(effect.TargetId, effect.Value, false);
                case EffectTarget.Skill:
                    return Skills.Update(effect.TargetId, effect.Value);
                default: 
                    return true;
            }
        }
    }
}