using System.Web.Mvc;

namespace Pnprpg.DomainService.Models
{
    public class FormQueryItem<T> where T: class
    {
        public T Selected { get; set; }
        public SelectList List { get; set; }
        public int Position { get; set; }
    }
}