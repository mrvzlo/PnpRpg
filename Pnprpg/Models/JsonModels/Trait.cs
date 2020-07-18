using System.Collections.Generic;
using Boot.Models.JsonModels;

namespace Boot.Models
{
    public class Trait
    {
        public List<Effect> Effects;
        public int Id;
        public string Name;
        public bool Chosen;
    }
}