using System.ComponentModel;

namespace Pnprpg.DomainService.Enums
{
    public enum SkillType
    {
        [Description("Плутовской")]
        None, 
        [Description("Оружейный")]
        Weapon,
        [Description("Магический")]
        Magic
    }
}
