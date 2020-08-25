using System.Linq;
using System.Web.Mvc;

namespace Pnprpg.Web.Helpers
{
    public static class SelectListExtension
    {
        public static void Select(this SelectList list, int value)
        {
            foreach (var item in list.Where(x => x.Value == value.ToString())) 
                item.Selected = true;
        }
    }
}