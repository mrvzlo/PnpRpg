using System;
using System.Web.Mvc;

namespace Pnprpg.DomainService.Models
{
    public class NewsEditModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
