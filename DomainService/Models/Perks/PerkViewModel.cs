namespace Pnprpg.DomainService.Models
{
    public class PerkViewModel : Upgradeable, IBaseViewModel
    {
        public int BranchId { get; set; }
        public string Description { get; set; }
        public virtual BranchShortModel Branch { get; set; }
    }
}
