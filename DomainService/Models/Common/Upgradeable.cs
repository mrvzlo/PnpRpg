using Pnprpg.DomainService.Helpers;

namespace Pnprpg.DomainService.Models
{
    public abstract class Upgradeable : Assignable
    {
        public int Difficulty { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public Upgradeable()
        {
            if (Difficulty == 0)
                Difficulty++;
        }

        public virtual int SpentPoints() => Level * Difficulty;

        public virtual bool FitsLimits(int modifier) => (modifier + Level).Fits(Max, Min);

        public bool Update(int modifier, bool manual)
        {
            if (manual && !FitsLimits(modifier))
                return false;

            Level += modifier;
            if (!manual) 
                AdjustBase(modifier);

            return true;
        }

        public void AdjustBase(int value)
        {
            Min += value;
            Max += value;
        }
    }
}
