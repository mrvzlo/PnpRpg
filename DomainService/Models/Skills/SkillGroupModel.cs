using System.Collections.Generic;

namespace Pnprpg.DomainService.Models.Skills
{
    public class SkillGroupModel
    {
        public int Id;
        public string Name;
        public List<SkillModel> Skills;
    }
}