using System.Collections.Generic;

namespace Boot.Models.JsonModels
{
    public class MagicSchoolInfo
    {
        public int Id;
        public string Name, Desc;
        public List<Spell> Spells;
    }
}