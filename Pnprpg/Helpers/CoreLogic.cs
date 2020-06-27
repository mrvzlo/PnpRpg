using System.Collections.Generic;
using System.Linq;
using Boot.Models;
using Boot.Models.JsonModels;

namespace Boot.Helpers
{
    public class CoreLogic
    {
        public static int CalculateSkillPoints(HeroModel hero, List<SkillInfo> list) => 
            hero.Skills.Sum(skill => (list.Single(x => x.Id == skill.Key).Difficulty + 1) * skill.Value);
    }
}