using System.Linq;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IViewService<out T> where T : IBaseViewModel
    {
        IQueryable<T> GetAll(int? filter = null);
    }
}
