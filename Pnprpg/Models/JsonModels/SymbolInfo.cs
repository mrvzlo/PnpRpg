using System.Web.Mvc;

namespace Boot.Models.JsonModels
{
    public class SymbolInfo
    {
        public int Id;
        public string Symbol;
        public string Name;
        public int Value;

        public SelectListItem ToSelectListItem()
        {
            return new SelectListItem
            {
                Value = Value.ToString(),
                Text = ToString()
            };
        }

        public override string ToString() => $"{Symbol} {Name}";
    }
}