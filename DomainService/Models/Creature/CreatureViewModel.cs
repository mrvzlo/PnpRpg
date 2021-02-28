namespace Pnprpg.DomainService.Models
{
    public class CreatureViewModel : IBaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
    }
}
