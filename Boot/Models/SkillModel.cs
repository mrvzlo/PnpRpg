using Boot.Enums;
using Boot.Helpers;

namespace Boot.Models
{
    public class SkillModel
    {
        public int Difficulty;
        public StatType Stat;
        public string Name;

        public SkillModel(string data)
        {
            var split = data.Split(StringHelper.Separator);
            Stat = (StatType)int.Parse(split[0]);
            Name = StringHelper.FormatToSentence(split[1]);
            Difficulty = int.Parse(split[2]);
        }
    }
}