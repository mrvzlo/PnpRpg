using System;
using System.Linq;
using Boot.Enums;
using Boot.Helpers;

namespace Boot.Models
{
    public class HeroModel
    {
        public int[] Stats;
        public int MinAttr, Level;
        public int[] Skills = new int[3];

        public int MaxHp() => Stats[(int)StatType.S] + Level * 2 - 2;
        public int MaxEp() => Math.Max(Stats[(int)StatType.I] + Level - 4, 0);
        public int MaxCarry() => Stats[(int)StatType.S] * Stats[(int)StatType.S] / 10;

        public HeroModel() { }

        public HeroModel(string data)
        {
            if (string.IsNullOrEmpty(data)) return;
            var count = EnumExtensions.GetEnumCount(typeof(StatType));
            var list = data.Split('.').Select(int.Parse).ToList();
            Stats = new int[count];
            for (var i = 0; i < Stats.Length; i++)
                Stats[i] = list[i];
            for (var i = 0; i < Skills.Length; i++)
                Skills[i] = list[Stats.Length + i];

            MinAttr = list[Stats.Length + Skills.Length];
            Level = list[Stats.Length + Skills.Length + 1];
        }

        public override string ToString()
        {
            var list = Stats.ToList();
            list.AddRange(Skills);
            list.AddRange(new[] { MinAttr, Level });
            return string.Join(".", list);
        }

        public HeroModel(ChaosLevel chaos)
        {
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
                    MinAttr = Constants.MaxStat;
                    for (var i = 0; i < Stats.Length; i++)
                        Stats[i] = Constants.MaxStat;
                    for (var i = 0; i < Constants.MaxStat / 2; i++)
                    {
                        Stat(rand.Next(count), - 1);
                        Stat(rand.Next(count), 1);
                    }
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