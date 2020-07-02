using Boot.Models.JsonModels;
using System.Web.Mvc;

namespace Boot.Models
{
    public class RequirementSelectModel
    {
        public int Pos { get; set; }
        public Requirement Selected { get; set; }
        public SelectList Requirements { get; set; }
        public SelectList Values { get; set; }
    }
}