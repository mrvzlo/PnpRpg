namespace Pnprpg.DomainService.Models
{
    public class PerkViewModel : Upgradeable, IBaseViewModel
    {
        public string Description { get; set; }
        public BranchViewModel BranchView { get; set; }
    }
}
