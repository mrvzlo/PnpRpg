namespace Pnprpg.DomainService.Models
{
    public class SpellViewModel : IBaseViewModel
    {
        public int Id { get; set; }
        public int MagicSchoolId { get; set; }
        public int Level { get; set; }
        public int Damage { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Effect { get; set; }
        public string Color { get; set; }
        public string MagicSchoolName { get; set; }
    }
}