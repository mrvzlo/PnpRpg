using Boot.Enums;
using Boot.Helpers;

namespace Boot.Models
{
    public class SkillModel
    {
        public int Group;
        public int Points;
        public int Difficulty;
        public bool Increasable;
        public StatType Stat;
        public string Name;

        public SkillModel(string data, int group, HeroModel hero = null)
        {
            Group = group;
            var split = data.Split(StringHelper.Separator);
            Stat = (StatType)int.Parse(split[0]);
            Name = StringHelper.FormatToSentence(split[1]);
            Difficulty = int.Parse(split[2]);
            if (hero == null) return;

            Points = hero.Skills[Name];
            Increasable = hero.FreeSkillPoints >= Difficulty;
        }
    }
}