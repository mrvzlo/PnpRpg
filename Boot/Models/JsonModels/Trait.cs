using System.Collections.Generic;
using Boot.Models.JsonModels;

namespace Boot.Models
{
    public class Trait
    {
        public List<Effect> effects;
        public int id;
        public string name;
        public bool Chosen;
    }
}