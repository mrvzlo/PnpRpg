using Pnprpg.DomainService.Enums;

namespace Pnprpg.DomainService.Models
{
    public class MajorShortModel
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Short => ((MajorType) Id).ToString();
    }
}
