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
        public int MinAttr;
        public int[] Skills = new int[3];

        public HeroModel() { }

        public HeroModel(string data)
        {
            var count = EnumExtensions.GetEnumCount(typeof(StatType));
            var list = data.ToCharArray().Select(Decode).ToList();
            Stats = new int[count];
            for (var i = 0; i < Stats.Length; i++)
                Stats[i] = list[i];
            MinAttr = list[count];
            for (var i = 0; i < Skills.Length; i++)
                Skills[i] = list[Stats.Length + 1 + i];
        }

        public override string ToString()
        {
            var list = Stats.ToList();
            list.AddRange(new[] { MinAttr });
            list.AddRange(Skills);
            var chars = list.Select(Encode).ToArray();
            return new string(chars);
        }

        public HeroModel(ChaosLevel chaos)
        {
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
            if (Stats[(int) attr] + val < MinAttr || Stats[(int)attr] + val > 20)
                return false;
            Stats[(int) attr] += val;
            return true;
        }

        private char Encode(int a) => Convert.ToChar(a + 'A');
        private int Decode(char c) => Convert.ToInt32(c - 'A');
    }
}