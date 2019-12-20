using System;
using System.Web.UI;

namespace Boot.Models
{
    public class HeroModel
    {
        public int S, A, P, I;
        public int MinAttr;
        public int Skill1, Skill2, Skill3;

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