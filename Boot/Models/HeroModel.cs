using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Boot.Enums;

namespace Boot.Models
{
    public class HeroModel
    {
        public int S, A, P, I;
        public int MinAttr;
        public int Skill1, Skill2, Skill3;
        public int Sum => S + A + P + I;

        public HeroModel() { }

        public HeroModel(string data)
        {
            var list = data.ToCharArray().Select(Decode).ToList();
            S = list[0];
            A = list[1];
            P = list[2];
            I = list[3];
            MinAttr = list[4];
            Skill1 = list[5];
            Skill2 = list[6];
            Skill3 = list[7];
        }

        public override string ToString()
        {
            var list = new List<int> { S, A, P, I, MinAttr, Skill1, Skill2, Skill3 };
            var chars = list.Select(Encode).ToArray();
            return new string(chars);
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

        public bool ChangeAttr(AttributeType attr, int val)
        {
            switch (attr)
            {
                case AttributeType.Strength:
                    if (S + val < MinAttr)
                        return false;
                    S += val;
                    return true;
                case AttributeType.Perception:
                    if (P + val < MinAttr)
                        return false;
                    P += val;
                    return true;
                case AttributeType.Agility:
                    if (A + val < MinAttr)
                        return false;
                    A += val;
                    return true;
                case AttributeType.Intelligence:
                    if (I + val < MinAttr)
                        return false;
                    I += val;
                    return true;
                default:
                    throw new ArgumentOutOfRangeException(nameof(attr), attr, null);
            }
        }

        private char Encode(int a) => Convert.ToChar(a + 'A');
        private int Decode(char c) => Convert.ToInt32(c - 'A');
    }
}