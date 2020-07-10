using Boot.Enums;
using Boot.Models.JsonModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Boot.Models
{
    public class PerkEditModel
    {
        public int? Id { get; set; }
        public List<Requirement> Requirements { get; set; }
        public int Level { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Desc { get; set; }
        public List<EffectType> Effects { get; set; }
    }
}