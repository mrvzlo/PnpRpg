using System;

namespace Pnprpg.DomainService.Entities
{
    public class News : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
