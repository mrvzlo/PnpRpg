using System.ComponentModel;

namespace Pnprpg.DomainService.Enums
{
    public enum MajorType
    {
        [Description("fantasy")]
        Fantasy = 1,
        [Description("noir")]
        Noir = 2,
        [Description("postwar")]
        PostApocalypse = 3,
    }
}
