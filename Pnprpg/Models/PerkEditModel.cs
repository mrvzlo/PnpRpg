using Boot.Models.JsonModels;
using System.Collections.Generic;

namespace Boot.Models
{
    public class PerkEditModel
    {
        public int? Id { get; set; }
        public List<Requirement> Requirements { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}