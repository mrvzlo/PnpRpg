using System.Linq;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface INewsService : IEditService<NewsEditModel>
    {
        int Save(NewsEditModel model);
        IQueryable<NewsViewModel> GetAll();
        NewsViewModel GetLatest();
    }
}
