using System.Threading.Tasks;

namespace Pnprpg.WebCore.Helpers
{
    public interface IPageRenderer
    {
        Task<string> RenderPartialToStringAsync<TModel>(string viewName, TModel model);
    }
}
