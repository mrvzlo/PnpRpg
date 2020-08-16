using System.ComponentModel;

namespace Pnprpg.DomainService.Enums
{
    public enum SkillType
    {
        [Description("Не выбран")]
        None, 
        [Description("Оружейный")]
        Weapon,
        [Description("Магический")]
        Magic
    }
}
