using System.Collections.Generic;
using System.Linq;
using Pnprpg.DomainService.Helpers;

namespace Pnprpg.DomainService.Models
{
    public class UpgradeableGroup<T> where T : Upgradeable
    {
        public List<T> List;

        public int Limit;

        public UpgradeableGroup() => Reset();

        public void Reset() => List = new List<T>();

        public T Get(int id) => List.FirstOrDefault(x => x.Id == id);

        public int TotalSpentPoints() => List.Sum(x => x.SpentPoints());

        public bool IsUpdateable(T target, int modifier = 1) =>
            target.FitsLimits(modifier) && FitsLimit(target, modifier);

        protected virtual bool FitsLimit(T target, int modifier) => 
            (modifier + TotalSpentPoints()).Fits(Limit);

        public bool Update(int id, int modifier = 1, bool manual = true)
        {
            var target = List.Single(x => x.Id == id);
            return Update(target, modifier, manual);
        }

        public bool Update(T target, int modifier = 1, bool manual = true)
        {
            if (manual && !FitsLimit(target, modifier))
                return false;

            if (List.All(x => x.Id != target.Id))
                List.Add(target);

            target = List.Single(x => x.Id == target.Id);
            var result = target.Update(modifier, manual);
            if (result && target.Level == 0)
                List.Remove(target);
            
            return result;
        }
    }
}
