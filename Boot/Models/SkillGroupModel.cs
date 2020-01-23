using System.Collections.Generic;
using System.IO;
using System.Linq;
using Boot.Helpers;

namespace Boot.Models
{
    public class SkillGroupModel
    {
        public int Group;
        public bool Editable;
        public string GroupName;
        public List<SkillModel> Skills;

        public SkillGroupModel(int group, string path, bool editable = false, HeroModel hero = null)
        {
            Group = group;
            Editable = editable;
            int count;
            var data = File.ReadAllLines(path);
            string[] firstLine;
            var i = 0;
            do
            {
                firstLine = data[i].Split(StringHelper.Separator);
                count = int.Parse(firstLine[1]);
                i += count + 1;
            } while (group-- != 0);

            GroupName = StringHelper.FormatToSentence(firstLine.First());
            Skills = new List<SkillModel>();
            for (var j = 0; j < count; j++)
                Skills.Add(new SkillModel(data[i - count + j], group, hero));
        }
    }
}