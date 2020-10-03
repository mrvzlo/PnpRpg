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
        public string Name { get; set; }
        public string Player { get; set; }
        public HeroAbilityGroup Abilities { get; set; }
        public HeroSkillGroup Skills { get; set; }
        public TraitGroup Traits { get; set; }
        public RaceViewModel Race { get; set; }
        public BranchGroup Branches { get; set; }
        public int GoodKarma { get; set; }
        public int BadKarma { get; set; }
        public HeroGenStatus MaxStatus { get; set; }

        public HeroModel(){}

        public HeroModel(Company chaos)
        {
            Name = "";
            Level = 1;
            Abilities = new HeroAbilityGroup();
            Skills = new HeroSkillGroup(this);
            Traits = new TraitGroup();
            Branches = new BranchGroup();
        }

        public int BaseArmor() => (GetAbilityLevel(AbilityKey.E) + 5) / 10;
        public int BaseDmg() => (GetAbilityLevel(AbilityKey.S) + 5) / 10;
        public int MaxHp() => GetAbilityLevel(AbilityKey.E) + Level / 2 + 3;
        public int MaxMp() => Math.Max(GetAbilityLevel(AbilityKey.I) + Level - 4, 0);
        public int MaxCarry() => GetAbilityLevel(AbilityKey.S) * GetAbilityLevel(AbilityKey.E) / 10;
        public int MaxAp() => GetAbilityLevel(AbilityKey.A) / 2 + Level;
        public int Perception() => Math.Max(GetAbilityLevel(AbilityKey.I) + Level - 5, 0);

        private int GetAbilityLevel(AbilityKey id) => Abilities.Get((int) id).Level;

        public bool ApplyEffectList(List<TraitEffectDescModel> list, bool manual) => list.All(x => ApplyEffect(x, manual));

        public bool ApplyModifiers(List<AbilityModifier> list) => 
            list.All(x => Abilities.Update(x.Ability.Id, x.Modifier, false));

        public void SetStatus(HeroGenStatus status)
        {
            if (status > MaxStatus)
                MaxStatus = status;
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