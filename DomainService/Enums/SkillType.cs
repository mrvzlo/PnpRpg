using System.ComponentModel;

namespace Pnprpg.DomainService.Enums
{
    public enum SkillType
    {
        [Description("Общий")]
        None, 
        [Description("Оружейный")]
        Weapon,
        [Description("Магический")]
        Magic
    }
}
