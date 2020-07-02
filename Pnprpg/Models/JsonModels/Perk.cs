using System.Collections.Generic;

namespace Boot.Models.JsonModels
{
    public class Perk
    {
        public int id { get; set; }
        public List<Requirement> requirements { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
    }
}