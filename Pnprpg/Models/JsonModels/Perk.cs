using System.Collections.Generic;

namespace Boot.Models.JsonModels
{
    public class Perk
    {
        public int Id { get; set; }
        public List<Requirement> Requirements { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}