using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace FightBalancer
{
    public class Team
    {
        public List<Fighter> Members { get; set; }

        public Team()
        {
            Members = new List<Fighter>();
        }

        public Team Clone()
        {
            var team = JsonConvert.DeserializeObject<Team>(JsonConvert.SerializeObject(this));
            foreach (var member in team.Members) 
                member.ResetLogs();
            return team;
        }

        public void Add(Fighter fighter) => Members.Add(fighter);

        public int FightWith(Team enemy)
        {
            var rounds = 0;
            while (IsAlive() && enemy.IsAlive())
            {
                rounds++;
                AttackOn(enemy);
                enemy.AttackOn(this);
            }

            return rounds;
        }

        public void AttackOn(Team enemy)
        {
            foreach (var member in Members)
            {
                if (!enemy.IsAlive() || !member.IsAlive()) return;
                var targets = enemy.Members.Where(x => x.IsAlive()).ToList();
                var count = targets.Count();
                var target = targets.Skip(Randomizer.Roll(count)).First();
                member.AttackOn(target);
            }
        }

        public bool IsAlive() => Members.Any(x => x.IsAlive());
    }
}
