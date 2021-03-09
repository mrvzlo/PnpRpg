namespace Pnprpg.DomainService.Entities
{
    public class Creature : BaseSettingPart
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
    }
}
