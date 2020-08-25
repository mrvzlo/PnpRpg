using System.ComponentModel;

namespace Pnprpg.DomainService.Enums
{
    public enum BonusType
    {
        [Description("Оружейный")]
        Weapon,
        [Description("Классовый")]
        Branch,
        [Description("Рассовый")]
        Race
    }
}
