using System.IO;
using Boot.Enums;
using Boot.Helpers;

namespace Boot.Models
{
    public class MagicSchoolPageModel
    {
        public readonly string Common, Header1, Header2, Content1, Content2;
        public readonly StatType Stat;

        public MagicSchoolPageModel(StatType stat, string path)
        {
            Stat = stat;
            var allStrings = File.ReadAllLines(path);
            var from = (int)stat * (1 + 5 * 2); // 1 - common, 1 - header 4 - content
            Common = allStrings[from++];
            Header1 = allStrings[from++];
            Content1 = allStrings[from++];
            for (var i = 0; i < 3; i++)
                Content1 += "<br/>" + allStrings[from++];
            Header2 = allStrings[from++];
            Content2 = allStrings[from++];
            for (var i = 0; i < 3; i++)
                Content2 += "<br/>" + allStrings[from++];
        }
    }
}