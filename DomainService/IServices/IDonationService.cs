using System.Collections.Generic;
using System.Linq;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IDonationService : IViewService<DonationViewModel>
    {
        IQueryable<DonationEditModel> GetEditModels();
        void SaveAll(List<DonationEditModel> list);
    }
}
