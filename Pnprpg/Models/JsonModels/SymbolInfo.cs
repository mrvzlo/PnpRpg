using System.Web.Mvc;

namespace Boot.Models.JsonModels
{
    public class SymbolInfo
    {
        public int id;
        public string symbol;
        public string name;
        public string value;

        public SelectListItem ToSelectListItem()
        {
            return new SelectListItem
            {
                Value = value,
                Text = ToString()
            };
        }

        public override string ToString() => $"{symbol} {name}";
    }
}