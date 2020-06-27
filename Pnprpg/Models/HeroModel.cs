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
        public List<HeroStat> Stats;
        public int[] Traits;
        public int Level, Race;
        public ChaosLevel Chaos;
        public Dictionary<int, int> Skills;
        public int UsedSkillPoints;
        
        public string Name;

        #region SaveLoad

        public HeroModel(string data, List<Stat> stats)
        {
            Stats = new List<HeroStat>();
            ResetSkills();
            ResetTraits();
            if (string.IsNullOrEmpty(data)) return;
            var list = data.Split(StringHelper.Separator);
            if (list.Length < 2) return;
            var x = 0;
            Name = list[x++];
            var count = int.Parse(list[x++]);
            if (count != stats.Count)
                return;

            for (int i=0; i<count; i++)
            {
                var symbol = list[x++];
                var stat = new HeroStat(stats.Single(y => y.Id == symbol))
                {
                    Value = int.Parse(list[x++])
                };
                Stats.Add(stat);
            }

            var intData = list.Skip(x).Select(int.Parse).ToList();
            x = 0;

            Level = intData[x++];
            Race = intData[x++];
            Chaos = (ChaosLevel)intData[x++];
            var skillsCount = intData[x++];
            for (var i = 0; i < skillsCount; i++)
                Skills.Add(intData[x++], intData[x++]);
            for (var i = 0; i < Constants.TraitCount; i++)
                Traits[i] = intData[x++];
        }

        public override string ToString()
        {
            var list = new List<string> { Name, Stats.Count().ToString() };
            list.AddRange(Stats.Select(x => $"{x.Id}{StringHelper.Separator}{x.Value}"));
            list.AddRange(new[] { Level, Race, (int)Chaos }.Select(x => x.ToString()));
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

        public HeroModel(ChaosLevel chaos, List<Stat> stats)
        {
            Name = "";
            Stats = new List<HeroStat>();
            ResetSkills();
            ResetTraits();
            Level = 1;
            Chaos = chaos;
            var count = stats.Count;
            for (int i = 0; i < count; i++)
            {
                var stat = new HeroStat(stats[i]);
                stat.Set(chaos);
                Stats.Add(stat);
            }
        }
        
        public void LoadRace(Race race)
        {
            race.effects?.ForEach(x => ApplyStatEffect(x, false, true));
        }

        #endregion

        #region SecondStats

        public int GetStat(string symbol) => Stats.Single(x => x.Id == symbol).Value;

        public int FreeStatPoints() =>
            Chaos == ChaosLevel.Random ? 0 : Constants.ManualStatSum - Stats.Select(x => x.Value).Sum();
        public int FreeSkillPoints() =>
            Constants.BaseSkillPoints + Constants.SkillPointsPerLvl * Level - UsedSkillPoints;

        public int BaseArmor() => (GetStat("E") + 5) / 10;
        public int BaseDmg() => (GetStat("S") + 5) / 10;
        public int MaxHp() => GetStat("E") + Level * 2 - 2;
        public int MaxEp() => Math.Max(GetStat("I") + Level - 4, 0);
        public int MaxCarry() => GetStat("S") * GetStat("E") / 10;

        #endregion

        public bool ChangeRace(Race oldRace, Race newRace)
        {
            if (oldRace.id == newRace.id)
                return false;
            Race = newRace.id;
            oldRace.effects?.ForEach(x => ApplyStatEffect(x, true));
            newRace.effects?.ForEach(x => ApplyStatEffect(x));

            return Stats.All(x => x.IsValid());
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

        public bool ManualIncStat(string attr, int val)
        {
            return Stats.Single(x => x.Id == attr).ManualBoost(val);
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

        private void ApplyStatEffect(Effect effect, bool revert = false, bool baseOnly= false)
        {
            if (effect.type != EffectType.Weaken && effect.type != EffectType.Boost)
                return;
            var value = effect.value;
            if (revert ^ effect.type == EffectType.Weaken)
                value *= -1;

            Stats.Single(x => x.Id == effect.statId).EffectBoost(value, baseOnly);
        }
    }
}