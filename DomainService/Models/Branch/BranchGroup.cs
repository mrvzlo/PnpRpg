using System.Collections.Generic;
using System.Linq;

namespace Pnprpg.DomainService.Models
{
    public class BranchGroup
    {
        public List<BranchViewModel> List;

        public BranchGroup() => Reset();

        public void Reset() => List = new List<BranchViewModel>();
    }
}
