using System.ComponentModel;

namespace Boot.Enums
{
    public enum Race
    {
        [Description("Человек")] human,
        [Description("Светлый эльф")] elf,
        [Description("Тёмный эльф")] drow,
        [Description("Змеелюд")] sneak,
        [Description("Ворген")] vorgen,
        [Description("Орк")] ork,
        [Description("Гном")] dwarf,
        [Description("Тролль")] troll,
        [Description("Демон")] demon
    }
}