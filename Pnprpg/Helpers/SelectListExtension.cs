using System.Linq;
using System.Web.Mvc;

namespace Pnprpg.Web.Helpers
{
    public static class SelectListExtension
    {
        public static void SelectId(this SelectList list, int value)
        {
            foreach (var item in list)
            {
                item.Selected = item.Value == value.ToString();
                if (item.Selected)
                    break;
            }
        }
    }
}