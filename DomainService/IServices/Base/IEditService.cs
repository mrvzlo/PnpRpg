using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IEditService<out T> where T : IBaseEditModel
    {
        T GetForEdit(int? id);
        void Delete(int id);
    }
}
