using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Entities
{
    public class BaseSettingPart : BaseEntity
    {
        public int MajorId { get; set; }
        public virtual Major Major { get; set; }
    }
}
