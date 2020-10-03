using System;

namespace FightBalancer
{
    public static class Randomizer
    {
        public static Random Rand;

        public static void Init()
        {
            Rand = new Random();
        }

        public static int Roll(int max) => Rand.Next(max);

        public static bool CheckRoll(int value, int max = 20)
        {
            var roll = Roll(max) < value;
            return roll;
        }

        public static int Damage(int count)
        {
            var result = 0;
            for (var i = 0; i < count; i++)
                result += RollDmg();
            return result;
        }

        private static int RollDmg()
        {
            var damage = (Rand.Next(6) + 3) / 2;
            return damage;
        }
    }
}
