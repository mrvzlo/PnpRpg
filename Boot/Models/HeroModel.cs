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
                Stats[i] = 1;
            switch (chaos)
            {
                case ChaosLevel.Normal:
                    for (var i = 0; i < Stats.Length; i++)
                        Stats[i] = 8;
                    return;
                case ChaosLevel.High:
                    MinAttr = 1;
                    return;
                case ChaosLevel.Extreme:
                    MinAttr = 20;
                    for (var i = 0; i < Stats.Length; i++)
                        Stats[i] = 10;
                    for (var i = 0; i < 10; i++)
                    {
                        RandomDiverse(-1, rand.Next(4));
                        RandomDiverse(1, rand.Next(4));
                    }
                    return;
                case ChaosLevel.Random:
                    MinAttr = 20;
                    for (var i = 0; i < Stats.Length; i++)
                        Stats[i] = rand.Next(20) + 1;
                    return;
            }
        }

        private void RandomDiverse(int val, int attr)
        {
            Stats[attr] += val;
        }

        public bool ChangeAttr(StatType attr, int val)
        {
            if (Stats[(int)attr] + val < MinAttr || Stats[(int)attr] + val > 20)
                return false;
            Stats[(int)attr] += val;
            return true;
        }
    }
}