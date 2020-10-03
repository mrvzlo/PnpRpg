namespace FightBalancer
{
    public class Fighter
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Weapon { get; set; }
        public int Armor { get; set; }
        public int HealthPoints { get; set; }
        public int Agility { get; set; }
        public int Speed { get; set; }

        public int Hits { get; set; }
        public int Rounds { get; set; }
        public int DealtDamage { get; set; }

        public FighterLog Logs { get; set; }

        public bool IsAlive() => HealthPoints > 0;

        public Fighter(int weapon, int armor, int health, int agility, int level, int speed = 1)
        {
            Weapon = weapon;
            Armor = armor;
            HealthPoints = health;
            Agility = agility;
            Level = level;
            Hits = 0;
            Speed = speed;
            ResetLogs();
        }

        public void ResetLogs() => Logs = new FighterLog(this);

        public void AttackOn(Fighter attacker)
        {
            for (var i = 0; i < Speed; i++)
                attacker.GetHit(Damage());
        }

        public override string ToString() =>
            $"{Name} {Level} | Dmg {Weapon} | Armor {Armor} | HP {HealthPoints} | Hit chance {Agility}\n";

        private int Damage()
        {
            Rounds++;
            var hit = Randomizer.CheckRoll(Agility);
            if (!hit) return 0;
            Hits++;
            var damage = Randomizer.Damage(Weapon);
            DealtDamage += damage;
            return damage;
        }

        private void GetHit(int damage)
        {
            damage -= Armor;
            if (damage > 0)
                HealthPoints -= damage;
        }
    }
}
