using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightBalancer
{
    public class FighterLog
    {
        public int Deaths { get; set; }
        public Log Hits { get; set; }
        public Log Health { get; set; }
        public Log DealtDamage { get; set; }
        public Log Rounds { get; set; }

        public FighterLog(Fighter fighter)
        {
            Health = new Log();
            Hits = new Log();
            DealtDamage = new Log();
            Rounds = new Log();
        }

        public void UpdateLogs(Fighter fighter)
        {
            Hits.Add(fighter.Hits);
            Health.Add(fighter.HealthPoints);
            DealtDamage.Add(fighter.DealtDamage);
            Rounds.Add(fighter.Rounds);
            if (!fighter.IsAlive())
                Deaths++;
        }
    }
}
