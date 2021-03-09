using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Major
{
    public class IndexModel : MajorPage
    {
        public string Name { get; set; }

        public IndexModel(IMajorService majorService) : base(majorService) { }

        public void OnGet(MajorType major)
        {
            var majorModel = MajorService.GetFullModel((int)major);
            Name = majorModel.Name;
        }
    }
}
