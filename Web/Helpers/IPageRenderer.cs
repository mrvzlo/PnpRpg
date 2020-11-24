using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pnprpg.WebCore.Helpers
{
    public interface IPageRenderer
    {
        Task<string> RenderPartialToStringAsync<TModel>(string viewName, TModel model);
    }
}
