using System;
using System.Collections.Generic;
using System.Linq;
using Boot.Enums;
using Boot.Helpers;

namespace Boot.Models
{
    public class HeroModel
    {
        public int[] Stats;
        public int MinAttr, Level;
        public Dictionary<string, int> Skills;

        public int MaxHp() => Stats[(int)StatType.S] + Level * 2 - 2;
        public int MaxEp() => Math.Max(Stats[(int)StatType.I] + Level - 4, 0);
        public int MaxCarry() => Stats[(int)StatType.S] * Stats[(int)StatType.S] / 10;

        public HeroModel() { }

        public HeroModel(string data)
        {
            Skills = new Dictionary<string, int>();
            if (string.IsNullOrEmpty(data)) return;
            var count = EnumExtensions.GetEnumCount(typeof(StatType));
            var list = data.Split(StringHelper.Separator).ToList();
            Stats = new int[count];
            var x = 0;
            for (var i = 0; i < Stats.Length; i++)
                Stats[i] = Convert.ToInt32(list[x++]);
            MinAttr = Convert.ToInt32(list[x++]);
            Level = Convert.ToInt32(list[x++]);
            var skillsCount = Convert.ToInt32(list[x++]);
            for (var i = 0; i < skillsCount; i++)
                Skills.Add(list[x++], Convert.ToInt32(list[x++]));
        }

        public override string ToString()
        {
            var list = Stats.Select(x => x.ToString()).ToList();
            list.AddRange(new[] { MinAttr, Level }.Select(x => x.ToString()));
            list.Add(Skills.Count.ToString());
            if (Skills.Any())
                list.AddRange(Skills.Select(x => $"{x.Key}{StringHelper.Separator}{x.Value}"));
            return string.Join($"{StringHelper.Separator}", list);
        }

        public HeroModel(ChaosLevel chaos)
        {
            Skills = new Dictionary<string, int>();
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
                    return;
                case ChaosLevel.High:
                    return;
                case ChaosLevel.Extreme:
                    for (var i = 0; i < Stats.Length; i++)
                        Stats[i] = Constants.MaxStat / 2;
                    for (var i = 0; i < Constants.MaxStat / 2; i++)
                    {
                        Stat(rand.Next(count), -1);
                        Stat(rand.Next(count), 1);
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

        public bool Stat(int attr, int val)
        {
            if (Stats[attr] + val < MinAttr
                || Stats[attr] + val > Constants.MaxStat
                || Stats.Sum() + val > Constants.MaxStatSum)
                return false;
            Stats[attr] += val;
            return true;
        }
    }
}