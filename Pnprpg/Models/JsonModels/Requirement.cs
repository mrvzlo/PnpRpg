using Boot.Enums;

namespace Boot.Models.JsonModels
{
    public class Requirement
    {
        public RequirementType type { get; set; }
        public int value { get; set; }
        public string strValue { get; set; }
        public string statId { get; set; }

        public Stat Stat;
    }
}