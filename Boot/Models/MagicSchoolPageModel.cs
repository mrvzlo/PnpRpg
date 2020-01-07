using System;
using Boot.Enums;

namespace Boot.Models
{
    public class MagicSchoolPageModel
    {
        public string Color, Header1, Header2, Content1, Content2;

        public MagicSchoolPageModel(AttributeType attr)
        {
            switch (attr)
            {
                case AttributeType.Strength:
                    Color = "danger";
                    break;
                case AttributeType.Perception:
                    Color = "warning";
                    break;
                case AttributeType.Agility:
                    Color = "info";
                    break;
                case AttributeType.Intelligence:
                    Color = "info";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(attr), attr, null);
            }
        }
    }
}