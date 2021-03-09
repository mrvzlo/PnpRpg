using System.Collections.Generic;
using System.Linq;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IDonationService
    {
        IQueryable<DonationEditModel> GetEditModels();
        IQueryable<DonationViewModel> GetAll();
        void SaveAll(List<DonationEditModel> list);
    }
}
