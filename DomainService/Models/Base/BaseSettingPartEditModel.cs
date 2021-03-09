using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class BaseSettingPartEditModel : IBaseEditModel
    {
        public int Id { get; set; }
        public MajorType MajorId { get; set; }
    }
}
