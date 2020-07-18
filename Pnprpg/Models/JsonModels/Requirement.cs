using Boot.Enums;

namespace Boot.Models.JsonModels
{
    public class Requirement
    {
        public RequirementType Type { get; set; }
        public int Value { get; set; }
        public string StrValue { get; set; }
        public string StatId { get; set; }
    }
}