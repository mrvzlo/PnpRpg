using System.Collections.Generic;

namespace Boot.Models.JsonModels
{
    public class Race
    {
        public int id;
        public string name;
        public List<Effect> effects;

        public bool Chosen;
    }
}