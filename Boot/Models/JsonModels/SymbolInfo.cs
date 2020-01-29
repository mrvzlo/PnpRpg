using System.Web.Mvc;

namespace Boot.Models.JsonModels
{
    public class SymbolInfo
    {
        public int id;
        public char symbol;
        public string name;

        public SelectListItem ToSelectListItem()
        {
            return new SelectListItem
            {
                Value = id.ToString(),
                Text = ToString()
            };
        }

        public override string ToString() => $"{symbol} {name}";
    }
}