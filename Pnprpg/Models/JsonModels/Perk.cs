using System.Collections.Generic;

namespace Boot.Models.JsonModels
{
    public class Perk
    {
        public int id;
        public List<Requirement> requirements;
        public string name, desc;
    }
}