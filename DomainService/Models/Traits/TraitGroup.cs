using System.Collections.Generic;
using System.Linq;

namespace Pnprpg.DomainService.Models
{
    public class TraitGroup
    {
        public List<TraitModel> List;

        public TraitGroup() => ResetTraits();

        public void ResetTraits() => List = new List<TraitModel>();

        public bool IsAssignable(TraitModel model)
        {
            var assigned = List.Where(x => x.Level > 0).ToList();
            return assigned.All(x => x.Id != model.Id) && assigned.Count < 2;
        }
    }
}
