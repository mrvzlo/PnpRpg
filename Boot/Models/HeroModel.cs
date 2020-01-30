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
        public int MinAttr, Level;
        public Dictionary<int, int> Skills;
        public int UsedSkillPoints;
        public int FreeStatPoints;

        public int FreeSkillPoints =>
            Constants.BaseSkillPoints + Constants.SkillPointsPerLvl * Level - UsedSkillPoints;

        public int MaxHp() => Stats[(int)StatType.S] + Level * 2 - 2;
        public int MaxEp() => Math.Max(Stats[(int)StatType.I] + Level - 4, 0);
        public int MaxCarry() => Stats[(int)StatType.S] * Stats[(int)StatType.S] / 10;

        public HeroModel(string data)
        {
            ResetSkills();
            if (string.IsNullOrEmpty(data)) return;
            var count = EnumExtensions.GetEnumCount(typeof(StatType));
            var list = data.Split(StringHelper.Separator).Select(int.Parse).ToList();
            Stats = new int[count];
            var x = 0;
            for (var i = 0; i < Stats.Length; i++)
                Stats[i] = list[x++];
            MinAttr = list[x++];
            Level = list[x++];
            var skillsCount = list[x++];
            for (var i = 0; i < skillsCount; i++)
                Skills.Add(list[x++], list[x++]);
        }

        public override string ToString()
        {
            var list = Stats.Select(x => x.ToString()).ToList();
            list.AddRange(new[] { MinAttr, Level }.Select(x => x.ToString()));
            list.Add(Skills.Count.ToString());
            if (Skills.Any())
            {
                var skillsInfo = Skills.Where(x => x.Value > 0)
                    .Select(x => $"{x.Key}{StringHelper.Separator}{x.Value}");
                list.AddRange(skillsInfo);
            }
            return string.Join($"{StringHelper.Separator}", list);
        }

        public HeroModel(ChaosLevel chaos)
        {
            ResetSkills();
            Level = 1;
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
                    FreeStatPoints = Constants.MaxStatSum - Stats.Sum();
                    return;
                case ChaosLevel.High:
                    FreeStatPoints = Constants.MaxStatSum - Stats.Sum();
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
                    FreeStatPoints = Constants.MaxStatSum - Stats.Sum();
                    return;
                case ChaosLevel.Random:
                    MinAttr = Constants.MaxStat;
                    for (var i = 0; i < Stats.Length; i++)
                        Stats[i] = rand.Next(Constants.MaxStat) + 1;
                    FreeStatPoints = 0;
                    return;
            }
        }

        public void ResetSkills()
        {
            UsedSkillPoints = 0;
            Skills = new Dictionary<int, int>();
        }

        public bool IncStat(int attr, int val)
        {
            if (Stats[attr] + val < MinAttr
                || Stats[attr] + val > Constants.MaxStat
                || Stats.Sum() + val > Constants.MaxStatSum)
                return false;
            Stats[attr] += val;
            FreeStatPoints = Constants.MaxStatSum - Stats.Sum();
            return true;
        }

        #region Skills 

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
            return skillInfo.Difficulty + 1 <= FreeSkillPoints && Level > skillPoints;
        }

        private int GetOrCreateSkillPoints(int skillId)
        {
            if (Skills.ContainsKey(skillId))
                return Skills[skillId];
            Skills.Add(skillId, 0);
            return 0;
        }

        #endregion
    }
}