using Boot.Enums;
using Boot.Helpers;

namespace Boot.Models.JsonModels
{
    public class SkillInfo
    {
        public int Id, Difficulty, Level;
        public bool CanInc;
        public string Name;
        public StatType Stat;

        public override string ToString()
        {
            var name = StringHelper.FormatToSentence(Name);
            if (Level > 0) name = $"{name} ({Level})";
            return name;
        }
    }
}