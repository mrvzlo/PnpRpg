using Boot.Enums;
using Boot.Helpers;

namespace Boot.Models
{
    public class MagicSchoolPageModel
    {
        public string Color, Header1, Header2, Content1, Content2;

        public MagicSchoolPageModel(StatType attr)
        {
            Color = attr.Color();
        }
    }
}