using System.Collections.Generic;

namespace Boot.Models.JsonModels
{
    public class SkillGroupList
    {
        public List<SkillGroup> Groups;
        public int Selected, FreePoints;
        public bool Editable;
    }
}