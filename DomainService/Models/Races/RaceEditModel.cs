using System.Collections.Generic;

namespace Pnprpg.DomainService.Models
{
    public class RaceEditModel
    {
        public int Id { get; set; }
        public int Karma { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<EffectDescModel> Effects { get; set; }
    }
}