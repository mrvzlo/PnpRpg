using System.Linq;
using Pnprpg.DomainService.Entities;

namespace Pnprpg.DomainService.IRepositories
{
    public interface IBaseRepository<T> where T : BaseEntity<int>
    {
        T Get(int id);
        T GetRandom();
        IQueryable<T> Select();
        void InsertOrUpdate(T entity);
        void Delete(T entity);
        void Delete(int id);
        void BatchInsert(IQueryable<T> list);
    }
}
