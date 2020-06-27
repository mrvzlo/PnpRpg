using Boot.Enums;

namespace Boot.Models.JsonModels
{
    public class Requirement
    {
        public RequirementType type;
        public int value;
        public string strValue, statId;

        public Stat Stat;
    }
}