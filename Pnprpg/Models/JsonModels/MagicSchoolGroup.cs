using System.Collections.Generic;
using Boot.Enums;

namespace Boot.Models.JsonModels
{
    public class MagicSchoolGroup
    {
        public StatType Stat;
        public string Special;
        public string Element;
        public List<MagicSchoolInfo> Schools;
    }
}