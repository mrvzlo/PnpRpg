using System.Linq;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface INewsService
    {
        void Save(NewsEditModel model);
        IQueryable<NewsViewModel> GetAll();
        NewsEditModel GetForEdit(int? id);
        void Delete(int id);
    }
}
