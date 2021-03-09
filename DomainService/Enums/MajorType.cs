using System.ComponentModel;

namespace Pnprpg.DomainService.Enums
{
    public enum MajorType
    {
        [Description("")]
        Common = 0,
        [Description("fantasy")]
        Fantasy = 1,
        [Description("noir")]
        Noir = 2,
        [Description("postapoc")]
        PostApocalypse = 3,
    }
}
