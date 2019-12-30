using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace Boot.Models
{
    public class HeroModel
    {
        public int S, A, P, I;
        public int MinAttr;
        public int Skill1, Skill2, Skill3;

        public HeroModel() { }

        public HeroModel(string data)
        {
            var list = data.ToCharArray().Select(x => Convert.ToInt32(x - 64)).ToList();
            S = list[0];
            A = list[0];
            P = list[0];
            I = list[0];
            MinAttr = list[0];
            Skill1 = list[0];
            Skill2 = list[0];
            Skill3 = list[0];
        }

        public override string ToString()
        {
            var list = new List<int> { S, A, P, I, MinAttr, Skill1, Skill2, Skill3 };
            return list.Select(x => Convert.ToChar(x + 64)).ToString();
        }

        public HeroModel(ChaosLevel chaos)
        {
            S = A = P = I = 1;
            switch (chaos)
            {
                case ChaosLevel.Normal:
                    MinAttr = S = A = P = I = 8;
                    return;
                case ChaosLevel.High:
                    MinAttr = 1;
                    return;
                case ChaosLevel.Extreme:
                    MinAttr = 20;
                    S = A = P = I = 10;
                    break;
            }

            var rand = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < 10; i++)
            {
                RandomDiverse(-1, rand.Next(4));
                RandomDiverse(1, rand.Next(4));
            }
        }

        private void RandomDiverse(int val, int attr)
        {
            switch (attr)
            {
                case 0: S += val; break;
                case 1: A += val; break;
                case 2: P += val; break;
                case 3: I += val; break;
            }
        }
    }
}