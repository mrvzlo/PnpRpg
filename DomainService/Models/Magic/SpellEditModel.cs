namespace Pnprpg.DomainService.Models
{
    public class SpellEditModel : IBaseEditModel
    {
        public int Id { get; set; }
        public int MagicSchoolId { get; set; }
        public int Level { get; set; }
        public int Damage { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Effect { get; set; }
    }
}
