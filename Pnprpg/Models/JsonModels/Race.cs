using System.Collections.Generic;

namespace Boot.Models.JsonModels
{
    public class Race
    {
        public int Id;
        public string Name;
        public List<Effect> Effects;

        public bool Chosen;
    }
}