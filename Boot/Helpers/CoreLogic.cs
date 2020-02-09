using System.Linq;
using Boot.Models;
using Boot.Models.JsonModels;

namespace Boot.Helpers
{
    public class CoreLogic
    {
        public static int CalculateSkillPoints(HeroModel hero, SkillGroupList list) => 
            hero.Skills.Sum(skill => (list.Groups[skill.Key / 10].skills[skill.Key % 10].Difficulty + 1) * skill.Value);
    }
}