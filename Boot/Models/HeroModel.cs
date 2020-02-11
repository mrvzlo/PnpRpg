using System;
using System.Collections.Generic;
using System.Linq;
using Boot.Enums;
using Boot.Helpers;
using Boot.Models.JsonModels;

namespace Boot.Models
{
    public class HeroModel
    {
        public int[] Stats;
        public int[] Traits;
        public int MinAttr, Level, Race;
        public ChaosLevel Chaos;
        public Dictionary<int, int> Skills;
        public int UsedSkillPoints;

        public string RaceStr;

        public int FreeStatPoints() =>
            Chaos == ChaosLevel.Random ? 0 : Constants.MaxStatSum - Stats.Sum();
        public int FreeSkillPoints() =>
            Constants.BaseSkillPoints + Constants.SkillPointsPerLvl * Level - UsedSkillPoints;
        public int MaxHp() => Stats[(int)StatType.S] + Level * 2 - 2;
        public int MaxEp() => Math.Max(Stats[(int)StatType.I] + Level - 4, 0);
        public int MaxCarry() => Stats[(int)StatType.S] * Stats[(int)StatType.S] / 10;

        #region SaveLoad

        public HeroModel(string data)
        {
            ResetSkills();
            ResetTraits();
            if (string.IsNullOrEmpty(data)) return;
            var count = EnumExtensions.GetEnumCount(typeof(StatType));
            var list = data.Split(StringHelper.Separator).Select(int.Parse).ToList();
            Stats = new int[count];
            var x = 0;
            for (var i = 0; i < Stats.Length; i++)
                Stats[i] = list[x++];
            MinAttr = list[x++];
            Level = list[x++];
            Race = list[x++];
            Chaos = (ChaosLevel)list[x++];
            var skillsCount = list[x++];
            for (var i = 0; i < skillsCount; i++)
                Skills.Add(list[x++], list[x++]);
            for (var i = 0; i < Constants.TraitCount; i++)
                Traits[i] = list[x++];
        }

        public override string ToString()
        {
            var list = Stats.Select(x => x.ToString()).ToList();
            list.AddRange(new[] { MinAttr, Level, Race, (int)Chaos }.Select(x => x.ToString()));
            list.Add(Skills.Count.ToString());
            if (Skills.Any())
            {
                var skillsInfo = Skills.Where(x => x.Value > 0)
                    .Select(x => $"{x.Key}{StringHelper.Separator}{x.Value}");
                list.AddRange(skillsInfo);
            }
            list.AddRange(Traits.Select(x => x.ToString()));
            return string.Join($"{StringHelper.Separator}", list);
        }

        public HeroModel(ChaosLevel chaos)
        {
            ResetSkills();
            ResetTraits();
            Level = 1;
            Chaos = chaos;
            var count = EnumExtensions.GetEnumCount(typeof(StatType));
            Stats = new int[count];
            var rand = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < Stats.Length; i++)
                Stats[i] = Constants.MinStat;
            MinAttr = Constants.MinStat;
            switch (chaos)
            {
                case ChaosLevel.Normal:
                    for (var i = 0; i < Stats.Length; i++)
                        Stats[i] = 8;
                    MinAttr = 8;
                    return;
                case ChaosLevel.High:
                    return;
                case ChaosLevel.Extreme:
                    for (var i = 0; i < Stats.Length; i++)
                        Stats[i] = Constants.MaxStat / 2;
                    for (var i = 0; i < Constants.MaxStat / 2; i++)
                    {
                        IncStat(rand.Next(count), -1);
                        IncStat(rand.Next(count), 1);
                    }
                    MinAttr = Constants.MaxStat;
                    return;
                case ChaosLevel.Random:
                    MinAttr = Constants.MaxStat;
                    for (var i = 0; i < Stats.Length; i++)
                        Stats[i] = rand.Next(Constants.MaxStat) + 1;
                    return;
            }
        }

        #endregion

        public bool ChangeRace(Race oldRace, Race newRace)
        {
            if (oldRace.id == newRace.id) 
                return false;
            Race = newRace.id;
            if (oldRace.effects != null)
                foreach (var eff in oldRace.effects)
                    ApplyStatEffect(eff, true);
            if (newRace.effects != null)
                foreach (var eff in newRace.effects)
                    ApplyStatEffect(eff);

            return !(Stats.Any(x => x < 1 || x > Constants.MaxStat));
        }

        public void ResetTraits()
        {
            Traits = new int[Constants.TraitCount];
            for (var i = 0; i < Constants.TraitCount; i++)
                Traits[i] = -1;
        }

        public bool AddTrait(int id)
        {
            for (var i = 0; i < Traits.Length; i++)
            {
                if (Traits[i] >= 0) continue;
                Traits[i] = id;
                return true;
            }

            return false;
        }

        public bool IncStat(int attr, int val)
        {
            if (Stats[attr] + val < MinAttr
                || Stats[attr] + val > Constants.MaxStat
                || Stats.Sum() + val > Constants.MaxStatSum)
                return false;
            Stats[attr] += val;
            return true;
        }

        #region Skills 

        public void ResetSkills()
        {
            UsedSkillPoints = 0;
            Skills = new Dictionary<int, int>();
        }

        public bool AddSkill(SkillInfo skillInfo)
        {
            if (!CanIncSkill(skillInfo)) return false;
            Skills[skillInfo.Id]++;
            UsedSkillPoints += skillInfo.Difficulty + 1;
            return true;
        }

        public bool CanIncSkill(SkillInfo skillInfo)
        {
            var skillPoints = GetOrCreateSkillPoints(skillInfo.Id);
            return skillInfo.Difficulty + 1 <= FreeSkillPoints() && Level > skillPoints;
        }

        private int GetOrCreateSkillPoints(int skillId)
        {
            if (Skills.ContainsKey(skillId))
                return Skills[skillId];
            Skills.Add(skillId, 0);
            return 0;
        }

        #endregion

        private void ApplyStatEffect(Effect effect, bool revert = false)
        {
            var stat = (int)effect.stat;
            var value = effect.value;
            if (revert)
                value *= -1;
            switch (effect.type)
            {
                case EffectType.Positive: Stats[stat] += value; return;
                case EffectType.Negative: Stats[stat] -= value; return;
            }
        }
    }
}