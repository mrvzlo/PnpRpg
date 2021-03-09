using System;
using System.Collections.Generic;
using System.Linq;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class HeroModel
    {
        public int Level { get; set; }
        public MajorType Major { get; set; }
        public string Name { get; set; }
        public string Player { get; set; }
        public HeroAbilityGroup Abilities { get; set; }
        public HeroSkillGroup Skills { get; set; }
        public TraitGroup Traits { get; set; }
        public RaceViewModel Race { get; set; }
        public BranchGroup Branches { get; set; }
        public int GoodKarma { get; set; }
        public int BadKarma { get; set; }
        public int Charisma { get; set; }
        public HeroGenStage MaxStage { get; set; }

        public HeroModel() { }

        public HeroModel(MajorType major)
        {
            Name = "";
            Level = 1;
            Major = major;
            Charisma = 10;
            Abilities = new HeroAbilityGroup();
            Skills = new HeroSkillGroup(this);
            Traits = new TraitGroup();
            Branches = new BranchGroup();
        }

        public int BaseArmor() => (GetAbilityLevel(AbilityType.Endurance) + 5) / 10;
        public int BaseDmg() => (GetAbilityLevel(AbilityType.Strength) + 5) / 10;
        public int MaxHp() => GetAbilityLevel(AbilityType.Endurance) + Level / 2 + 3;
        public int MaxMp() => Math.Max(GetAbilityLevel(AbilityType.Intelligence) + Level - 4, 0);
        public int MaxCarry() => GetAbilityLevel(AbilityType.Strength) * GetAbilityLevel(AbilityType.Strength) / 10;
        public int MaxAp() => GetAbilityLevel(AbilityType.Endurance) / 2 + Level * 2;
        public int Perception() => Math.Max(GetAbilityLevel(AbilityType.Intelligence) + Level - 5, 0);

        private int GetAbilityLevel(AbilityType id) => Abilities.Get((int)id).Level;

        public bool ApplyEffectList(List<TraitEffectDescModel> list, bool manual) => list.All(x => ApplyEffect(x, manual));

        public bool ApplyModifiers(List<AbilityModifier> list)
        {
            var grouped = list.GroupBy(x => x.Ability.Type).Select(x => (x.Key, x.Sum(mod => mod.Modifier)));
            var updates = grouped.Select(x => Abilities.Update(x.Key, x.Item2, false)).ToList();
            return updates.All(success => success);
        }

        public void SetStatus(HeroGenStage stage)
        {
            if (stage > MaxStage)
                MaxStage = stage;
        }

        private bool ApplyEffect(TraitEffectDescModel traitEffect, bool manual)
        {
            switch (traitEffect.TargetType)
            {
                case EffectTarget.Ability:
                    return Abilities.Update(traitEffect.TargetId, traitEffect.Value, manual);
                case EffectTarget.Skill:
                    return Skills.Update(traitEffect.Skill, traitEffect.Value, manual);
                default:
                    return true;
            }
        }
    }
}