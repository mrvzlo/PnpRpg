using System.Collections.Generic;

namespace Boot.Models.JsonModels
{
    public class MagicSchoolGroup
    {
        public string Special, Element, StatId;
        public List<MagicSchoolInfo> Schools;
        public Stat Stat;
    }
}